using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace ShanxiAdultEducationBatchQueryScore
{
    public partial class FrmBatchDownloadAdmissionTicket : UIForm
    {
        private string _savePath = string.Empty;

        public FrmBatchDownloadAdmissionTicket()
        {
            InitializeComponent();
        }

        private void btnSelectSavePath_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "选择PDF保存目录";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _savePath = dlg.SelectedPath;
                    UIMessageBox.ShowInfo($"保存位置: {_savePath}");
                }
            }
        }

        private async void btnLoginAndDownload_Click(object sender, EventArgs e)
        {
            try
            {
                dgvResults.Rows.Clear();
                if (string.IsNullOrWhiteSpace(_savePath))
                {
                    UIMessageBox.ShowWarning("请先选择保存位置");
                    return;
                }

                var lines = rtbAccountInfo.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
                var parsed = new List<(string username, string password)>();
                int id = 1;
                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 2) continue;
                    var username = parts[0];
                    var password = parts[1];
                    parsed.Add((username, password));
                    dgvResults.Rows.Add(id++, username, password, "", "待处理");
                }

                if (parsed.Count == 0)
                {
                    UIMessageBox.ShowWarning("请输入账号和密码，每行用空格分隔");
                    return;
                }

                // Process each account sequentially to avoid server rate limits
                for (int rowIndex = 0; rowIndex < parsed.Count; rowIndex++)
                {
                    var (username, password) = parsed[rowIndex];
                    dgvResults.Rows[rowIndex].Cells[4].Value = "正在登录...";

                    // try
                    // {
                    //     // var result = await WebService.LoginAndProcessTicketAsync(username, password, _savePath);
                    //     dgvResults.Rows[rowIndex].Cells[3].Value = result.TicketNo ?? "";
                    //     dgvResults.Rows[rowIndex].Cells[4].Value = result.Success ? "下载成功" : ($"失败: {result.ErrorMessage}");
                    // }
                    // catch (Exception ex)
                    // {
                    //     dgvResults.Rows[rowIndex].Cells[4].Value = $"失败: {ex.Message}";
                    // }
                }

                UIMessageBox.ShowSuccess($"处理完成，共 {parsed.Count} 条");
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError($"发生错误: {ex.Message}");
            }
        }
    }
}

