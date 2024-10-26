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

namespace _13PZ
{
    
    public partial class MainWindow : Window
    {
        private Calculator _calculator;
        private CalculatorHistory _history;

        public MainWindow()
        {
            InitializeComponent();
            _calculator = new Calculator();
            _history = new CalculatorHistory();
        }

        //логика калькулятора с сохранением состояния
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (double.TryParse(button.Content.ToString(), out _))
                {
                    _calculator.Input(button.Content.ToString());
                }
                else 
                {
                    _calculator.SetOperation(button.Content.ToString());
                }
                Display.Text = _calculator.GetState();
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            _history.Save(_calculator.SaveState());
            Display.Text = _calculator.Evaluate();         }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _history.Save(_calculator.SaveState()); // Сохранение состояния перед очисткой
            _calculator.Clear();
            Display.Text = _calculator.GetState();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            var memento = _history.Undo();
            if (memento != null)
            {
                _calculator.RestoreState(memento);
                Display.Text = _calculator.GetState();
            }
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            var memento = _history.Redo();
            if (memento != null)
            {
                _calculator.RestoreState(memento);
                Display.Text = _calculator.GetState();
            }
        }
    }
}
