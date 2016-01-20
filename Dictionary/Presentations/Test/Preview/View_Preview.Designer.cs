namespace Dictionary
{
    partial class View_Preview
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridWords = new System.Windows.Forms.DataGridView();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Translate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNext = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.gridWords)).BeginInit();
            this.SuspendLayout();
            // 
            // gridWords
            // 
            this.gridWords.AllowUserToAddRows = false;
            this.gridWords.AllowUserToDeleteRows = false;
            this.gridWords.AllowUserToResizeColumns = false;
            this.gridWords.AllowUserToResizeRows = false;
            this.gridWords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridWords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Source,
            this.Translate});
            this.gridWords.Location = new System.Drawing.Point(3, 43);
            this.gridWords.MultiSelect = false;
            this.gridWords.Name = "gridWords";
            this.gridWords.ReadOnly = true;
            this.gridWords.RowHeadersVisible = false;
            this.gridWords.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.gridWords.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            this.gridWords.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridWords.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Window;
            this.gridWords.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.gridWords.RowTemplate.Height = 30;
            this.gridWords.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridWords.Size = new System.Drawing.Size(712, 577);
            this.gridWords.TabIndex = 0;
            this.gridWords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridWords_CellClick);
            this.gridWords.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridWords_CellPainting);
            // 
            // Source
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Source.DefaultCellStyle = dataGridViewCellStyle1;
            this.Source.HeaderText = "Исходное слово";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Width = 227;
            // 
            // Translate
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Translate.DefaultCellStyle = dataGridViewCellStyle2;
            this.Translate.HeaderText = "Перевод";
            this.Translate.Name = "Translate";
            this.Translate.ReadOnly = true;
            this.Translate.Width = 481;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(557, 627);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(152, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Продолжить >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 3);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(712, 34);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Value = 1000;
            // 
            // View_Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 662);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.gridWords);
            this.MaximumSize = new System.Drawing.Size(726, 689);
            this.MinimumSize = new System.Drawing.Size(726, 689);
            this.Name = "View_Preview";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View_Preview";
            ((System.ComponentModel.ISupportInitialize)(this.gridWords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridWords;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Translate;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}