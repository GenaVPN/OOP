using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA_8_2_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.rentalsTableAdapter.Fill(this.FILMDATA.Rentals);
            this.librariansTableAdapter.Fill(this.FILMDATA.Librarians);
            this.filmsTableAdapter.Fill(this.FILMDATA.Films);
            this.clientsTableAdapter.Fill(this.FILMDATA.Clients);

            DATAGRID.AutoGenerateColumns = true;

            
            BINSOUR.DataMember = "Films";

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DATAGRID.Columns.Clear();
            BINSOUR.DataMember = "Films";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DATAGRID.Columns.Clear();
            BINSOUR.DataMember = "Clients";
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            this.Validate();
            BINSOUR.EndEdit();

            filmsTableAdapter.Update(FILMDATA.Films);
            clientsTableAdapter.Update(FILMDATA.Clients);
            librariansTableAdapter.Update(FILMDATA.Librarians);
            rentalsTableAdapter.Update(FILMDATA.Rentals);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DATAGRID.Columns.Clear();
            BINSOUR.DataMember = "Librarians";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BINSOUR.DataMember = "Rentals";

            DATAGRID.Columns.Clear();
            DATAGRID.AutoGenerateColumns = false;

           

            
            DATAGRID.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "rental_id",
                HeaderText = "ID"
            });

            
            DataGridViewComboBoxColumn filmColumn =
                new DataGridViewComboBoxColumn();

            filmColumn.DataPropertyName = "film_id";
            filmColumn.HeaderText = "Фильм";
            filmColumn.DataSource = FILMDATA.Films;
            filmColumn.DisplayMember = "title";
            filmColumn.ValueMember = "film_id";

            DATAGRID.Columns.Add(filmColumn);

            
            DataGridViewComboBoxColumn clientColumn =
                new DataGridViewComboBoxColumn();

            clientColumn.DataPropertyName = "client_id";
            clientColumn.HeaderText = "Клиент";
            clientColumn.DataSource = FILMDATA.Clients;
            clientColumn.DisplayMember = "full_name";
            clientColumn.ValueMember = "client_id";

            DATAGRID.Columns.Add(clientColumn);

         
            DataGridViewComboBoxColumn librarianColumn =
                new DataGridViewComboBoxColumn();

            librarianColumn.DataPropertyName = "librarian_id";
            librarianColumn.HeaderText = "Библиотекарь";
            librarianColumn.DataSource = FILMDATA.Librarians;
            librarianColumn.DisplayMember = "full_name";
            librarianColumn.ValueMember = "librarian_id";

            DATAGRID.Columns.Add(librarianColumn);
            DATAGRID.AutoGenerateColumns = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BINSOUR.Current != null)
            {
                BINSOUR.RemoveCurrent();
            }
        }

        private void DATAGRID_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DATAGRID_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(
        "Неверный тип данных!\nПроверьте введённое значение.",
        "Ошибка ввода",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error
    );

            e.ThrowException = false;
        }
    }
}
