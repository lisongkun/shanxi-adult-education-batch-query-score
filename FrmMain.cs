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
                var score = new Dictionary<string, string>();
                try
                {
                    var cookies = await WebService.AccountLogin(account[0], account[1]);
                    score = await WebService.QueryScore(cookies);
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
                    var number = score.TryGetValue("学号", out var value) ? value : "-";
                    var name = score.TryGetValue("姓名", out var value1) ? value1 : "-";
                    AddRecord(dgv_records.Rows.Count + "", string.Join(" ", account), number, name, "-", "-", $"异常:{exception.Message}");
                }
            }
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
            NPOIHelper.DataTableToExcel(DataTableUtil.GetDataTableFromDataGridView(dgv_records), txtPath);
            ShowSuccessTip("导出数据成功!");
        }


    }
}
