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
using WpfApplicationLogin.Models;

namespace WpfApplicationLogin
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void New(object sender, RoutedEventArgs e)
        {
            AddWindow a = new AddWindow();
            a.Show();
            this.Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            var log = App.Repo.Logs.Find(((Log)liste.SelectedItem).ID);
            App.Repo.Logs.Remove(log);
            App.Repo.SaveChanges();

            liste.ItemsSource = null;
            liste.ItemsSource = App.CurrentUser.Logs;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            var log = (Log)liste.SelectedItem;
            App.CurrentLog = log;
            EditWindow a = new EditWindow();
            a.Gunluk = log.logs;
            this.Close();
            a.Show();
        }
    }
}
