namespace ShanxiAdultEducationBatchQueryScore
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_to_website = new Sunny.UI.UILinkLabel();
            this.dgv_records = new Sunny.UI.UIDataGridView();
            this.dgv_column_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch_column_account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch_column_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ch_column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_column_course_score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_column_total_score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_column_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_account = new Sunny.UI.UITextBox();
            this.btn_import = new Sunny.UI.UIButton();
            this.btn_export_data = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_records)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_to_website
            // 
            this.lbl_to_website.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(155)))), ((int)(((byte)(40)))));
            this.lbl_to_website.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_to_website.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lbl_to_website.Location = new System.Drawing.Point(1137, 491);
            this.lbl_to_website.Name = "lbl_to_website";
            this.lbl_to_website.Size = new System.Drawing.Size(183, 38);
            this.lbl_to_website.TabIndex = 0;
            this.lbl_to_website.TabStop = true;
            this.lbl_to_website.Text = "点我跳转至招生网";
            this.lbl_to_website.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lbl_to_website.Click += new System.EventHandler(this.lbl_to_website_Click);
            // 
            // dgv_records
            // 
            this.dgv_records.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_records.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_records.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.dgv_records.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_records.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_records.ColumnHeadersHeight = 32;
            this.dgv_records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_column_index,
            this.ch_column_account,
            this.ch_column_number,
            this.ch_column_name,
            this.dgv_column_course_score,
            this.dgv_column_total_score,
            this.dgv_column_status});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_records.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_records.EnableHeadersVisualStyles = false;
            this.dgv_records.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_records.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.dgv_records.Location = new System.Drawing.Point(3, 38);
            this.dgv_records.MultiSelect = false;
            this.dgv_records.Name = "dgv_records";
            this.dgv_records.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_records.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_records.RowHeadersVisible = false;
            this.dgv_records.RowHeadersWidth = 51;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_records.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_records.RowTemplate.Height = 27;
            this.dgv_records.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgv_records.SelectedIndex = -1;
            this.dgv_records.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_records.Size = new System.Drawing.Size(1318, 279);
            this.dgv_records.TabIndex = 1;
            // 
            // dgv_column_index
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_column_index.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_column_index.HeaderText = "序号";
            this.dgv_column_index.MinimumWidth = 6;
            this.dgv_column_index.Name = "dgv_column_index";
            this.dgv_column_index.ReadOnly = true;
            this.dgv_column_index.Width = 125;
            // 
            // ch_column_account
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ch_column_account.DefaultCellStyle = dataGridViewCellStyle4;
            this.ch_column_account.HeaderText = "账户信息";
            this.ch_column_account.MinimumWidth = 6;
            this.ch_column_account.Name = "ch_column_account";
            this.ch_column_account.ReadOnly = true;
            this.ch_column_account.Width = 240;
            // 
            // ch_column_number
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ch_column_number.DefaultCellStyle = dataGridViewCellStyle5;
            this.ch_column_number.HeaderText = "准考证号";
            this.ch_column_number.MinimumWidth = 6;
            this.ch_column_number.Name = "ch_column_number";
            this.ch_column_number.ReadOnly = true;
            this.ch_column_number.Width = 125;
            // 
            // ch_column_name
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ch_column_name.DefaultCellStyle = dataGridViewCellStyle6;
            this.ch_column_name.HeaderText = "考生姓名";
            this.ch_column_name.MinimumWidth = 6;
            this.ch_column_name.Name = "ch_column_name";
            this.ch_column_name.ReadOnly = true;
            this.ch_column_name.Width = 125;
            // 
            // dgv_column_course_score
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_column_course_score.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_column_course_score.HeaderText = "科目成绩";
            this.dgv_column_course_score.MinimumWidth = 6;
            this.dgv_column_course_score.Name = "dgv_column_course_score";
            this.dgv_column_course_score.ReadOnly = true;
            this.dgv_column_course_score.Width = 470;
            // 
            // dgv_column_total_score
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_column_total_score.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_column_total_score.HeaderText = "总分";
            this.dgv_column_total_score.MinimumWidth = 6;
            this.dgv_column_total_score.Name = "dgv_column_total_score";
            this.dgv_column_total_score.ReadOnly = true;
            this.dgv_column_total_score.Width = 125;
            // 
            // dgv_column_status
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_column_status.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_column_status.HeaderText = "状态";
            this.dgv_column_status.MinimumWidth = 6;
            this.dgv_column_status.Name = "dgv_column_status";
            this.dgv_column_status.ReadOnly = true;
            this.dgv_column_status.Width = 290;
            // 
            // tb_account
            // 
            this.tb_account.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_account.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_account.Location = new System.Drawing.Point(4, 325);
            this.tb_account.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tb_account.MinimumSize = new System.Drawing.Size(1, 16);
            this.tb_account.Multiline = true;
            this.tb_account.Name = "tb_account";
            this.tb_account.ShowText = false;
            this.tb_account.Size = new System.Drawing.Size(753, 199);
            this.tb_account.TabIndex = 2;
            this.tb_account.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.tb_account.Watermark = "";
            // 
            // btn_import
            // 
            this.btn_import.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_import.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_import.Location = new System.Drawing.Point(764, 491);
            this.btn_import.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(100, 35);
            this.btn_import.TabIndex = 3;
            this.btn_import.Text = "批量查询";
            this.btn_import.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_export_data
            // 
            this.btn_export_data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_export_data.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_export_data.Location = new System.Drawing.Point(888, 491);
            this.btn_export_data.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_export_data.Name = "btn_export_data";
            this.btn_export_data.Size = new System.Drawing.Size(133, 35);
            this.btn_export_data.TabIndex = 4;
            this.btn_export_data.Text = "导出现有数据";
            this.btn_export_data.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_export_data.Click += new System.EventHandler(this.btn_export_data_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1323, 529);
            this.Controls.Add(this.btn_export_data);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.tb_account);
            this.Controls.Add(this.dgv_records);
            this.Controls.Add(this.lbl_to_website);
            this.Name = "FrmMain";
            this.Text = "山西省成人高校招生成绩批量查询系统";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_records)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILinkLabel lbl_to_website;
        private Sunny.UI.UIDataGridView dgv_records;
        private Sunny.UI.UITextBox tb_account;
        private Sunny.UI.UIButton btn_import;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_column_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch_column_account;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch_column_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn ch_column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_column_course_score;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_column_total_score;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_column_status;
        private Sunny.UI.UIButton btn_export_data;
    }
}

