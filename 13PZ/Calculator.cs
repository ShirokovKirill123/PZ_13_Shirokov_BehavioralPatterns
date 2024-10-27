using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13PZ
{
    //Originator - создание объекта хранителя для сохранения своего состояния

    internal class Calculator
    {
        private string _currentState = "0";
        private string _operation;
        private double _operand1;

        public void Input(string input)
        {
            if (_currentState == "0" || _operation != null)
                _currentState = input; // новое число
            else
                _currentState += input; // продолжение числа
        }

        public void SetOperation(string operation)
        {
            if (double.TryParse(_currentState, out _operand1))
            {
                _operation = operation; // запоминание операцию
                _currentState = "0"; // сброс состояния
            }
        }

        public string GetState() => _currentState;

        public CalculatorMemento SaveState()
        {
            return new CalculatorMemento(_currentState);
        }

        public void RestoreState(CalculatorMemento memento)
        {
            _currentState = memento.State;
        }

        public void Clear()
        {
            _currentState = "0";
            _operation = null;
        }

        public string Evaluate()
        {
            try
            {
                if (_operation == null)
                    return _currentState; // отсутствие вычислений без операции

                if (!double.TryParse(_currentState, out double operand2))
                    throw new InvalidOperationException("Некорректное второе число");

                double result = 0;

                switch (_operation)
                {
                    case "+":
                        result = _operand1 + operand2;
                        break;
                    case "-":
                        result = _operand1 - operand2;
                        break;
                    case "*":
                        result = _operand1 * operand2;
                        break;
                    case "/":
                        if (operand2 == 0)
                            throw new DivideByZeroException("Деление на ноль невозможно");
                        result = _operand1 / operand2;
                        break;
                }

                _currentState = result.ToString(); 
                _operation = null; 
                return _currentState;
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }
    }
}
