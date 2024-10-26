using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13PZ
{
    // Caretaker - выполняет только функцию хранения объекта Memento

    internal class CalculatorHistory
    {
        private Stack<CalculatorMemento> _undoHistory = new Stack<CalculatorMemento>();
        private Stack<CalculatorMemento> _redoHistory = new Stack<CalculatorMemento>();

        public void Save(CalculatorMemento memento)
        {
            _undoHistory.Push(memento);
            _redoHistory.Clear(); 
        }

        public CalculatorMemento Undo()
        {
            if (_undoHistory.Count > 0)
            {
                var memento = _undoHistory.Pop();
                _redoHistory.Push(memento);
                return memento;
            }
            return null;
        }

        public CalculatorMemento Redo()
        {
            if (_redoHistory.Count > 0)
            {
                var memento = _redoHistory.Pop();
                _undoHistory.Push(memento);
                return memento;
            }
            return null;
        }
    }
}
