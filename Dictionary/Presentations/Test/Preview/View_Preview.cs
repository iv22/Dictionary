using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace Dictionary
{
    public partial class View_Preview : Form
    {
        Color SELECT_COLOR = Color.Gold;
        Color TRUE_CHECK_COLOR = Color.PaleGreen;
        Color FALSE_CHECK_COLOR = Color.Red;

        private System.Timers.Timer t = new System.Timers.Timer();
        private double c;
        private System.Timers.ElapsedEventHandler onTimer;

        public void Start(double interval)
        {
            int val;
            c = 1;
            this.progressBar1.Value = this.progressBar1.Maximum;
            this.progressBar1.ForeColor = SystemColors.Highlight;
            int RColor = this.progressBar1.ForeColor.R;
            int GColor = System.Math.Min(255, this.progressBar1.ForeColor.G + 1);
            int BColor = this.progressBar1.ForeColor.B;
            t.Interval = 200;
            t.AutoReset = true;
            
            Func<Color, float, Color> getProgressColor = (curColor, curValuePart) =>
            {
                int R;
                int G;
                int B;

                R = (int)(255-curValuePart*(255-RColor));
                G = (int)(120 - curValuePart * (120 - GColor));
                B = (int)((0.7 + 0.3 * curValuePart) * BColor);

                R = System.Math.Max(System.Math.Min(R, 255), 0);
                G = System.Math.Max(System.Math.Min(G, 255), 0);
                B = System.Math.Max(System.Math.Min(B, 255), 0);
                return Color.FromArgb(R, G, B);
            };

            onTimer = delegate
            {
                if (this.progressBar1.Value > 0)
                {
                    val = this.progressBar1.Maximum - (int)(this.progressBar1.Maximum * (++c) * t.Interval / interval);
                    if (val < 0) val = 0;
                    if (this.progressBar1.InvokeRequired)
                    {
                        this.progressBar1.Invoke(new Action<int>(i => this.progressBar1.Value = i), val);
                        this.progressBar1.Invoke(new Action<Color, float>((foreColor, valuePart) =>
                           this.progressBar1.ForeColor =
                           getProgressColor(foreColor, valuePart)), this.progressBar1.ForeColor, ((float)val / this.progressBar1.Maximum));
                    }
                    else
                    {
                        this.progressBar1.Value = val;
                        this.progressBar1.ForeColor = getProgressColor(this.progressBar1.ForeColor, (float)val / this.progressBar1.Maximum);
                    }
                }
                else
                    this.Stop();
            };
            t.Elapsed += onTimer;
            t.Start();
        }

        public void Stop()
        {
            t.Stop();
            t.Elapsed -= onTimer;
        }

        public string Caption { set { this.Text = value; } }
        public List<Word> TestWords { set { this.ShowWords(value); } }
        public bool CanNext { set { this.btnNext.Enabled = value; } }

        private bool _canCheck;
        public bool CanCheck
        {
            get { return  this._canCheck; }

            set
            {
                this._canCheck = value;
                if (value) 
                    this.gridWords.Cursor = System.Windows.Forms.Cursors.Default;
                else
                    this.gridWords.Cursor = System.Windows.Forms.Cursors.AppStarting;
            }
        }

        private ITestPreviewController controller;

        public View_Preview()
        {
            InitializeComponent();
        }

        public void SetController(ITestPreviewController controller)
        {
            this.controller = controller;
        }

        private int findRowIndexByWord(Word w)
        {
            for (int i = 0; i < gridWords.RowCount; i++ )
            {
                if (w.Equals(new Word(gridWords.Rows[i].Cells["Source"].Value.ToString(), gridWords.Rows[i].Cells["Translate"].Value.ToString())))
                    return i;
            }
            return -1;
        }

        private void clearGridColumns(string column)
        {
            for (int i = 0; i < gridWords.RowCount; i++)
            {
                gridWords.Rows[i].Cells[column].Style.BackColor = Color.White;
                gridWords.Rows[i].Cells[column].Style.SelectionBackColor = Color.White;
            }
        }

        public void MarkSource(Word w)
        {
            this.markWord(w, "Source", SELECT_COLOR);
        }

        public void MarkTranslate(Word w)
        {
            this.markWord(w, "Translate", SELECT_COLOR);
        }

        public void CheckWord(Word wsource, Word wtranslate, bool IsHit)
        {
            this.markWord(wsource, "Source", IsHit ? TRUE_CHECK_COLOR : FALSE_CHECK_COLOR);
            this.markWord(wtranslate, "Translate", IsHit ? TRUE_CHECK_COLOR : FALSE_CHECK_COLOR);
        }

        private void markWord(Word w, string column, Color c)
        {
            clearGridColumns(column);
            int i = this.findRowIndexByWord(w);
            if (i >= 0)
                gridWords.Rows[i].Cells[column].Style.BackColor = c;
        }

        public void RemoveWord(Word wsource)
        {
            int i = this.findRowIndexByWord(wsource);
            if (i >= 0)
                this.gridWords.Rows[i].Cells["Source"].Value = "";
        }

        public void ShuffleWordsTranslate(List<Word> words)
        {
            for (int i = 0; i < words.Count; i++ )
            {
                gridWords.Rows[i].Cells["Translate"].Value = words[i].translate;
            }
        }

        public void Reset()
        {
            clearGridColumns("Source");
            clearGridColumns("Translate");
        }

        private void ShowWords(List<Word> words)
        {
            foreach (Word w in words)
            {
                gridWords.Rows.Add(w.source, w.translate);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void gridWords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Word w;
            DataGridViewCell cell = (sender as DataGridView).CurrentCell;
            
            if ((this._canCheck) && (cell.Value.ToString() != "") && (this.controller != null))
            {
                w = new Word(cell.OwningRow.Cells["Source"].Value.ToString(), cell.OwningRow.Cells["Translate"].Value.ToString());
                if (cell.OwningColumn.Name == "Source")
                    controller.CheckWord(wsource: w);
                else if (cell.OwningColumn.Name == "Translate")
                    controller.CheckWord(wtranslate: w);
            }
        }

        private void gridWords_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(e.CellStyle.BackColor), e.CellBounds);
                //(e.Graphics.colo, e.CellBounds);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(e.CellStyle.ForeColor)), e.CellBounds);
            if (e.Value != null)
                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, e.CellBounds);
            e.Handled = true;
        }
    }
}
