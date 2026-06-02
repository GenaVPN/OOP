using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public StringBuilder FileRIGHT(string path)
        {
            StringBuilder str = new StringBuilder();
            string[] text = File.ReadAllLines(path, Encoding.UTF8);
            for (int i = 0; i < text.Length; i++)
            {
                str.AppendLine(text[i]);
                text[i] = text[i].PadLeft(80);
            }
            File.WriteAllLines(path, text);
            str.AppendLine("--------------");
            str.AppendLine("ФАЙЛ ГОТОВ");
            return str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                string path = openFileDialog1.FileName;
                StringBuilder str =  FileRIGHT(path);
                textBox1.Text = str.ToString();
            }
        }
    }
}
