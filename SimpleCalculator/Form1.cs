namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private bool isFirstNumberTyped = false;
        private decimal nextNumber;
        private bool isNextNumberTyped = false;
        private string number;
        private string lastOperation;
        private decimal result;

        private bool enableButtons = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void DeleteAll()
        {
            isFirstNumberTyped = false;
            isNextNumberTyped = false;
            result = 0;
            nextNumber = 0;
            number = "";
            lastOperation = "";

            enableButtons = true;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;

            textBox1.Text = "";
        }

        private void Operation()
        {
            if (!isFirstNumberTyped)
            {
                result = Convert.ToDecimal(number);
                isFirstNumberTyped = true;
            }
            number = "";
        }

        private void CalculateTwo(decimal number1, decimal number2)
        {
            switch (lastOperation)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
            }
        }

        private void CalculatingProcess(Button button)
        {
            string buttonText = button.Text;

            switch (buttonText)
            {
                case "=":
                    Operation();
                    if (isNextNumberTyped)
                    {
                        CalculateTwo(result, nextNumber);
                    }
                    textBox1.Text = result.ToString();

                    isNextNumberTyped = false;
                    break;
                case "+":
                    Operation();
                    if (isNextNumberTyped)
                    {
                        CalculateTwo(result, nextNumber);
                    }
                    lastOperation = "+";
                    break;
                case "-":
                    Operation();
                    if (isNextNumberTyped)
                    {
                        CalculateTwo(result, nextNumber);
                    }
                    lastOperation = "-";
                    break;
                case "*":
                    Operation();
                    if (isNextNumberTyped)
                    {
                        CalculateTwo(result, nextNumber);
                    }
                    lastOperation = "*";
                    break;
                case "/":
                    Operation();
                    if (isNextNumberTyped)
                    {
                        CalculateTwo(result, nextNumber);
                    }
                    lastOperation = "/";
                    break;
                default:
                    if(enableButtons)
                    {
                        button11.Enabled = true;
                        button12.Enabled = true;
                        button13.Enabled = true;
                        button14.Enabled = true;
                        button15.Enabled = true;

                        enableButtons = false;
                    }
                    

                    number += buttonText;

                    if (isFirstNumberTyped)
                    {
                        nextNumber = Convert.ToDecimal(number);
                        isNextNumberTyped = true;
                    }
                    break;
            }

            if (buttonText != "=")
            {
                textBox1.Text += buttonText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button? clickedButton = sender as Button;

            CalculatingProcess(clickedButton);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DeleteAll();
        }
    }
}