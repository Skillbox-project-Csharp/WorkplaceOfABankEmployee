using BankSystemLibrary.BankSystem;
using BankSystemLibrary.BankSystem.BankClients;
using BankSystemLibrary.BankWorkers;
using BankSystemWpfControlLibrary;
using BankSystemWpfControlLibrary.SelectionWindows;
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

namespace WorkplaceOfABankEmployee
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            customerAccountManagementMenu.Employee = new Consultant("Name", "SurName", "");
            customerAccountManagementMenu.BankClients = new ObservableCollection<Client>
            {
                new BankClient{Name ="Анна", SurName="Петровна", Patronymic="Игоревна"},
                new BankClient{Name ="Павел", SurName="Вересов", Patronymic="Александрович"},
                new BankClient{Name ="Андрей", SurName="Краснов", Patronymic=""}
            };
        }

        private void MenuChangeAnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeSelectionWindow employeeSelection = new EmployeeSelectionWindow();
            if (employeeSelection.ShowDialog() == true)
            {
                customerAccountManagementMenu.Employee = employeeSelection.GetWorker;
            }
        }
        private void MenuOpenHistoryWindows_Click(object sender, RoutedEventArgs e)
        {
            HistoryOperationWindows historyOperationWindows = new HistoryOperationWindows(CustomerAccountManagementMenu.HistoryOperations);
            historyOperationWindows.Show();
        }
    }
}
