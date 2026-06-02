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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_10_laba
{

    public class Apteka_obj
    {
        
        public String Name_medicines { get; set; }
        public String Provider { get; set; }
        public String Indications { get; set; }
        public String Patients { get; set; }

        public int count { get; set; }

        public double Cena {  get; set;}
        public Apteka_obj(string name_medicines,
                      string provider,
                      string indications,
                      string patients,
                      int count,
                      double cena)
        {
            Name_medicines = name_medicines;
            Provider = provider;
            Indications = indications;
            Patients = patients;
            this.count = count;
            Cena = cena;
        }
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        private List<Apteka_obj> medicines;
        private List<Apteka_obj> CreateMedicines()
        {
            var medicines = new List<Apteka_obj>();

            string[] names = { "Парацетамол", "Ибупрофен", "Амоксициллин", "Аспирин", "Омепразол",
                       "Лоратадин", "Цитрамон", "Но-шпа", "Анальгин", "Кеторол",
                       "Диклофенак", "Нимесил", "Арбидол", "Ингавирин", "Эргоферон",
                       "Афобазол", "Глицин", "Валидол", "Корвалол", "Мезим" };

            string[] providers = { "Фармстандарт", "Bayer", "Sanofi", "Pfizer", "Novartis",
                           "Р-Фарм", "Отисифарм", "Верофарм", "Биокад", "Гедеон Рихтер",
                           "КРКА", "Берлин-Хеми", "Штада", "Тева", "Эбботт",
                           "Акрихин", "Сотекс", "Валента", "Полисан", "Микроген" };

            string[] indications = { "Головная боль", "Воспаление", "Инфекции дыхательных путей",
                             "Профилактика тромбозов", "Гастрит",
                             "Аллергия", "Мигрень", "Спазмы", "Болевой синдром", "Сильная боль",
                             "Артрит", "Боль в суставах", "ОРВИ", "Грипп", "Простуда",
                             "Тревожность", "Стресс", "Сердечные боли", "Тахикардия", "Пищеварение" };

            // Инициалы пациентов (Фамилия И.О.)
            string[] patients = { "Иванов И.И.", "Петрова А.С.", "Сидоров В.П.", "Козлова Е.Н.", "Морозов Д.А.",
                          "Смирнова О.В.", "Кузнецов И.Г.", "Попова М.Л.", "Васильев Н.Р.", "Соколова Т.Б.",
                          "Михайлов А.Д.", "Новикова Ю.К.", "Федоров С.М.", "Морозова Е.В.", "Волков П.А.",
                          "Зайцева Л.С.", "Белов Г.Н.", "Тарасова И.А.", "Медведев К.Ю.", "Егорова А.П." };

            var random = new Random();

            for (uint i = 0; i < 25; i++)
            {
                Apteka_obj medicine = new Apteka_obj(
                    names[random.Next(0, 19)],
                    providers[random.Next(0, 19)],
                    indications[random.Next(0, 19)],
                    patients[random.Next(0, 19)],
                    random.Next(10, 200),
                    Math.Round(random.NextDouble() * (1500 - 50) + 50, 2)
                );

                medicines.Add(medicine);
            }

            return medicines;
        }

        public void AddObj(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1();

            if (win.ShowDialog() == true)
            {
                medicines.Add(win.NewMedicine);

                Table.Items.Refresh();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            medicines = CreateMedicines();
            Table.ItemsSource = medicines;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Table.SelectedIndex != -1)
            {
                medicines.RemoveAt(Table.SelectedIndex);
                Table.Items.Refresh();
            }
            
        }
    }
}
