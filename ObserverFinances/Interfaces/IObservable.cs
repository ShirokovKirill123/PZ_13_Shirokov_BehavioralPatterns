namespace ObserverFinances.Interfaces
{
    //наблюдаемый объект
    public interface IObservable
    {
        void NotifyObservers();
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
    }
}