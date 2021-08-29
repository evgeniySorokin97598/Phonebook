using LogicLayer.Workers;
using ModelsLayer.DataBaseModels;
using ModelsLayer.Interfaces;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Directory
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static IDataBase _dataBaseWorker;
        public MainWindow()
        {
            InitializeComponent();
            _dataBaseWorker = new EntityWorker();


            var phones = _dataBaseWorker.GetPhones();
            ListPhones.ItemsSource = phones;

        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            var t = ListPhones.SelectedItem as Phone;
            _dataBaseWorker.DeletePhone(t);
            
        }

        private void NewPerson_Click(object sender, RoutedEventArgs e)
        {
            PersonInfo personInfo = new PersonInfo(_dataBaseWorker);
            personInfo.SetDataPerson();
            personInfo.Show();
        }

        private void Change_button_Click(object sender, RoutedEventArgs e)
        {
            PersonInfo personInfo = new PersonInfo(_dataBaseWorker);
            var t = ListPhones.SelectedItem as Phone;
            personInfo.SetDataPerson(t.person);
            personInfo.Show();
        }

        private void Find_Click_Button(object sender, RoutedEventArgs e)
        {
            var menuItem = e.Source as MenuItem;
            if (string.IsNullOrEmpty(FindInfo.Text.Trim())) {
                MessageBox.Show("Поле с искомыми данными не заполнено ");
                return;
                
            }
            switch (menuItem.Header) {
                
                case "поиск по имени":
                    var findByname =  _dataBaseWorker._finder.FindByName(FindInfo.Text);
                    if(findByname != null) ListPhones.ItemsSource = findByname;
                    break;
                case "поиск по фамилии":
                    var findBySurname = ListPhones.ItemsSource = _dataBaseWorker._finder.FindBySurname(FindInfo.Text);
                    if (findBySurname != null) ListPhones.ItemsSource = findBySurname;
                    break;
                case "поиск по отчеству":
                    var findByLastName = ListPhones.ItemsSource = _dataBaseWorker._finder.FindByLastName(FindInfo.Text);
                    if (findByLastName != null) ListPhones.ItemsSource = findByLastName;
                    break;
                case "поиск по телефону":
                    var findByPhone = ListPhones.ItemsSource = _dataBaseWorker._finder.FindByPhone(FindInfo.Text);
                    if (findByPhone != null) ListPhones.ItemsSource = findByPhone;
                    break;
            }
        }
        private void Update_List_Click(object sender, RoutedEventArgs e)
        {
            var phones = _dataBaseWorker.GetPhones();
            ListPhones.ItemsSource = phones;
        }

       

    }


}
