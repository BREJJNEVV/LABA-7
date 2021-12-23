using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA_7
{
    public partial class Form1 : Form
    {
        private const double V = 0.02;

        public Form1()
        {
            InitializeComponent();
            numericUpDown2.Value = (decimal)V;
        }

        public bool faill = false;

        private void button1_Click(object sender, EventArgs e)
        {

            double a = 0, b = 10, x, y;
            double t = (double)numericUpDown1.Value;    //Точек по горизонтали
            chart1.Series[0].Points.Clear();
            double h = (double)numericUpDown2.Value * 0.1; //Шаг по горизонтали
            x = a;
            double pi = 3.14;

            if (groupBox3.Enabled == true)  
            {
                MessageBox.Show(h + "");
                while (x <= b)
                {
                    y = Math.Pow(Math.Cos(x * h * pi) + Math.Sin(x * h * pi), 2);
                    chart1.Series[0].Points.AddXY(x, y);
                    //MessageBox.Show(y + "");
                    x += h;
                }

            }
            else if(groupBox2.Enabled == true)
            {
                if (faill == false)
                {
                    MessageBox.Show("Нет данных, пожалуйста, выберите файл");
                    return;
                }
                int counter = 0;
                foreach (string line in File.ReadLines(filename))
                {
                    
                    counter++;

                    string[] num = line.Split(' ');
                    int l = int.Parse(num[0]);
                    int m = int.Parse(num[1]);
                    chart1.Series[0].Points.AddXY(l, m);
                }
            }
            if (h == 0)
            {
                MessageBox.Show("расстояние не может быть нулем");
                return;
            }
            MessageBox.Show(h + "");
            
            //chart1.ChartAreas
            
;


        }
        string filename;
        string fileText;

        public object Line { get; private set; }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            button3.Text = "Выбрать другой файл";
            filename = openFileDialog1.FileName;
            fileText = File.ReadAllText(filename);
            faill = true;
            button4.BackColor = Color.Green;
            
        }

        private void button2_Click(object sender, EventArgs e) // exit
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
        }
    }   
}
