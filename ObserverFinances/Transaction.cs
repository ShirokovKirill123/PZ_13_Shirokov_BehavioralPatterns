using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverFinances
{
    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string description, decimal amount, DateTime date)
        {
            Description = description;
            Amount = amount;
            Date = date;
        }
    }
}
