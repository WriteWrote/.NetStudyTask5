using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        private Assembly currAsm;
        private Type currType;
        private Dictionary<String, MethodInfo> currMethods;
        private Dictionary<String, ParameterInfo> currParams;
        private ITextile currObj;

        public Form1()
        {
            InitializeComponent();
            this.currMethods = new Dictionary<String, MethodInfo>();
            this.currParams = new Dictionary<String, ParameterInfo>();
        }

        /// <summary>
        /// искать классы по названию проекта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            currAsm = Assembly.Load(textBox1.Text.Trim());

            //listBox1.Items.Add(asm.FullName);

            Type[] types = currAsm.GetTypes();
            comboBox1.Items.Clear();
            foreach (Type t in types)
            {
                if (t.IsClass && t.Name.Contains("Costume"))
                    comboBox1.Items.Add(t.Name);
            }

            comboBox1.Refresh();
        }

        /// <summary>
        /// Выполнить метод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null &&
                comboBox3.Items.Count == 0)
            {
                String s = comboBox2.SelectedItem.ToString().Trim();
                String[] ass = s.Split(' ');
                String ss = ass[ass.Length - 1];
                MethodInfo meth = currType.GetMethod(ss);

                //listBox1.Items.Add(currObj.ToString());
                meth.Invoke(currObj, null);
            }
            //SomeType someObject2 = newObj as SomeType;
            /*
            currObj = (ITextile) newObj;
            currObj.Invoke(currMethods[comboBox2.SelectedItem.ToString().Trim()]);
            
            MethodInfo m, mb;
            m = currType.GetMethod(comboBox2.SelectedItem.ToString().Trim());
            mb = m.GetBaseDefinition();
            */
        }

        /// <summary>
        /// выбрать класс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            String s = currAsm.FullName.Split(',')[0].Trim() + "." + comboBox1.SelectedItem.ToString().Trim();
            currType = Type.GetType(s);
            
            object newObj = Activator.CreateInstance(currType);
            currObj = (ITextile) newObj;
            listBox1.Items.Add(currObj.ToString());

            List<String> methods = new List<string>();

            currMethods.Clear();

            foreach (MethodInfo method in currType.GetMethods())
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                methods.Add((modificator + " " + method.ReturnType.Name + " " + method.Name + "\n").Trim());
                currMethods.Add((modificator + " " + method.ReturnType.Name + " " + method.Name).Trim(), method);
            }

            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(methods.ToArray());
            comboBox2.Refresh();
        }

        /// <summary>
        /// заполнить поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                if (comboBox3.Items.Count > 0 && comboBox3.SelectedItem != null)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        String parValue = textBox2.Text.Trim();
                        MethodInfo setMethod = currType.GetMethod(comboBox2.SelectedItem.ToString().Trim().Split(' ')[1]);
                        setMethod.Invoke(currObj, new[] {parValue});
                    }
                }
            }
        }

        /// <summary>
        /// Выбрать метод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MethodInfo method = currMethods[comboBox2.SelectedItem.ToString().Trim()];
            ParameterInfo[] parameters = method.GetParameters();
            comboBox3.Items.Clear();
            currParams.Clear();
            for (int i = 0; i < parameters.Length; i++)
            {
                comboBox3.Items.Add(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                currParams.Add(parameters[i].ParameterType.Name + " " + parameters[i].Name, parameters[i]);
            }

            comboBox3.Refresh();
        }
    }
}