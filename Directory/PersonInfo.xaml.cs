using ModelsLayer.DataBaseModels;
using ModelsLayer.Interfaces;
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

namespace Directory
{
    /// <summary>
    /// Логика взаимодействия для PersonInfo.xaml
    /// </summary>
    public partial class PersonInfo : Window
    {
      
        private IDataBase _dataBaseWorker;
        private Person _person;
        private bool isNewPerson = false;
        public PersonInfo(IDataBase dataBaseWorker)
        {
            InitializeComponent();
            _dataBaseWorker = dataBaseWorker;

        }

        public void SetDataPerson(Person person = null) {
            
            if (person != null)
            {
                _person = person;
                button.Content = "изменить";
                NameTextBox.Text = person.name;
                SurnameTextBox.Text = person.surname;
                lastNameTextBox.Text = person.lastName;
                PhoneTextBox.Text = person.phone.phone;
                AdresTextBox.Text = person.adres;
            }
            else {
                _person = new Person();
                button.Content = "добавить";
                isNewPerson = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _person.name = NameTextBox.Text;
            _person.surname = SurnameTextBox.Text;
            _person.lastName = lastNameTextBox.Text;
            _person.adres = AdresTextBox.Text;

            _person.phone = _person.phone == null ? _person.phone = new Phone() : _person.phone;
            _person.phone.phone = PhoneTextBox.Text;
            _person.phone.person = _person;


            if (_person.CheckNull() == true && _person.phone.CheckNull() == true)
            {
                
                if (isNewPerson == true) _dataBaseWorker.AddPerson(_person);
                else _dataBaseWorker.ChangePerson(_person);
               
                Close();
            }
            else MessageBox.Show("Не все поля заполнены или пустые");
           
            
        }
    }
}
