using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public class Controller_DictionaryWord
    {
        private Model model;
        private View view;

        private IDictionaryState notFoundWordState;
        private IDictionaryState foundWordState;
        private IDictionaryState editWordState;
        private IDictionaryState _DictionaryState;
        private IDictionaryState DictionaryState { 
            get { return _DictionaryState; }
            set { _DictionaryState = value; DictionaryState.init(); }
        }

        private Word selectedWord;
        
        public Controller_DictionaryWord(Model model, View view)
        {
            this.model = model;
            this.view = view;
        }

        public List<Word> getDictionaryWords()
        {
            if (model.CurrentDictionary != null)
                return model.CurrentDictionary.wordList;
            else
                return null;
        }

        public void DictionaryEnter()
        {
            view.fill_DictionaryGrid(getDictionaryWords());
            view.CanAddDictionaryWord = false;
            view.CanUpdDictionaryWord = false;
            view.CanDelDictionaryWord = false;
            view.CanEditCurrentWord = false;
            view.CanCancelEditWord = false;
            view.CanEditDictionaryView = (model.CurrentDictionary != null);
            if (model.CurrentDictionary != null)
            {
                notFoundWordState = new NotFoundWordState(this);
                foundWordState = new FoundWordState(this);
                editWordState = new EditWordState(this);
                DictionaryState = notFoundWordState;
                DictionaryState.SelectedWordChanged(view.source);
            }
        }

        private void updateViewCurrentWord(Word w)
        {
            view.source = w.source;
            view.translate = w.translate;
            view.test_count = w.test_count;
            view.attempts = w.attempts;
            view.knowing = w.knowing;
        }

        private void updateWordFromView(Word w)
        {
            w.source = view.source;
            w.translate = view.translate;
            w.test_count = view.test_count;
            w.attempts = view.attempts;
            w.knowing = view.knowing;
        }

        public string GetNearestDictionaryWord(string source)
        {
            Word w;
            if (source.Length < 1)
                return "";
            else
            {
                w = model.CurrentDictionary.wordList.Find(
                    x => string.Compare(x.source.Trim(), 0, source.Trim(), 0, source.Length, true) == 0);
                if (w != null)
                    return w.source;
                else
                    return (GetNearestDictionaryWord(source.Substring(0, source.Length - 1))); 
            }
        }

        public void SelectedWordChanged(string source)
        {
            DictionaryState.SelectedWordChanged(source);
        }
        // Desin pattern State for dictionary states
        class NotFoundWordState : IDictionaryState
        {
            Controller_DictionaryWord controller;
            public NotFoundWordState(Controller_DictionaryWord controller) 
            { 
                this.controller = controller; 
            }

            public void init() 
            {
                controller.view.CurrentWordOperTitle = "Поиск слова: нет совпадений";
                controller.view.CanAddDictionaryWord = ((controller.selectedWord != null) && 
                    (controller.selectedWord.source != "")); //(source != "");
                controller.view.CanUpdDictionaryWord = false;
                controller.view.CanDelDictionaryWord = false;
                controller.view.CanEditCurrentWord = false;
                controller.view.CanCancelEditWord = false;
                controller.view.CanEditWordTranslate = true;

                controller.selectedWord = controller.selectedWord == null ? new Word("", "") : controller.selectedWord;
                controller.updateWordFromView(controller.selectedWord);
                controller.selectedWord.translate = "";
                controller.updateViewCurrentWord(controller.selectedWord);
                controller.view.TrySetWordPosition(
                    controller.GetNearestDictionaryWord(controller.selectedWord.source), true);
            }

            public void SelectedWordChanged(string source) 
            {
                Word w = controller.model.CurrentDictionary.FindWordBySource(source);
                if (w == null)
                {
                    controller.updateWordFromView(controller.selectedWord);
                    controller.view.TrySetWordPosition(
                        controller.GetNearestDictionaryWord(controller.selectedWord.source));
                    controller.view.CanAddDictionaryWord = ((controller.selectedWord != null) &&
                        (controller.selectedWord.source != "")); //(source != "")
                }
                else
                {
                    w.CopyTo(controller.selectedWord);
                    controller.DictionaryState = controller.foundWordState;
                }                    
            }
         
            public void insertWord() 
            {
                try
                {
                    //---get translate from view---//
                    controller.updateWordFromView(controller.selectedWord);
                    controller.model.addWord(controller.selectedWord);
                    //controller.view.fill_DictionaryGrid(controller.getDictionaryWords());
                    controller.view.fill_DictionaryGrid(controller.model.CurrentDictionary.wordList);
                    controller.view.DictionaryWordsCount = controller.model.CurrentDictionary.wordList.Count;
                    controller.DictionaryState = controller.foundWordState;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка при добавлении: " + e.Message);
                }
            }

            public void updateWord() { }
            public void deleteWord() { }
            public void startEditWord() { }
            public void cancelEditWord() { }
        }

        private class FoundWordState : IDictionaryState
        {
            Controller_DictionaryWord controller;
            public FoundWordState(Controller_DictionaryWord controller)
            {
                this.controller = controller;
            }

            public void init() 
            {
                controller.view.CurrentWordOperTitle = "Слово присутствует в словаре";
                controller.view.CanAddDictionaryWord = false;
                controller.view.CanUpdDictionaryWord = false;
                controller.view.CanDelDictionaryWord = true;
                controller.view.CanEditCurrentWord = true;
                controller.view.CanCancelEditWord = false;
                controller.view.CanEditWordTranslate = false;

                controller.updateViewCurrentWord(controller.selectedWord);
                controller.view.TrySetWordPosition(
                    controller.GetNearestDictionaryWord(controller.selectedWord.source), true);
            }

            public void SelectedWordChanged(string source) 
            {
                Word w = controller.model.CurrentDictionary.FindWordBySource(source);
                if (w != null)
                {
                    w.CopyTo(controller.selectedWord);
                    controller.updateViewCurrentWord(controller.selectedWord);
                    controller.view.TrySetWordPosition(
                        controller.GetNearestDictionaryWord(controller.selectedWord.source), true);
                }
                else
                {
                    controller.DictionaryState = controller.notFoundWordState;
                }   
            }

            public void insertWord() { }
            public void updateWord() { }
            
            public void deleteWord() 
            {
                try
                {
                    //controller.updateWordFromView(controller.selectedWord);
                    controller.model.delWord(controller.selectedWord);
                    //controller.view.fill_DictionaryGrid(controller.getDictionaryWords());
                    controller.view.fill_DictionaryGrid(controller.model.CurrentDictionary.wordList);
                    controller.view.DictionaryWordsCount = controller.model.CurrentDictionary.wordList.Count;
                    controller.view.source = "";
                    controller.DictionaryState = controller.notFoundWordState;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка при удалении: " + e.Message);
                }
            }
            
            public void startEditWord() 
            {
                controller.DictionaryState = controller.editWordState;
            }
            public void cancelEditWord() { }
        }

        private class EditWordState : IDictionaryState
        {
            Controller_DictionaryWord controller;
            Word editingWord = new Word("", "");

            public EditWordState(Controller_DictionaryWord controller)
            {
                this.controller = controller;
            }

            public void init() 
            {
                controller.view.CurrentWordOperTitle = "Редактирование слова";
                controller.view.CanAddDictionaryWord = false;
                controller.view.CanUpdDictionaryWord = true;
                controller.view.CanDelDictionaryWord = true;
                controller.view.CanEditCurrentWord = false;
                controller.view.CanCancelEditWord = true;
                controller.view.CanEditWordTranslate = true;
            }

            public void SelectedWordChanged(string source) { }
            public void insertWord() { }
            
            public void updateWord() 
            {
                try
                {
                    controller.updateWordFromView(editingWord);
                    controller.model.updWord(controller.selectedWord, editingWord);
                    controller.updateWordFromView(controller.selectedWord);
                    controller.view.fill_DictionaryGrid(controller.model.CurrentDictionary.wordList);
                    controller.DictionaryState = controller.foundWordState;
                }
                catch (Exception e)
                {
                    //return;
                }
            }

            public void deleteWord() 
            {
                try
                {
                    //controller.updateWordFromView(controller.selectedWord);
                    controller.model.delWord(controller.selectedWord);
                    //controller.view.fill_DictionaryGrid(controller.getDictionaryWords());
                    controller.view.fill_DictionaryGrid(controller.model.CurrentDictionary.wordList);
                    controller.view.source = "";
                    controller.DictionaryState = controller.notFoundWordState;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка при удалении: " + e.Message);
                }
            }

            public void startEditWord() { }
            
            public void cancelEditWord() 
            {
                controller.updateViewCurrentWord(controller.selectedWord);
                controller.DictionaryState = controller.foundWordState;
            }
        }
        // End Desin pattern State for dictionary states

        public void SaveWord(Word w)
        {
            model.addWord(w);
        }

        public void AddDictionaryWord()
        {
            DictionaryState.insertWord();
        }

        public void DelDictionaryWord()
        {
            DictionaryState.deleteWord();
        }

        public void EditDictionaryWord()
        {
            DictionaryState.startEditWord();
        }

        public void CancelEditDictionaryWord()
        {
            DictionaryState.cancelEditWord();
        }

        public void UpdateDictionaryWord()
        {
            DictionaryState.updateWord();
        }
    }

    internal interface IDictionaryState
    {
        void init();
        void SelectedWordChanged(string source);
        void insertWord();
        void updateWord();
        void deleteWord();
        void startEditWord();
        void cancelEditWord();
    }
}
