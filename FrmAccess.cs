using Sunny.UI;

namespace ShanxiAdultEducationBatchQueryScore
{
    public partial class FrmAccess : UIForm
    {
        public FrmAccess()
        {
            InitializeComponent();
        }

        #region Control Event

        /// <summary>
        /// 点击进入窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAccess_Click(object sender, System.EventArgs e)
        {
            switch (CmbForm.SelectedIndex)
            {
                case 0:
                    var frmMain = new FrmMain();
                    frmMain.ShowDialog();
                    Hide();
                    frmMain.FormClosed += (o, args) => Close();
                    break;
                case 1:
                    var frmAllInfo = new FrmAllInfo();
                    frmAllInfo.ShowDialog();
                    Hide();
                    frmAllInfo.FormClosed += (o, args) => Close();
                    break;
                default:
                    ShowErrorTip("请选择要进入的窗口!");
                    break;
            }
        }

        #endregion
    }
}
