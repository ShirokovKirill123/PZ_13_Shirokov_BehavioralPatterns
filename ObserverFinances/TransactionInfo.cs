using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverFinances
{
    //хранение информации о транзакциях
    public class TransactionInfo
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void UpdateTransaction(int index, Transaction transaction)
        {
            if (index >= 0 && index < Transactions.Count)
            {
                Transactions[index] = transaction;
            }
        }
    }
}
