namespace LABA_8_2_OOP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DATAGRID = new System.Windows.Forms.DataGridView();
            this.BINSOUR = new System.Windows.Forms.BindingSource(this.components);
            this.FILMDATA = new LABA_8_2_OOP.FilmotekaDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_save = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.clientsTableAdapter = new LABA_8_2_OOP.FilmotekaDataSetTableAdapters.ClientsTableAdapter();
            this.filmsTableAdapter = new LABA_8_2_OOP.FilmotekaDataSetTableAdapters.FilmsTableAdapter();
            this.librariansTableAdapter = new LABA_8_2_OOP.FilmotekaDataSetTableAdapters.LibrariansTableAdapter();
            this.rentalsTableAdapter = new LABA_8_2_OOP.FilmotekaDataSetTableAdapters.RentalsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BINSOUR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FILMDATA)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DATAGRID
            // 
            this.DATAGRID.AutoGenerateColumns = false;
            this.DATAGRID.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DATAGRID.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRID.DataSource = this.BINSOUR;
            this.DATAGRID.Location = new System.Drawing.Point(-1, -1);
            this.DATAGRID.MultiSelect = false;
            this.DATAGRID.Name = "DATAGRID";
            this.DATAGRID.RowHeadersVisible = false;
            this.DATAGRID.RowHeadersWidth = 51;
            this.DATAGRID.RowTemplate.Height = 24;
            this.DATAGRID.Size = new System.Drawing.Size(720, 415);
            this.DATAGRID.TabIndex = 0;
            this.DATAGRID.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DATAGRID_CellContentClick);
            this.DATAGRID.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DATAGRID_DataError);
            // 
            // BINSOUR
            // 
            this.BINSOUR.AllowNew = true;
            this.BINSOUR.DataSource = this.FILMDATA;
            this.BINSOUR.Position = 0;
            // 
            // FILMDATA
            // 
            this.FILMDATA.DataSetName = "FilmotekaDataSet";
            this.FILMDATA.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.DATAGRID);
            this.panel1.Location = new System.Drawing.Point(246, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 419);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Location = new System.Drawing.Point(12, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 418);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.button_save, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.button6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.button7, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.button8, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button9, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(219, 155);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(102, 105);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(112, 45);
            this.button_save.TabIndex = 4;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 45);
            this.button6.TabIndex = 1;
            this.button6.Text = "Фильмы";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 105);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(102, 54);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(112, 45);
            this.button7.TabIndex = 4;
            this.button7.Text = "Библиотекари";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(102, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(112, 45);
            this.button8.TabIndex = 2;
            this.button8.Text = "Клиенты";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(3, 54);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(93, 45);
            this.button9.TabIndex = 3;
            this.button9.Text = "Журнал";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = false;
            // 
            // filmsTableAdapter
            // 
            this.filmsTableAdapter.ClearBeforeFill = true;
            // 
            // librariansTableAdapter
            // 
            this.librariansTableAdapter.ClearBeforeFill = true;
            // 
            // rentalsTableAdapter
            // 
            this.rentalsTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BINSOUR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FILMDATA)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DATAGRID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.BindingSource BINSOUR;
        private FilmotekaDataSet FILMDATA;
        private FilmotekaDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private FilmotekaDataSetTableAdapters.FilmsTableAdapter filmsTableAdapter;
        private FilmotekaDataSetTableAdapters.LibrariansTableAdapter librariansTableAdapter;
        private FilmotekaDataSetTableAdapters.RentalsTableAdapter rentalsTableAdapter;
    }
}

