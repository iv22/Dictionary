using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    class Controller_DictionaryEdit: AbstractOperationController
    {
        private View_DictionaryEdit view;
        private MyDictionary dictionary;

        public Controller_DictionaryEdit(Model model, MyDictionary dictionary)
        {
            this.model = model;
            this.dictionary = dictionary;
            view = new View_DictionaryEdit(this, dictionary);
            PrepareView();
            view.ShowDialog();
        }

        private void PrepareView()
        {
            view.SetViewCaption("Редактирование данных словаря");
            view.SetEditingValues();
        }

        public override void ExecOperation() 
        {
            view.UpdateDictionaryFields();
            model.updDictionary(dictionary);
            view.Close();
        }
    }


    class Controller_DictionaryAdd : AbstractOperationController
    {
        private View_DictionaryEdit view;
        private MyDictionary dictionary;

        public Controller_DictionaryAdd(Model model)
        {
            this.model = model;
            this.dictionary = new MyDictionary("");
            view = new View_DictionaryEdit(this, dictionary);
            InitView();
            
            view.ShowDialog();
        }

        public void InitView()
        {
            view.SetViewCaption("Создание нового словаря пользователя");
        }

        public override void ExecOperation()
        {
            view.UpdateDictionaryFields();
            model.addDictionary(dictionary);
            view.Close();
        }
    }

    class Controller_DictionaryDel : AbstractOperationController
    {
        private MyDictionary dictionary;

        public Controller_DictionaryDel(Model model, MyDictionary dictionary)
        {
            this.model = model;
            this.dictionary = dictionary;
            this.ExecOperation();
        }

        public override void ExecOperation()
        {
            if(MessageBox.Show("Вы действительно желаете удалить словарь пользователя?", 
                "Редактирование списка словарей",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                model.delDictionary(dictionary);
        }
    }
}
