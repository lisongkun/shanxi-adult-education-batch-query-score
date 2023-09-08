using Flurl.Http;
using Newtonsoft.Json;
using ShanxiAdultEducationBatchQueryScore.Vo;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Sunny.UI;

namespace ShanxiAdultEducationBatchQueryScore
{
    /// <summary>
    /// 网站数据请求的类
    /// </summary>
    public class WebService
    {
        /// <summary>
        /// 账号登录
        /// </summary>
        /// <param name="username">学号</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功的Cookies</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<CookieJar> AccountLogin(string username, string password)
        {
            // 1.获取基础Cookies
            await "https://gkpt.sxkszx.cn/Ck-student-web/"
                .WithCookies(out var cookies)
                .WithHeader("User-Agent", NetContext.UserAgent)
                .GetAsync();
            var retryCount = 8;
            var body = "";
            while (retryCount > 0)
            {
                // 2.根据上一步的Cookies获取验证码
                var codeBytes = await "https://xysp.sxkszx.cn/Ck-student-web/code.do"
                    .WithCookies(cookies)
                    .WithHeader("User-Agent", NetContext.UserAgent)
                    .GetBytesAsync();
                // 3.图形识别接口调用
                var codeRequest = await "http://121.37.181.45:9898/ocr/file".PostMultipartAsync(mp =>
                    mp.AddFile("image", new MemoryStream(codeBytes), "code"));
                var code = await codeRequest.GetStringAsync();

                // 4.提交登录请求
                var request = await "https://xysp.sxkszx.cn/Ck-student-web/login_login".WithCookies(cookies)
                    .WithHeader("Referer", "https://xysp.sxkszx.cn/Ck-student-web/")
                    .WithHeader("Content-Type", NetContext.ContentTypeUrlEncoded)
                    .WithHeader("User-Agent", NetContext.UserAgent)
                    .PostUrlEncodedAsync(new
                    {
                        username,
                        password,
                        checkCode = code,
                        sbxx = "Win32"
                    });
                body = await request.GetStringAsync();
                // 5.判断是否为验证码错误,准备重试
                if (body.Contains("验证码已失效"))
                {
                    retryCount--;
                    continue;
                }
                break;
            }


            try
            {
                var vo = JsonConvert.DeserializeObject<LoginSuccessVo>(body);
                if (vo.result == "success")
                    return cookies;
                throw new Exception(vo.result);
            }
            catch (Exception e)
            {
                throw new Exception($"序列化登录文本失败,响应体为:{body}");
            }
        }

        /// <summary>
        /// 查询各项目成绩
        /// </summary>
        /// <param name="cookies"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<Dictionary<string, string>> QueryScore(CookieJar cookies)
        {
            var dic = new Dictionary<string, string>();
            var response = await "https://gkpt.sxkszx.cn/Ck-student-web/stuInfo/scoreSel"
                .WithCookies(cookies)
                .WithHeader("User-Agent",
                    NetContext.UserAgent)
                .GetStringAsync();

            if (response.Contains("您是免试生或未现场确认，不参加成人高考考试,无考试成绩"))
            {
                throw new Exception("您是免试生或未现场确认，不参加成人高考考试,无考试成绩");
            }

            var regex = new Regex("准考证号：(.*?) 姓名");
            var matches = regex.Matches(response);
            dic["学号"] = matches[0].Groups[1].Value;

            regex = new Regex("姓名：(.*?)</span>");
            matches = regex.Matches(response);
            dic["姓名"] = matches[0].Groups[1].Value;

            regex = new Regex("<td>(.*?)</td>", RegexOptions.Singleline);
            matches = regex.Matches(response);

            var index = 1;
            var key = "";
            foreach (Match match in matches)
            {
                if (index % 2 == 1)
                    key = match.Groups[1].Value.Trim();
                else
                    dic[key] = match.Groups[1].Value.Trim();

                index++;
            }


            return dic;
        }

