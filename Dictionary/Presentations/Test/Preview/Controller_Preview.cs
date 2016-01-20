using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Dictionary
{
    public interface ITestPreviewController
    {
        void CheckWord(Word wsource=null, Word wtranslate=null);
    }

    class Controller_Preview : ITestPreviewController
    {
        private Model model;
        private View_Preview view;
        
        public Controller_Preview(Model model, View_Preview view)
        {
            this.model = model;
            this.view = view;
            this.model.CurrentTest.PropertyChanged += PropertyChangedHandler;
            this.view.TestWords = this.model.CurrentTest.CurrentPart.PartWords().ToList();
            this.showView();        
        }

        private void showView()
        {
            this.view.Text = "Предварительный просмотр";
            if (this.view.ShowDialog() == DialogResult.Cancel)
                model.CurrentTest.Cancel();
        }

        private void PropertyChangedHandler(Object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "State":
                    view.CanNext = (model.CurrentTest.State == TestStates.Completed);
                    break;
            }
        }

        public void CheckWord(Word wsource, Word wtranslate) { }
    }
}
