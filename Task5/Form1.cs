using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            List<String> methods = new List<string>();
            foreach (MethodInfo method in myType.GetMethods())
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                methods.Add(modificator + " " + method.ReturnType.Name + " " + method.Name + "\n");

                /*
                //получаем все параметры
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }

                Console.WriteLine(")");*/
            }

            comboBox2.Items.AddRange(methods.ToArray());
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            throw new System.NotImplementedException();
            // TODO: если к-б-ы не пусты, нажат энтер, то заполнить поле класса
        }
    }
}