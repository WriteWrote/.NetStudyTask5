using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        private Type currType;
        private Dictionary<String, MethodInfo> currMethods;
        private Dictionary<String, ParameterInfo> currParams;

        public Form1()
        {
            InitializeComponent();
            this.currMethods = new Dictionary<String, MethodInfo>();
            this.currParams = new Dictionary<String, ParameterInfo>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: искать классы и загружать их в к-б бокс
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TODO: выполнять методы
            throw new System.NotImplementedException();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // TODO: при выборе класса подгружать методы и поля в к-б бокс
            Type myType = Type.GetType("Task5.CosplayCostume", false, true);
            currType = myType;
            List<String> methods = new List<string>();
            
            foreach (MethodInfo method in myType.GetMethods())
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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            throw new System.NotImplementedException();
            // TODO: если к-б-ы не пусты, нажат энтер, то заполнить поле класса
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MethodInfo method = currMethods[comboBox2.SelectedItem.ToString().Trim()];
            ParameterInfo[] parameters = method.GetParameters();
            comboBox3.Items.Clear();
            for (int i = 0; i < parameters.Length; i++)
            {
                comboBox3.Items.Add(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                currParams.Add(parameters[i].ParameterType.Name + " " + parameters[i].Name, parameters[i]);
            }
            comboBox3.Refresh();
        }
    }
}