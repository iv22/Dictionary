using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Dictionary
{
    class Controller_Couple: ITestPreviewController
    {
        private Model model;
        private View_Preview view;
        private List<Word> _testWords;

        private Word selectedSourceWord;
        private Word selectedTranslateWord;
        private bool isHit = false;
        private System.Timers.Timer t = new System.Timers.Timer(700);
        private System.Timers.Timer timer = new System.Timers.Timer();

        public Controller_Couple(Model model, View_Preview view)
        {
            this.model = model;
            this.view = view;
            this.view.SetController(this);
            this.model.CurrentTest.PropertyChanged += PropertyChangedHandler;
            this.model.CurrentTest.CurrentPart.SetTimer(timer);
            this._testWords = this.model.CurrentTest.CurrentPart.PartWords().ToList();
            this.view.TestWords = getMixedWords(_testWords);
            this.t.Elapsed += delegate { this.reset(); };
            this.view.CanCheck = true;
            this.showView();
        }

        private void showView()
        {
            this.view.Text = "Поиск пары: \"слово/перевод\"";
            this.view.Start(this.timer.Interval);
            this.timer.Start();
            if (this.view.ShowDialog() == DialogResult.Cancel)
                model.CurrentTest.Cancel();

            this.finish();
        }

        private void finish()
        {
            this.timer.Stop();
            this.view.Stop();
            this.model.CurrentTest.PropertyChanged -= PropertyChangedHandler;
        }

        private void PropertyChangedHandler(Object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "State":
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
                            this.finish();
                            MessageBox.Show("Вы не вложились в отведенное время, запустите тест повторно");
                            model.CurrentTest.Cancel();
                            break;
                    }
                    break;
            }
        }

        private List<Word> getMixedWords(List<Word> words)
        {
            int scounter = 0;
            int tcounter = 0;
            List<Word> trans_words = Test.GetShuffleWords(new List<Word>(words));
           
            List<Word> mix = (from wsrc in words
                              join wtrans in trans_words
                              on (++scounter) equals (++tcounter)
                              select new Word(wsrc.source, wtrans.translate)).ToList();
            return mix;
         }

        public void CheckWord(Word wsource, Word wtranslate)
        {
            if ((this.selectedSourceWord != null) && (this.selectedTranslateWord != null))
                this.reset();

            if (wsource!=null) this.selectedSourceWord = wsource;
            if (wtranslate != null) this.selectedTranslateWord = wtranslate;

            if ((this.selectedSourceWord != null) && (this.selectedTranslateWord != null))
            {
                this.isHit = this.model.CurrentTest.CurrentPart.CheckWord(new Word(this.selectedSourceWord.source, this.selectedTranslateWord.translate));
                view.CheckWord(this.selectedSourceWord, this.selectedTranslateWord, this.isHit);
                view.CanCheck = false;
                this.t.Start();
            }
            else if (this.selectedSourceWord != null)
                view.MarkSource(this.selectedSourceWord);
            else if (this.selectedTranslateWord != null)
                view.MarkTranslate(this.selectedTranslateWord);
        }

        private void reset()
        {
            this.t.Stop();
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
                view.Invoke(new Action<bool>(b=>view.CanCheck=b),true);
        }
    }
}
