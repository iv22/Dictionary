namespace Dictionary
{
    partial class View_Spell
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
            this.btnNext = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.gboxSpell = new System.Windows.Forms.GroupBox();
            this.lblTrueSource = new System.Windows.Forms.Label();
            this.btnNextWord = new System.Windows.Forms.Button();
            this.txtTypeSource = new System.Windows.Forms.TextBox();
            this.gridHistory = new System.Windows.Forms.DataGridView();
            this.Translate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblTranslate = new System.Windows.Forms.Label();
            this.gboxSpell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(554, 627);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(152, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Продолжить >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.BackColor = System.Drawing.SystemColors.Window;
            this.txtSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSource.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtSource.Location = new System.Drawing.Point(4, 119);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(684, 50);
            this.txtSource.TabIndex = 4;
            this.txtSource.TabStop = false;
            this.txtSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gboxSpell
            // 
            this.gboxSpell.Controls.Add(this.lblTranslate);
            this.gboxSpell.Controls.Add(this.progressBar1);
            this.gboxSpell.Controls.Add(this.lblTrueSource);
            this.gboxSpell.Controls.Add(this.btnNextWord);
            this.gboxSpell.Controls.Add(this.txtTypeSource);
            this.gboxSpell.Controls.Add(this.txtSource);
            this.gboxSpell.Location = new System.Drawing.Point(12, 12);
            this.gboxSpell.Name = "gboxSpell";
            this.gboxSpell.Size = new System.Drawing.Size(694, 208);
            this.gboxSpell.TabIndex = 5;
            this.gboxSpell.TabStop = false;
            this.gboxSpell.Enter += new System.EventHandler(this.gboxSpell_Enter);
            // 
            // lblTrueSource
            // 
            this.lblTrueSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrueSource.BackColor = System.Drawing.SystemColors.Window;
            this.lblTrueSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTrueSource.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTrueSource.Location = new System.Drawing.Point(6, 146);
            this.lblTrueSource.Name = "lblTrueSource";
            this.lblTrueSource.Size = new System.Drawing.Size(678, 23);
            this.lblTrueSource.TabIndex = 7;
            this.lblTrueSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextWord
            // 
            this.btnNextWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextWord.Enabled = false;
            this.btnNextWord.Location = new System.Drawing.Point(576, 175);
            this.btnNextWord.Name = "btnNextWord";
            this.btnNextWord.Size = new System.Drawing.Size(112, 23);
            this.btnNextWord.TabIndex = 6;
            this.btnNextWord.Text = "Следующее слово";
            this.btnNextWord.UseVisualStyleBackColor = true;
            this.btnNextWord.Click += new System.EventHandler(this.btnNextWord_Click);
            // 
            // txtTypeSource
            // 
            this.txtTypeSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTypeSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTypeSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTypeSource.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTypeSource.Location = new System.Drawing.Point(6, 123);
            this.txtTypeSource.MaximumSize = new System.Drawing.Size(678, 22);
            this.txtTypeSource.MinimumSize = new System.Drawing.Size(678, 22);
            this.txtTypeSource.Name = "txtTypeSource";
            this.txtTypeSource.Size = new System.Drawing.Size(678, 22);
            this.txtTypeSource.TabIndex = 5;
            this.txtTypeSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTypeSource.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTypeSource_KeyPress);
            // 
            // gridHistory
            // 
            this.gridHistory.AllowUserToAddRows = false;
            this.gridHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Translate,
            this.Source});
            this.gridHistory.Location = new System.Drawing.Point(12, 226);
            this.gridHistory.MultiSelect = false;
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.Size = new System.Drawing.Size(694, 395);
            this.gridHistory.TabIndex = 7;
            // 
            // Translate
            // 
            this.Translate.HeaderText = "Перевод";
            this.Translate.Name = "Translate";
            this.Translate.ReadOnly = true;
            this.Translate.Width = 488;
            // 
            // Source
            // 
            this.Source.HeaderText = "Исходное слово";
            this.Source.Name = "Source";
            this.Source.ReadOnly = true;
            this.Source.Width = 140;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 10);
            this.progressBar1.Maximum = 200;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(682, 34);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Value = 200;
            // 
            // lblTranslate
            // 
            this.lblTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTranslate.Location = new System.Drawing.Point(6, 47);
            this.lblTranslate.Name = "lblTranslate";
            this.lblTranslate.Size = new System.Drawing.Size(682, 64);
            this.lblTranslate.TabIndex = 9;
            this.lblTranslate.Text = "L";
            this.lblTranslate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // View_Spell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 662);
            this.Controls.Add(this.gridHistory);
            this.Controls.Add(this.gboxSpell);
            this.Controls.Add(this.btnNext);
            this.MaximumSize = new System.Drawing.Size(726, 689);
            this.MinimumSize = new System.Drawing.Size(726, 689);
            this.Name = "View_Spell";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View_Spell";
            this.gboxSpell.ResumeLayout(false);
            this.gboxSpell.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.GroupBox gboxSpell;
        private System.Windows.Forms.TextBox txtTypeSource;
        private System.Windows.Forms.Label lblTrueSource;
        private System.Windows.Forms.Button btnNextWord;
        private System.Windows.Forms.DataGridView gridHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Translate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.Label lblTranslate;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}