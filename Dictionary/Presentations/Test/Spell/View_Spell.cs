using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class View_Spell : Form
    {
        private System.Timers.Timer t = new System.Timers.Timer();
        private double c;
        private System.Timers.ElapsedEventHandler onTimer;

        public void Start(double interval)
        {
            int val;
            c = 1;
            this.progressBar1.Value = this.progressBar1.Maximum;
            this.progressBar1.ForeColor = SystemColors.Highlight;
            //this.lblTranslate.ForeColor = this.progressBar1.ForeColor;
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

                    R = (int)(255 - curValuePart * (255 - RColor));
                    G = (int)(120 - curValuePart * (120 - GColor));
                    B = (int)((0.7 + 0.3 * curValuePart) * BColor);

                    R = System.Math.Max(System.Math.Min(R, 255),0);
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
                        //this.progressBar1.Invoke(new Action<Color>(foreColor =>
                            //this.lblTranslate.ForeColor = foreColor), this.progressBar1.ForeColor);
                    }
                    else
                    {
                        this.progressBar1.Value = val;
                        //this.progressBar1.ForeColor = getProgressColor(this.progressBar1.ForeColor, (float)val / this.progressBar1.Maximum);
                        //this.lblTranslate.ForeColor = this.progressBar1.ForeColor;
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


        public Word TestWord
        {
            get { return new Word(this.txtTypeSource.Text, this.lblTranslate.Text); }
            set
            {
                this.lblTranslate.Text = value.translate;
                this.txtTypeSource.Text = "";
                this.txtTypeSource.ReadOnly = false;
                this.txtTypeSource.Focus();
                this.lblTrueSource.Text = "";
                this.txtTypeSource.ForeColor = SystemColors.MenuHighlight;
                this.txtTypeSource.Font = new Font(System.Drawing.FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            }
        }
        
        public bool CanNext { 
            set 
            { 
                this.btnNext.Enabled = value;
                this.txtTypeSource.Enabled = !value;
            } 
        }

        public bool CanNextWord
        {
            set
            {
                this.btnNextWord.Enabled = value;
                if (value)
                {
                    this.btnNextWord.Focus();
                }
            }
        }

        private Controller_Spell controller;

        private bool _canCheck;
        public bool CanCheck
        {
            get { return this._canCheck; }

            set
            {
                this._canCheck = value;
                /*if (value)
                    this.gridWords.Cursor = System.Windows.Forms.Cursors.Default;
                else
                    this.gridWords.Cursor = System.Windows.Forms.Cursors.AppStarting;*/
            }
        }

        public View_Spell()
        {
            InitializeComponent();
        }

        public void SetController(Controller_Spell controller)
        {
            this.controller = controller;
        }

        public void ShowTrueSource(Word w)
        {
            Font font;
            this.lblTrueSource.Text = w.source;
            this.txtTypeSource.ReadOnly = true;
            this.txtTypeSource.BackColor = System.Drawing.SystemColors.Window;
            this.txtTypeSource.ForeColor = Color.Red;
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 10, this.txtTypeSource.Font.Style | FontStyle.Strikeout);
            this.txtTypeSource.Font = font;
        }

        public void AddToHistory(Word w, bool result)
        {
            Color c;
            if (result)
                c = Color.Green;
            else
                c = Color.Red;

            gridHistory.Rows.Insert(0, w.translate, w.source);
            //gridHistory.Rows[0].Cells[0].Style.BackColor = c;
            gridHistory.Rows[0].Cells[0].Style.ForeColor = c;
            gridHistory.Rows[0].Cells[1].Style.ForeColor = c;
        }

        private void txtTypeSource_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                controller.CheckWord(TestWord);
        }

        private void btnNextWord_Click(object sender, EventArgs e)
        {
            controller.Next();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void gboxSpell_Enter(object sender, EventArgs e)
        {

        }


        /*
         using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap animatedImage;
        bool currentlyAnimating = false;
        public Form1()
        {
            InitializeComponent();

            animatedImage = new Bitmap("C:\\test.gif");

        }

        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                //Begin the animation only once. 
                ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = true;
            }
        }
        private void OnFrameChanged(object o, EventArgs e)
        {
            //Force a call to the Paint event handler. 
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //Begin the animation. 
            AnimateImage();
            //Get the next frame ready for rendering. 
            ImageAnimator.UpdateFrames();
            //Draw the next frame in the animation. 
            e.Graphics.DrawImage(this.animatedImage, new Point(100, 100));
        }

        private void buttonStopPlay_Click(object sender, EventArgs e)
        {
            if (currentlyAnimating)
            {
                ImageAnimator.StopAnimate(animatedImage, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = false;
            }
            else
            {
                AnimateImage();
            }
        }
    }
}
         */
    }
}
