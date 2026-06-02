using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_10_laba
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Apteka_obj NewMedicine { get; set; }
        public Window1()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pat = PatientBox.Text;
                string med = MedicineBox.Text;
                string ind = IndicationBox.Text;
                string provider = ProviderBox.Text;

                int Count = int.Parse(CountBox.Text);
                double Price = double.Parse(PriceBox.Text);

                NewMedicine = new Apteka_obj(
                    med,
                    provider,
                    ind,
                    pat,
                    Count,
                    Price
                );

              

                DialogResult = true;

                Close();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
