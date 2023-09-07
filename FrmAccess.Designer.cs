namespace ShanxiAdultEducationBatchQueryScore
{
    partial class FrmAccess
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
            this.label1 = new System.Windows.Forms.Label();
            this.CmbForm = new Sunny.UI.UIComboBox();
            this.BtnAccess = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "窗口:";
            // 
            // CmbForm
            // 
            this.CmbForm.DataSource = null;
            this.CmbForm.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.CmbForm.FillColor = System.Drawing.Color.White;
            this.CmbForm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmbForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CmbForm.Items.AddRange(new object[] {
            "查分数",
            "查个人信息"});
            this.CmbForm.Location = new System.Drawing.Point(89, 67);
            this.CmbForm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CmbForm.MinimumSize = new System.Drawing.Size(63, 0);
            this.CmbForm.Name = "CmbForm";
            this.CmbForm.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.CmbForm.Size = new System.Drawing.Size(557, 29);
            this.CmbForm.TabIndex = 1;
            this.CmbForm.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.CmbForm.Watermark = "";
            // 
            // BtnAccess
            // 
            this.BtnAccess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAccess.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAccess.Location = new System.Drawing.Point(674, 67);
            this.BtnAccess.MinimumSize = new System.Drawing.Size(1, 1);
            this.BtnAccess.Name = "BtnAccess";
            this.BtnAccess.Size = new System.Drawing.Size(100, 35);
            this.BtnAccess.TabIndex = 2;
            this.BtnAccess.Text = "进入";
            this.BtnAccess.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnAccess.Click += new System.EventHandler(this.BtnAccess_Click);
            // 
            // FrmAccess
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 134);
            this.Controls.Add(this.BtnAccess);
            this.Controls.Add(this.CmbForm);
            this.Controls.Add(this.label1);
            this.Name = "FrmAccess";
            this.Text = "FrmAccess";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIComboBox CmbForm;
        private Sunny.UI.UIButton BtnAccess;
    }
}