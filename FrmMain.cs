using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Newtonsoft.Json;
using ShanxiAdultEducationBatchQueryScore.Vo;
using Sunny.UI;

namespace ShanxiAdultEducationBatchQueryScore
{
    public partial class FrmMain : UIForm
    {
        private const string UserAgent =
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36 Edg/111.0.1661.54";
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 预置mock数据
            // AddRecord("1", "1xxxx xxxxx", "10xxxxxxx", "张三", "语文:缺考 | 数学(理):缺考 | 英语:缺考", "缺考", "待处理");
            // 预置查询账号
            tb_account.Text = @"1xxx xxxxx";
        }

        private void AddRecord(string index, string account, string number, string name, string courseScore,
            string totalScore, string status)
        {
            var newRowIndex = dgv_records.Rows.Add();
            dgv_records.Rows[newRowIndex].Cells[0].Value = index;
            dgv_records.Rows[newRowIndex].Cells[1].Value = account;
            dgv_records.Rows[newRowIndex].Cells[2].Value = number;
            dgv_records.Rows[newRowIndex].Cells[3].Value = name;
            dgv_records.Rows[newRowIndex].Cells[4].Value = courseScore;
            dgv_records.Rows[newRowIndex].Cells[5].Value = totalScore;
            dgv_records.Rows[newRowIndex].Cells[6].Value = status;
        }

        /// <summary>
        /// 跳转至官网
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_to_website_Click(object sender, EventArgs e)
        {
            // 自动打开链接
            System.Diagnostics.Process.Start("http://www.sxkszx.cn");
        }

        /// <summary>
        /// 点击批量导入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_import_Click(object sender, EventArgs e)
        {
            var content = tb_account.Text.Trim();
            if (string.IsNullOrEmpty(content))
            {
                ShowErrorTip(@"导入的账号不能为空");
                return;
            }

            var lines = tb_account.Lines;
            foreach (var line in lines)
            {
                var account = Regex.Split(line, @"\s+");
                if (account.Length != 2) continue;
                var score = new Dictionary<string,string>();
                try
                {
                    var cookies = await AccountLogin(account[0], account[1]);
                    score = await QueryScore(cookies);
                    // 语文:缺考 | 数学(理):缺考 | 英语:缺考
                    var stringBuilder = new StringBuilder();
                    foreach (var scoreKey in score.Keys.Where(scoreKey => !scoreKey.Contains("总分") && !scoreKey.Contains("学号") && !scoreKey.Contains("姓名")))
                    {
                        stringBuilder.Append($"{scoreKey}:{score[scoreKey]} |");
                    }
                    AddRecord(dgv_records.Rows.Count + "", string.Join(" ", account), score["学号"], score["姓名"], stringBuilder.ToString().Substring(0, stringBuilder.Length - 1), score["总分"], "已查询");
                }
                catch (Exception exception)
                {
                    var number = score.ContainsKey("学号") ? score["学号"] : "-";
                    var name = score.ContainsKey("姓名") ? score["姓名"] : "-";
                    AddRecord(dgv_records.Rows.Count + "", string.Join(" ", account), number, name, "-", "-", $"异常:{exception.Message}");
                }
            }
        }

        /// <summary>
        /// 账号登录
        /// </summary>
        /// <param name="username">学号</param>
        /// <param name="password">密码</param>
        /// <returns>登录成功的Cookies</returns>
        /// <exception cref="Exception"></exception>
        private static async Task<CookieJar> AccountLogin(string username, string password)
        {
            // 1.获取基础Cookies
            var request = await "https://gkpt.sxkszx.cn/Ck-student-web/"
                .WithCookies(out var cookies)
                .WithHeader("User-Agent", UserAgent)
                .GetAsync();
            var retryCount = 8;
            var body = "";
            while (retryCount > 0)
            {
                // 2.根据上一步的Cookies获取验证码
                var codeBytes = await "https://gkpt.sxkszx.cn/Ck-student-web/code.do"
                    .WithCookies(cookies)
                    .WithHeader("User-Agent", UserAgent)
                    .GetBytesAsync();
                // 3.图形识别接口调用
                var codeRequest = await "http://121.37.181.45:9898/ocr/file".PostMultipartAsync(mp =>
                    mp.AddFile("image", new MemoryStream(codeBytes), "code"));
                var code = await codeRequest.GetStringAsync();

                // 4.提交登录请求
                request = await "https://gkpt.sxkszx.cn/Ck-student-web/login_login".WithCookies(cookies)
                    .WithHeader("Referer", "https://gkpt.sxkszx.cn/Ck-student-web/")
                    .WithHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8")
                    .WithHeader("User-Agent", UserAgent)
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

        private static async Task<Dictionary<string, string>> QueryScore(CookieJar cookies)
        {
            var dic = new Dictionary<string, string>();
            var response = await "https://gkpt.sxkszx.cn/Ck-student-web/stuInfo/scoreSel"
                .WithCookies(cookies)
                .WithHeader("User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36 Edg/111.0.1661.54")
                .GetStringAsync();
            
            if (response.Contains("您是免试生或未现场确认，不参加成人高考考试,无考试成绩"))
            {
                throw new Exception("您是免试生或未现场确认，不参加成人高考考试,无考试成绩");
            }

            // 准考证号：10291552025 姓名：张菁浩</span>
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

        /// <summary>
        /// 以Excel的方式导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_export_data_Click(object sender, EventArgs e)
        {
            //打开文件对话框
            var saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = @"保存文件";
            saveFileDialog1.Filter = @"Excel 文件(*.xls)|*.xls|Excel 文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
            saveFileDialog1.FileName = "学生信息.xls"; //设置默认另存为的名字
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            var txtPath = saveFileDialog1.FileName;
            NPOIHelper.DataTableToExcel(GetDataTableFromDataGridView(dgv_records), txtPath);
            ShowSuccessTip("导出数据成功!");
        }

        /// <summary>
        /// 从dataGridView中获取DataTable对象
        /// </summary>
        /// <param name="dataGridView">dataGridView对象</param>
        /// <returns>dataTable</returns>
        private static DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
        {
            var dataTable = new DataTable();

            // 添加列名
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.HeaderText);
            }

            // 添加行数据
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var dataRow = dataTable.NewRow();
                for (var i = 0; i < dataGridView.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

    }
}
