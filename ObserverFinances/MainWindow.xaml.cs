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

namespace ObserverFinances
{
    public partial class MainWindow : Window
    {
        private readonly FinanceTracker financeTracker = new FinanceTracker();
        private readonly TransactionView transactionView;
        private int currentTransactionIndex = 1; 

        public MainWindow()
        {
            InitializeComponent();
            transactionView = new TransactionView(TransactionListView);
            financeTracker.RegisterObserver(transactionView);
        }

        private void AddTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            var transaction = new Transaction($"{currentTransactionIndex}_transaction", 100.0m, DateTime.Now);
            financeTracker.AddTransaction(transaction);
            currentTransactionIndex++; 
        }

        private void UpdateTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTransaction = TransactionListView.SelectedItem as Transaction;

            if (selectedTransaction != null)
            {
                int index = financeTracker.TransactionInfo.Transactions.IndexOf(selectedTransaction);

                var updatedTransaction = new Transaction($"{index + 1}_обновленный", 150.0m, DateTime.Now);
                financeTracker.UpdateTransaction(index, updatedTransaction);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите транзакцию для обновления.");
            }
        }
    }
}
