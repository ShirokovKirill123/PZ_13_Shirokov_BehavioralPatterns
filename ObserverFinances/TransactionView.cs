using ObserverFinances.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ObserverFinances
{
    //представление данных в интерфейсе
    public class TransactionView : IObserver
    {
        private ListView _transactionListView;

        public TransactionView(ListView transactionListView)
        {
            _transactionListView = transactionListView;
        }

        public void Update(object obj)
        {
            var transactionInfo = (TransactionInfo)obj;

            _transactionListView.Items.Clear();

            foreach (var transaction in transactionInfo.Transactions)
            {
                _transactionListView.Items.Add(transaction);
            }
        }
    }
}