        public static async Task<Dictionary<string, string>> GetAllInfo(CookieJar cookies)
        {
            var dic = new Dictionary<string, string>();
            var response = await "https://xysp.sxkszx.cn/Ck-student-web/zyck/to_zyck"
                .WithCookies(cookies)
                .WithHeader("User-Agent",
                    NetContext.UserAgent).SetQueryParam("number", "0.06261674744304668")
                .GetStringAsync();
            // 姓名
            var regex = new Regex("姓名</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            var matches = regex.Matches(response);
            dic["考生姓名"] = matches[0].Groups[1].Value;
            // 性别
            regex = new Regex("<td align=\"center\">性别</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["性别"] = matches[0].Groups[1].Value;
            // 出生日期
            regex = new Regex("<td align=\"center\">出生日期</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["出生日期"] = matches[0].Groups[1].Value;
            // 民族
            regex = new Regex("<td align=\"center\">民族</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["民族"] = matches[0].Groups[1].Value;
            // 政治面貌
            regex = new Regex("<td align=\"center\">政治面貌</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["政治面貌"] = matches[0].Groups[1].Value;
            // 文化程度
            regex = new Regex("<td align=\"center\">文化程度</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["文化程度"] = matches[0].Groups[1].Value;
            // 证件类型
            regex = new Regex("<td align=\"center\">证件类型</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["证件类型"] = matches[0].Groups[1].Value;
            // 证件号码
            regex = new Regex("<td align=\"center\">证件号码</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["证件号码"] = matches[0].Groups[1].Value;
            // 职业类别
            regex = new Regex("<td align=\"center\">职业类别</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["职业类别"] = matches[0].Groups[1].Value;
            // 外语语种
            regex = new Regex("<td align=\"center\">外语语种</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["外语语种"] = matches[0].Groups[1].Value;
            // 毕业学校
            regex = new Regex("<td align=\"center\">毕业学校</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["毕业学校"] = matches[0].Groups[1].Value;
            // 毕业日期
            regex = new Regex("<td align=\"center\">毕业日期</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["毕业日期"] = matches[0].Groups[1].Value;
            // 毕业证书编号
            regex = new Regex("<td align=\"center\">国民教育系列的专科及以上毕业证书编号</td>\r\n\t\t\t<td colspan=\"3\">(.*?)\r\n\t\t\t\r\n\t\t\t\r\n\t\t\t<span style=\"color: red\"> \r\n\t\t\t\r\n\t\t\t\\((.*?)\\)\r\n\t\t\t</span>");
            matches = regex.Matches(response);
            dic["毕业证书编号"] = matches[0].Groups[1].Value + matches[0].Groups[2].Value;
            // 工作单位位置
            regex = new Regex("<td align=\"center\">工作单位所在市、县（市、区）</td>\r\n\t\t\t<td><select disabled=\"disabled\">\r\n\t\t\t\t\t<option selected=\"selected\">(.*?)</option>\r\n\t\t\t</select> <select disabled=\"disabled\">\r\n\t\t\t\t\t<option selected=\"selected\">(.*?)</option>\r\n\t\t\t</select></td>");
            matches = regex.Matches(response);
            dic["工作单位位置"] = matches[0].Groups[1].Value + "-" + matches[0].Groups[2].Value;
            // 参加工作日期
            regex = new Regex("<td align=\"center\">参加工作日期</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["参加工作日期"] = matches[0].Groups[1].Value;
            // 通知书邮寄地址
            regex = new Regex("<td align=\"center\">录取通知书邮寄地址</td>\r\n\t\t\t<td colspan=\"3\">(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["通知书邮寄地址"] = matches[0].Groups[1].Value;
            // 邮政编码
            regex = new Regex("<td align=\"center\">邮政编码</td>\r\n\t\t\t<td>(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["邮政编码"] = matches[0].Groups[1].Value;
            // 电话
            regex = new Regex("<td align=\"center\">联系电话</td>\r\n\t\t\t<td>(.*?)</td>");
            matches = regex.Matches(response);
            dic["电话"] = matches[0].Groups[1].Value;
            // 报考类型
            regex = new Regex("<td align=\"center\">报考类型</td>\r\n\t\t\t<td>(.*?)</td>\r\n\t\t\t<td align=\"center\">报考科类</td>\r\n\t\t\t<td>(.*?)</td>");
            matches = regex.Matches(response);
            dic["报考类型"] = matches[0].Groups[1].Value + "-" + matches[0].Groups[2].Value;
            // 户口所在地市
            regex = new Regex("<td align=\"center\">户口（工作或居住）所在市</td>\r\n\t\t\t<td><select disabled=\"disabled\">\r\n\t\t\t\t\t<option selected=\"selected\">(.*?)</option>\r\n\t\t\t</select></td>\r\n\t\t\t<td align=\"center\">户口（工作或居住）所在县（市、区）</td>\r\n\t\t\t<td><select disabled=\"disabled\">\r\n\t\t\t\t\t<option selected=\"selected\">(.*?)</option>\r\n\t\t\t</select></td");
            matches = regex.Matches(response);
            dic["户口所在地市-县(市、区)"] = matches[0].Groups[1].Value + "-" + matches[0].Groups[2].Value;
            // 考生类型
            regex = new Regex("<td align=\"center\" style=\"color: red;\">考生类型:</td>\r\n\t\t\t<td colspan=\"3\">(.*?)</td>\r\n");
            matches = regex.Matches(response);
            dic["考生类型"] = matches[0].Groups[1].Value;
            // 现场审核信息
            regex = new Regex("<tr>\r\n\t\t\t<td align=\"center\">现场审核点</td>\r\n\t\t\t<td>(.*?)</td>\r\n\t\t\t<td align=\"center\">现场审核点联系电话</td>\r\n\t\t\t<td>(.*?)</td>\r\n\t\t</tr>\r\n\t\t<tr>\r\n\t\t\t<td align=\"center\">现场审核点地址</td>\r\n\t\t\t<td colspan=\"3\">(.*?)</td>\r\n\t\t</tr>\r\n");
            matches = regex.Matches(response);
            dic["现场审核信息"] = matches[0].Groups[1].Value + "-" + matches[0].Groups[2].Value + "-" + matches[0].Groups[3].Value;
            // 考试所在市
            regex = new Regex("<td align=\"center\">考试所在市</td>\r\n\t\t\t<td colspan=\"3\"><span style=\"color: blue; font-size: 20px\">(.*?)</span>\r\n\t\t\t</td>\r\n");
            matches = regex.Matches(response);
            dic["考试所在市"] = matches[0].Groups[1].Value;
            // 志愿信息
            // regex = new Regex("<td align=\"center\">专业名称</td>\r\n\t\t</tr>\r\n\t\t \r\n\t\t<tr>(.*?)</tr>\r\n\t\t\r\n\t\t  \r\n\t\t\r\n\t</table>",RegexOptions.Multiline);
            // matches = regex.Matches(response);
            var doc = new HtmlDocument();
            doc.LoadHtml(response);
            var result = doc.DocumentNode.SelectNodes("//table[2]/tr");
            dic["志愿信息"] = "";
            if (result.Count > 1)
            {
                dic["志愿信息"] = string.Join("  |  ", result.Skip(1)
                    .Select(i => i.SelectNodes("td").Select(j => j.InnerText))
                    .Select(i => string.Join("-", i)).ToList());


            }
            // 审核状态
            regex = new Regex("<td align=\"center\">审核状态：</td>\r\n\t<td> \r\n\t <span style=\"font-size: 20px;color: red;\"> (.*?) </span>");
            matches = regex.Matches(response);
            dic["审核状态"] = matches[0].Groups[1].Value;
            // 照片
            regex = new Regex("<td align=\"center\">身份证照片、证件照、手持身份证照片比对是否为同一个人：</td>\r\n\t<td>\r\n\t\r\n\t <span style=\"font-size: 20px;color: green;\">(.*?)</span>\r\n");
            matches = regex.Matches(response);
            dic["三照片是否为同一人"] = matches[0].Groups[1].Value;
            // 录入姓名
            regex = new Regex("<td align=\"center\">录入的姓名与身份证识别到的姓名是否一致：</td>\r\n\t<td>\r\n\t\r\n\t <span style=\"font-size: 20px;color: green;\">(.*?)</span>\r\n");
            matches = regex.Matches(response);
            dic["录入姓名和身份证姓名一致"] = matches[0].Groups[1].Value;
            // 身份证签发
            regex = new Regex("身份证签发机关与所选户口（居住证）所在区县是否一致：</td>\r\n\t<td>\r\n\t\r\n\t <span style=\"font-size: 20px;color: green;\">(.*?)</span>\r\n");
            matches = regex.Matches(response);
            dic["身份证签发机与户口所在区县一致"] = matches[0].Groups[1].Value;
            // 缴费状态
            regex = new Regex("缴费状态：</td>\r\n\t<td>\r\n\t <span style=\"font-size: 20px;color: red;\">(.*?)</span>\r\n");
            matches = regex.Matches(response);
            dic["缴费状态"] = matches[0].Groups[1].Value;


            return dic;
        }
    }
}
