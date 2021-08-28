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
        private static IDataBase dataBaseWorker;



        

       
        public MainWindow()
        {
            InitializeComponent();
            dataBaseWorker = new EntityWorker();


            var phones = dataBaseWorker.GetPhones();
            ListPhones.ItemsSource = phones;

        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            var t = ListPhones.SelectedItem as Phone;
            dataBaseWorker.DeletePhone(t);
        }

        private void NewPerson_Click(object sender, RoutedEventArgs e)
        {
            PersonInfo personInfo = new PersonInfo(dataBaseWorker);
            personInfo.SetDataPerson();
            personInfo.Show();
        }

        private void Change_button_Click(object sender, RoutedEventArgs e)
        {
            PersonInfo personInfo = new PersonInfo(dataBaseWorker);
            var t = ListPhones.SelectedItem as Phone;
            personInfo.SetDataPerson(t.person);
            personInfo.Show();
        }

        private void Find_Click_Button(object sender, RoutedEventArgs e)
        {
            var menuItem = e.Source as MenuItem;
          
            switch (menuItem.Header) {
                case "поиск по имени":
                    var findByname =  dataBaseWorker.GetPhones().Where(p => p.person.name.ToLower().Contains(FindInfo.Text.ToLower()));
                    if(findByname != null) ListPhones.ItemsSource = findByname;
                    break;
                case "поиск по фамилии":
                    var findBySurname = ListPhones.ItemsSource = dataBaseWorker.GetPhones().Where(p => p.person.surname.ToLower().Contains(FindInfo.Text.ToLower()) );
                    if (findBySurname != null) ListPhones.ItemsSource = findBySurname;
                    break;
                case "поиск по отчеству":
                    var findByLastName = ListPhones.ItemsSource = dataBaseWorker.GetPhones().Where(p => p.person.lastName.ToLower().Contains(FindInfo.Text.ToLower()));
                    if (findByLastName != null) ListPhones.ItemsSource = findByLastName;
                    break;
                case "поиск по телефону":
                    var findByPhone = ListPhones.ItemsSource = dataBaseWorker.GetPhones().Where(p => p.phone.ToLower().Contains(FindInfo.Text.ToLower()));
                    if (findByPhone != null) ListPhones.ItemsSource = findByPhone;
                    break;
            }
        }
        private void Update_List_Click(object sender, RoutedEventArgs e)
        {
            var phones = dataBaseWorker.GetPhones();
            ListPhones.ItemsSource = phones;
        }

       

    }


}
