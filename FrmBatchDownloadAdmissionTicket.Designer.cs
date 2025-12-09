namespace ShanxiAdultEducationBatchQueryScore
{
    partial class FrmBatchDownloadAdmissionTicket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbAccountInfo = new System.Windows.Forms.RichTextBox();
            this.btnSelectSavePath = new Sunny.UI.UIButton();
            this.btnLoginAndDownload = new Sunny.UI.UIButton();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTicketNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // FrmBatchDownloadAdmissionTicket
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmBatchDownloadAdmissionTicket";
            this.Text = "批量下载准考证";
            this.ZoomScaleRect = new System.Drawing.Rectangle(22, 22, 800, 450);
            // 
            // rtbAccountInfo
            // 
            this.rtbAccountInfo.Location = new System.Drawing.Point(24, 60);
            this.rtbAccountInfo.Name = "rtbAccountInfo";
            this.rtbAccountInfo.Size = new System.Drawing.Size(450, 500);
            this.rtbAccountInfo.TabIndex = 0;
            this.rtbAccountInfo.Text = "";
            // 
            // btnSelectSavePath
            // 
            this.btnSelectSavePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectSavePath.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnSelectSavePath.Location = new System.Drawing.Point(24, 20);
            this.btnSelectSavePath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSelectSavePath.Name = "btnSelectSavePath";
            this.btnSelectSavePath.Size = new System.Drawing.Size(180, 35);
            this.btnSelectSavePath.TabIndex = 1;
            this.btnSelectSavePath.Text = "选择保存位置";
            this.btnSelectSavePath.Click += new System.EventHandler(this.btnSelectSavePath_Click);
            // 
            // btnLoginAndDownload
            // 
            this.btnLoginAndDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoginAndDownload.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnLoginAndDownload.Location = new System.Drawing.Point(210, 20);
            this.btnLoginAndDownload.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLoginAndDownload.Name = "btnLoginAndDownload";
            this.btnLoginAndDownload.Size = new System.Drawing.Size(180, 35);
            this.btnLoginAndDownload.TabIndex = 2;
            this.btnLoginAndDownload.Text = "开始登录并下载";
            this.btnLoginAndDownload.Click += new System.EventHandler(this.btnLoginAndDownload_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colUsername,
            this.colPassword,
            this.colTicketNo,
            this.colStatus});
            this.dgvResults.Location = new System.Drawing.Point(490, 20);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowTemplate.Height = 25;
            this.dgvResults.Size = new System.Drawing.Size(486, 540);
            this.dgvResults.TabIndex = 3;
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 50;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;
            // 
            // colUsername
            // 
            this.colUsername.HeaderText = "账号";
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            this.colUsername.Width = 120;
            // 
            // colPassword
            // 
            this.colPassword.HeaderText = "密码";
            this.colPassword.Name = "colPassword";
            this.colPassword.ReadOnly = true;
            this.colPassword.Width = 120;
            // 
            // colTicketNo
            // 
            this.colTicketNo.HeaderText = "准考证号";
            this.colTicketNo.Name = "colTicketNo";
            this.colTicketNo.ReadOnly = true;
            this.colTicketNo.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStatus.HeaderText = "状态";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // Controls
            // 
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnLoginAndDownload);
            this.Controls.Add(this.btnSelectSavePath);
            this.Controls.Add(this.rtbAccountInfo);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbAccountInfo;
        private Sunny.UI.UIButton btnSelectSavePath;
        private Sunny.UI.UIButton btnLoginAndDownload;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTicketNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}
