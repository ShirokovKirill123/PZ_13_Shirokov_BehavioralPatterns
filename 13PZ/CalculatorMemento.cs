using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13PZ
{
    // Memento - хранитель, который сохраняет состояние объекта Originator 

    internal class CalculatorMemento
    {
        public string State { get; private set; }

        public CalculatorMemento(string state)
        {
            State = state;
        }
    }
}
