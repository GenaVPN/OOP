using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace WPF_11_LABA.model
{
    internal class Model
    {
        public ObservableCollection<DataClass> Cities { get; set; }
        public ICollectionView CitiesView { get; set; }
        private string _searchText;
        public ICommand SortCommand { get; }
        public ICommand DelCommand { get; }
        public ICommand AddCommand { get; }

        public String SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                CitiesView.Refresh();
            }
        }

        private DataClass _selectedCity;
        public DataClass SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged(nameof(SelectedCity));
            }
        }

        private bool FilterCities(object obj)
        {
            if (obj is DataClass city)
                return string.IsNullOrEmpty(SearchText) ||
                       city.Name.ToLower().Contains(SearchText.ToLower()) ||
                       city.Country.ToLower().Contains(SearchText.ToLower());
            return false;
        }
        public Model()
        {
            Cities = new ObservableCollection<DataClass>
        {
            new DataClass { Name="Москва", Country="Россия", Population=13000000 },
            new DataClass { Name="Берлин", Country="Германия", Population=3600000 },
            new DataClass { Name="Токио", Country="Япония", Population=13900000 }
        };

            CitiesView = CollectionViewSource.GetDefaultView(Cities);
            CitiesView.Filter = FilterCities;
            SortCommand = new RelayCommand(SortByPopulation);

            AddCommand = new RelayCommand(AddCity);
            DelCommand = new RelayCommand(DeleteCity);
        }

        private void DeleteCity()
        {
            if (SelectedCity != null)
            {
                Cities.Remove(SelectedCity);
            }

            CitiesView.Refresh();
        }

        private void AddCity()
        {
            var window = new Window1();

            if (window.ShowDialog() == true)
            {
                Cities.Add(window.city);
            }
        }
        private void SortByPopulation()
        {
            CitiesView.SortDescriptions.Clear();
            CitiesView.SortDescriptions.Add(
                new SortDescription(nameof(DataClass.Population), ListSortDirection.Descending));
        }

       

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
