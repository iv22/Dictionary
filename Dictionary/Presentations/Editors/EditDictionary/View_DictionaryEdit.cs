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
    public partial class View_DictionaryEdit : Form
    {
        private AbstractOperationController controller;
        private MyDictionary dictionary;

        public View_DictionaryEdit(AbstractOperationController controller, MyDictionary dictionary)
        {
            this.controller = controller;
            this.dictionary = dictionary;
            InitializeComponent();
        }

        public void SetViewCaption(string caption)
        {
            this.Text = caption;
        }

        public void SetEditingValues()
        {
            tbDictionary.Text = dictionary.name;
        }

        public void UpdateDictionaryFields()
        {
            dictionary.name = tbDictionary.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            controller.ExecOperation();
        }

    }
}
