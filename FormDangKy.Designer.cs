namespace Baitaplon
{
    partial class FormDangKy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            this.quaylai = new System.Windows.Forms.Button();
            this.dangky = new System.Windows.Forms.Button();
            this.chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.malhp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sltoida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sldangky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slconlai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lichhoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chon,
            this.loai,
            this.malhp,
            this.sltoida,
            this.sldangky,
            this.slconlai,
            this.gv,
            this.lichhoc,
            this.ghichu});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(59, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(975, 312);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lbl
            // 
            this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(56, 23);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(0, 16);
            this.lbl.TabIndex = 3;
            // 
            // quaylai
            // 
            this.quaylai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.quaylai.Location = new System.Drawing.Point(929, 409);
            this.quaylai.Name = "quaylai";
            this.quaylai.Size = new System.Drawing.Size(105, 45);
            this.quaylai.TabIndex = 4;
            this.quaylai.Text = "Quay lại";
            this.quaylai.UseVisualStyleBackColor = true;
            this.quaylai.Click += new System.EventHandler(this.quaylai_Click);
            // 
            // dangky
            // 
            this.dangky.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dangky.Location = new System.Drawing.Point(798, 409);
            this.dangky.Name = "dangky";
            this.dangky.Size = new System.Drawing.Size(110, 45);
            this.dangky.TabIndex = 5;
            this.dangky.Text = "Đăng ký";
            this.dangky.UseVisualStyleBackColor = true;
            this.dangky.Click += new System.EventHandler(this.dangky_Click);
            // 
            // chon
            // 
            this.chon.DataPropertyName = "chon";
            this.chon.FillWeight = 60F;
            this.chon.HeaderText = "Chọn";
            this.chon.MinimumWidth = 6;
            this.chon.Name = "chon";
            this.chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // loai
            // 
            this.loai.DataPropertyName = "loai";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.loai.DefaultCellStyle = dataGridViewCellStyle7;
            this.loai.FillWeight = 75F;
            this.loai.HeaderText = "Loại";
            this.loai.MinimumWidth = 6;
            this.loai.Name = "loai";
            // 
            // malhp
            // 
            this.malhp.DataPropertyName = "malhp";
            this.malhp.HeaderText = "Mã LHP";
            this.malhp.MinimumWidth = 6;
            this.malhp.Name = "malhp";
            // 
            // sltoida
            // 
            this.sltoida.DataPropertyName = "sltoida";
            this.sltoida.FillWeight = 60F;
            this.sltoida.HeaderText = "SL tối đa";
            this.sltoida.MinimumWidth = 6;
            this.sltoida.Name = "sltoida";
            // 
            // sldangky
            // 
            this.sldangky.DataPropertyName = "sldangky";
            this.sldangky.FillWeight = 60F;
            this.sldangky.HeaderText = "SL đăng ký";
            this.sldangky.MinimumWidth = 6;
            this.sldangky.Name = "sldangky";
            // 
            // slconlai
            // 
            this.slconlai.DataPropertyName = "slconlai";
            this.slconlai.FillWeight = 60F;
            this.slconlai.HeaderText = "SL còn lại";
            this.slconlai.MinimumWidth = 6;
            this.slconlai.Name = "slconlai";
            // 
            // gv
            // 
            this.gv.DataPropertyName = "gv";
            this.gv.HeaderText = "GV";
            this.gv.MinimumWidth = 6;
            this.gv.Name = "gv";
            // 
            // lichhoc
            // 
            this.lichhoc.DataPropertyName = "lichhoc";
            this.lichhoc.FillWeight = 250F;
            this.lichhoc.HeaderText = "Lịch học";
            this.lichhoc.MinimumWidth = 6;
            this.lichhoc.Name = "lichhoc";
            // 
            // ghichu
            // 
            this.ghichu.DataPropertyName = "ghichu";
            this.ghichu.FillWeight = 82.41978F;
            this.ghichu.HeaderText = "Ghi chú";
            this.ghichu.MinimumWidth = 6;
            this.ghichu.Name = "ghichu";
            // 
            // FormDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.dangky);
            this.Controls.Add(this.quaylai);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDangKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDangKy";
            this.Load += new System.EventHandler(this.FormDangKy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button quaylai;
        private System.Windows.Forms.Button dangky;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn malhp;
        private System.Windows.Forms.DataGridViewTextBoxColumn sltoida;
        private System.Windows.Forms.DataGridViewTextBoxColumn sldangky;
        private System.Windows.Forms.DataGridViewTextBoxColumn slconlai;
        private System.Windows.Forms.DataGridViewTextBoxColumn gv;
        private System.Windows.Forms.DataGridViewTextBoxColumn lichhoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghichu;
    }
}