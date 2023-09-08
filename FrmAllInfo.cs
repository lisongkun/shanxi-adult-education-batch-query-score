using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sunny.UI;

namespace ShanxiAdultEducationBatchQueryScore
{
    public partial class FrmAllInfo : UIForm
    {
        public FrmAllInfo()
        {
            InitializeComponent();
        }

        private void FrmAllInfo_Load(object sender, EventArgs e)
        {
            tb_account.Text = $"142601198906107639 aaa111111{Environment.NewLine}";
        }

        /// <summary>
        /// 跳转至官网
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_to_website_Click(object sender, EventArgs e)
        {
            // 自动打开链接
            System.Diagnostics.Process.Start("https://xysp.sxkszx.cn/Ck-student-web/#");
        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            var content = tb_account.Text.Trim();
            if (string.IsNullOrEmpty(content))
            {
                ShowErrorTip(@"导入的账号不能为空");
                return;
            }
            dgv_records.Rows.Clear();
            var lines = tb_account.Lines;
            foreach (var line in lines)
            {
                var account = Regex.Split(line, @"\s+");
                if (account.Length != 2) continue;
                Dictionary<string, string> info;
                try
                {
                    var cookies = await WebService.AccountLogin(account[0], account[1]);
                    info = await WebService.GetAllInfo(cookies);
                    var newRowIndex = dgv_records.Rows.Add();
                    dgv_records.Rows[newRowIndex].Cells[0].Value = newRowIndex + "";
                    dgv_records.Rows[newRowIndex].Cells[1].Value = string.Join(" ", account);
                    foreach (var item in info)
                    {
                        foreach (DataGridViewCell cell in dgv_records.Rows[newRowIndex].Cells)
                        {
                            if (cell.OwningColumn.HeaderText == item.Key) cell.Value = item.Value.Trim();
                        }
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

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
