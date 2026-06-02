using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_LABA_9_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Trans> mas = new List<Trans>();
        private void CreateMas(int n)
        {
            mas.Clear();

            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                int type = rand.Next(0, 3);

                string mark = $"Марка_{i + 1}";
                int number = rand.Next(1000, 9999);
                int speed = rand.Next(60, 200);
                int maxWeight = rand.Next(100, 5000);

                switch (type)
                {
                    case 0:
                        mas.Add(new Car(mark, number, speed, maxWeight));
                        break;

                    case 1:
                        bool hasSidecar = rand.Next(0, 2) == 1;
                        mas.Add(new Motorcycle(mark, number, speed, maxWeight, hasSidecar));
                        break;

                    case 2:
                        bool hasTrailer = rand.Next(0, 2) == 1;
                        mas.Add(new Truck(mark, number, speed, maxWeight, hasTrailer));
                        break;
                }
            }
        }

        public void Add_Table()
        {

        }
        private ObservableCollection<Trans> myDataItems = new ObservableCollection<Trans>();
        private ObservableCollection<Trans> FilterItem = new ObservableCollection<Trans>();

        public MainWindow()
        {
            InitializeComponent();    
            DATAGRID.ItemsSource = myDataItems;
        }

        public void B_click_ADD(object sender, RoutedEventArgs e)
        {
            int n;
            int.TryParse(TextBoxElements.Text, out n);
            myDataItems.Clear();
            CreateMas(n);
            foreach (var item in mas)
            {
                myDataItems.Add(item);
            }
            DATAGRID.ItemsSource = myDataItems;
            TextBoxElements.Text = "";
        }

        public void Pokaz(object sender, RoutedEventArgs e)
        {
            DATAGRID.ItemsSource = myDataItems;

        }
        public void Filtr_button(object sender, RoutedEventArgs e)
        {
            int maxWeight;
            int.TryParse(TextBoxFilter.Text,out maxWeight);
            FilterItem.Clear();
            foreach (Trans i in mas)
            {
                if (i.GetLoadCapacity() >= maxWeight)
                {
                    FilterItem.Add(i);
                }
            }
            DATAGRID.ItemsSource = FilterItem;

        }
    }
}
