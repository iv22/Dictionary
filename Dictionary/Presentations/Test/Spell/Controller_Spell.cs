using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Dictionary
{
    public class Controller_Spell
    {
        private Model model;
        private View_Spell view;
        private Word currentWord;

        private System.Timers.Timer timer = new System.Timers.Timer();

        public Controller_Spell(Model model, View_Spell view)
        {
            this.model = model;
            this.view = view;
            this.view.SetController(this);
            this.model.CurrentTest.PropertyChanged += PropertyChangedHandler;
            this.model.CurrentTest.CurrentPart.SetTimer(timer);
            this.view.CanCheck = true;
            this.Next();
            this.showView();
        }

        private void showView()
        {
            this.view.Text = "Печать по буквам";
            if (this.view.ShowDialog() == DialogResult.Cancel)
                model.CurrentTest.Cancel();

            this.finish();
        }

        private void finish()
        {
            this.timer.Stop();
            this.model.CurrentTest.PropertyChanged -= PropertyChangedHandler;
        }

        private void PropertyChangedHandler(Object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "State":
                    //view.CanNext = (model.CurrentTest.State == TestStates.Completed);
                    switch (model.CurrentTest.State)
                    {
                        case TestStates.Completed:
                            this.finish();
                            if (view.InvokeRequired)
                                view.Invoke(new Action<bool>(b => view.CanNext = b), true);
                            else
                                view.CanNext = true;
                            break;
                        case TestStates.Expired:
                            this.timer.Stop();
                            if (view.InvokeRequired)
                                view.Invoke(new Action(this.view.Stop));
                            else
                                this.view.Stop();
                            
                            if (!CheckWord(view.TestWord))
                            {
                                this.addToHistory(view.TestWord, false);
                                if (view.InvokeRequired)
                                {
                                    view.Invoke(new Action<bool>(b => view.CanNextWord = b), true);
                                    view.Invoke(new Action<Word>(wrd => view.ShowTrueSource(wrd)), this.currentWord);
                                }
                                else
                                {
                                    view.CanNextWord = true;
                                    view.ShowTrueSource(this.currentWord);
                                }
                            }
                            
                            /*if (view.InvokeRequired)
                            {
                                //view.Invoke(new Action<Word>(wrd => CheckWord(wrd)), view.TestWord);
                                view.Invoke(new Action<bool>(b => view.CanNextWord = b), true);
                            }*/
                            break;
                    }
                    break;
            }
        }

        public void Next()
        {
            //view.CanNextWord = false;
            if (view.InvokeRequired)
                view.Invoke(new Action<bool>(b => view.CanNextWord = b), false);
            else
                view.CanNextWord = false;
            this.timer.Stop();
            if (view.InvokeRequired)
                view.Invoke(new Action(this.view.Stop));
            else
                this.view.Stop();

            this.currentWord = this.model.CurrentTest.CurrentPart.PartWords().FirstOrDefault();
            //if (this.model.CurrentTest.CurrentPart.PartWords().GetEnumerator().MoveNext())
            if(this.currentWord != null)
            {
                //this.currentWord = this.model.CurrentTest.CurrentPart.PartWords().fi
                if (view.InvokeRequired)
                    view.Invoke(new Action<Word>(wrd => view.TestWord = wrd), this.currentWord);
                else
                    view.TestWord = this.currentWord;
                if (view.InvokeRequired)
                    view.Invoke(new Action<double>(i => this.view.Start(i)), this.timer.Interval);
                else
                    this.view.Start(this.timer.Interval);
                this.timer.Start();
            }
        }

        public bool CheckWord(Word w)
        {
            if (!this.currentWord.Equals(w))
            {
                this.model.CurrentTest.CurrentPart.CheckWord(new Word(this.currentWord.source, "&*$"));
                return false;
            }
            else
            {
                this.addToHistory(w, true);
                this.model.CurrentTest.CurrentPart.CheckWord(w);
                this.Next();
                return true;
            }
        }

        private void addToHistory(Word w, bool result)
        {
            if (view.InvokeRequired)
            {
                view.Invoke(new Action<Word, bool>((wrd, b) => view.AddToHistory(wrd, b)), w, result);
            }
            else
                view.AddToHistory(w, result);
        }

        private void reset()
        {
         /*   this.t.Stop();
            if (this.isHit)
                view.RemoveWord(this.selectedSourceWord);
            else
            {
                view.ShuffleWordsTranslate(Test.GetShuffleWords(this._testWords));
            }
            this.selectedSourceWord = null;
            this.selectedTranslateWord = null;
            view.Reset();
            if (view.InvokeRequired)
                view.Invoke(new Action<bool>(b => view.CanCheck = b), true);*/
        }
    }
}
