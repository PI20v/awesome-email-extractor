using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeEmailExtractor
{
    public class FormManager : ApplicationContext
    {
        private void onFormClosed(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                if (((Form)sender).Name == currentForm)
                    ExitThread();
            }
        }
        
        public T CreateForm<T>() where T : Form, new()
        {
            var ret = new T();
            ret.FormClosed += onFormClosed;
            return ret;
        }

        public void Navigate(Form from, Form to)
        {
            currentForm = to.Name;
            from.Close();
            to.Show();
        }

        public string currentForm = "AuthorizationForm";

        private static Lazy<FormManager> _current = new Lazy<FormManager>();
        public static FormManager Current => _current.Value;

        public FormManager()
        {
            var authorization = CreateForm<AuthorizationForm>();
            authorization.Show();
        }        
    }
}
