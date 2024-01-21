using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calc
{
    public partial class MainPage : ContentPage
    {
        string currentInput = "";
        string previousInput = "";
        char currentOperator;

        public MainPage()
        {
            InitializeComponent();
            resultLabel = this.FindByName<Label>("resultLabel");
        }

        void OnNumberButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            resultLabel.Text = currentInput;
        }

        void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            previousInput = currentInput;
            currentInput = "";
            currentOperator = button.Text[0];
        }

        void OnClearButtonClicked(object sender, EventArgs e)
        {
            currentInput = "";
            previousInput = "";
            currentOperator = '\0';
            resultLabel.Text = "0";
        }

        void OnEqualsButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(previousInput) && !string.IsNullOrEmpty(currentInput))
            {
                decimal num1 = decimal.Parse(previousInput);
                decimal num2 = decimal.Parse(currentInput);
                decimal result = 0;

                switch (currentOperator)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                            resultLabel.Text = "Error";
                        break;
                }

                resultLabel.Text = result.ToString();
                currentInput = result.ToString();
                previousInput = "";
                currentOperator = '\0';
            }
        }
    }
}
