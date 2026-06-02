using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LABA7OOP_1
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        Random random = new Random();
        List<Furniture> list;
        List<OrgTech> orgTechList;

        private void button1_Click(object sender, EventArgs e)
        {
            list = new List<Furniture>();
            orgTechList = new List<OrgTech>();

            string[] orgTechNames = { "Ноутбук", "Компьютер", "Принтер", "Сканер", "Монитор",
                                   "Клавиатура", "Мышь", "Телефон", "Планшет", "Колонки",
                                   "Наушники", "Роутер", "Факс", "Копир", "Проектор" };

            string[] furnitureNames = { "Стул", "Стол", "Шкаф", "Кровать", "Комод",
                                        "Диван", "Кресло", "Тумбочка", "Стеллаж", "Барный стул",
                                        "Журнальный столик", "Полка", "Вешалка", "Пуф", "Этажерка" };

            int itemsCount = random.Next(5, 16);

            for (int i = 0; i < itemsCount; i++)
            {
                string randomName = furnitureNames[random.Next(furnitureNames.Length)];
                int randomWeight = random.Next(2, 101);
                list.Add(new Furniture { name = randomName, weight = randomWeight });
            }

            for (int i = 0; i < itemsCount; i++)
            {
                string randomName = orgTechNames[random.Next(orgTechNames.Length)];
                int randomWeight = random.Next(1, 51);
                int randomYear = random.Next(2010, 2025);
                orgTechList.Add(new OrgTech { name = randomName, weight = randomWeight, year = randomYear });
            }
            SelEl();

        }

        

        private void SelEl()
        {
            if (list == null)
            {
                return;
            }
            String str = comboBox1.SelectedItem.ToString();
            dataGridView1.DataSource = null;
            if (str == "Мебель")
            {
                dataGridView1.DataSource = list;
                dataGridView1.Columns["name"].HeaderText = "Название мебели";
                dataGridView1.Columns["weight"].HeaderText = "Вес (кг)";
                
                
            }
            else if (str == "ОргТехника")
            {
                dataGridView1.DataSource = orgTechList;
                dataGridView1.Columns["name"].HeaderText = "Название";
                dataGridView1.Columns["weight"].HeaderText = "Вес (кг)";
                dataGridView1.Columns["year"].HeaderText = "Год выпуска";
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelEl();
            String str = comboBox1.SelectedItem.ToString();

            if (str == "Мебель")
            {
                textBoxYear.Visible = false;
                labelYear.Visible = false;
            }
            else if (str == "ОргТехника")
            {
                textBoxYear.Visible = true;
                labelYear.Visible = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String str = comboBox1.SelectedItem.ToString();

                if (str == "Мебель")
                {
                    list.Add(new Furniture
                    {
                        name = textBox1.Text,
                        weight = int.Parse(textBox2.Text)
                    });
                }
                else if (str == "ОргТехника")
                {
                    orgTechList.Add(new OrgTech
                    {
                        name = textBox1.Text,
                        weight = int.Parse(textBox2.Text),
                        year = int.Parse(textBoxYear.Text)
                    });
                }
                
                SelEl();
            }
            catch (Exception)
            {

                return;
            }
            
        }

        private void DeleatRow()
        {
            
            DialogResult dr = MessageBox.Show("Удалить", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int selectedRow = dataGridView1.SelectedRows[0].Index;

                
                String str = comboBox1.SelectedItem.ToString();

                if (str == "Мебель" && list != null)
                {
                    list.RemoveAt(selectedRow);
                }
                else if (str == "ОргТехника" && orgTechList != null)
                {
                    orgTechList.RemoveAt(selectedRow);
                }
                SelEl();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dataGridView1.ClearSelection();

                    var hit = dataGridView1.HitTest(e.X, e.Y);
                    dataGridView1.Rows[hit.RowIndex].Selected = true;
                    DeleatRow();
                }
            }
            catch (Exception)
            {

                return;
            }
            
        }
    }
    class Furniture
    {
        public String name { get; set; }
        public int weight { get; set; }
    }

    class OrgTech
    {
        public string name { get; set; }
        public int weight { get; set; }
        public int year { get; set; } 
    }
}