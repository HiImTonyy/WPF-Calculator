using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LearningWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double numberPressed, answer;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            plusMinusButton.Click += PlusMinusButton_Click;
            caButton.Click += CaButton_Click;
            percentButton.Click += PercentButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(answerLabel.Content.ToString(), out numberPressed))
            {
                answerLabel.Content = "0";
            }

            if (sender == plusButton) { selectedOperator = SelectedOperator.add; }
            if (sender == minusButton) { selectedOperator = SelectedOperator.minus; }
            if (sender == divideButton) { selectedOperator = SelectedOperator.divide; }
            if (sender == multiplyButton) { selectedOperator = SelectedOperator.multiply; }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton) { selectedValue = 0; }
            if (sender == oneButton) { selectedValue = 1; }
            if (sender == twoButton) { selectedValue = 2; }
            if (sender == threeButton) { selectedValue = 3; }
            if (sender == fourButton) { selectedValue = 4; }
            if (sender == fiveButton) { selectedValue = 5; }
            if (sender == sixButton) { selectedValue = 6; }
            if (sender == sevenButton) { selectedValue = 7; }
            if (sender == eightButton) { selectedValue = 8; }
            if (sender == nineButton) { selectedValue = 9; }

            if (answerLabel.Content.ToString() == "0")
            {
                answerLabel.Content = $"{selectedValue}";
            }
            else
            {
                answerLabel.Content = $"{answerLabel.Content}{selectedValue}";
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(answerLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.add:
                        answer = SimpleMath.Plus(numberPressed, newNumber);
                        break;
                    case SelectedOperator.minus:
                        answer = SimpleMath.Minus(numberPressed, newNumber);
                        break;
                    case SelectedOperator.divide:
                        answer = SimpleMath.Divide(numberPressed, newNumber);
                        break;
                    case SelectedOperator.multiply:
                        answer = SimpleMath.Multiply(numberPressed, newNumber);
                        break;
                }

                answerLabel.Content = answer.ToString();
            }

        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(answerLabel.Content.ToString(), out numberPressed))
            {
                numberPressed = numberPressed / 100;
                answerLabel.Content = numberPressed.ToString();
            }
        }

        private void CaButton_Click(object sender, RoutedEventArgs e)
        {
            answerLabel.Content = "0";
        }

        private void PlusMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(answerLabel.Content.ToString(), out numberPressed))
            {
                numberPressed = numberPressed * -1;
                answerLabel.Content = numberPressed.ToString();
            }
        }
    }

    public enum SelectedOperator
    {
        add, minus, divide, multiply
    }

    public class SimpleMath
    {
        public static double Plus(double number1, double  number2)
        {
            return number1 + number2;
        }

        public static double Minus(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double Divide(double number1, double number2)
        {
            return number1 / number2;
        }

        public static double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }
    }
}