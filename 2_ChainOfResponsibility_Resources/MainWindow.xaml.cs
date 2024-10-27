using _2_ChainOfResponsibility_Resources.Roles;
using Microsoft.Win32;
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

namespace _2_ChainOfResponsibility_Resources
{

    public partial class MainWindow : Window
    {
        private AccessHandler _accessHandler;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAccessHandlers();
        }

        private void InitializeAccessHandlers()
        {
            // Инициализация цепочки обязанностей
            AccessHandler adminHandler = new AdminAccessHandler();
            AccessHandler managerHandler = new ManagerAccessHandler();
            AccessHandler userHandler = new UserAccessHandler();

            adminHandler.Successor = managerHandler;
            managerHandler.Successor = userHandler;

            _accessHandler = adminHandler;
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                string userRole = RoleTextBox.Text;

                // Проверка доступа
                FileAccessRequest request = new FileAccessRequest(fileName, userRole);
                _accessHandler.Handle(request);

                ResultTextBlock.Text = $"Доступ к файлу '{fileName}' проверен для роли '{userRole}'.";
            }
        }
    }
}
