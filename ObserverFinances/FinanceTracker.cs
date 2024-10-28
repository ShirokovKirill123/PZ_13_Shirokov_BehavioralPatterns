using ObserverFinances.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverFinances
{
    //Реализация интерфейса IObservable
    public class FinanceTracker : IObservable
    {
        private readonly List<IObserver> observers = new List<IObserver>();
        public TransactionInfo TransactionInfo { get; } = new TransactionInfo();

        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(TransactionInfo);
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            TransactionInfo.AddTransaction(transaction);
            NotifyObservers();
        }

        public void UpdateTransaction(int index, Transaction transaction)
        {
            TransactionInfo.UpdateTransaction(index, transaction);
            NotifyObservers();
        }
    }
}
