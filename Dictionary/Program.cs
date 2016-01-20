using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dictionary
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Model model = new Model();
            View view = new View(model);
            Controller_View controller = new Controller_View(model, view);
            //view.SetController(controller);
            //View view = new View(controller);
            //Application.Run(view);
        }
    }
}
