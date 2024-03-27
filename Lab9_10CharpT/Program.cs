using System;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;


namespace Lab8CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab#8 ");
            Console.WriteLine("What task do you want?");
            Console.WriteLine("1. Task 1");
            Console.WriteLine("2. Task 2");
            Console.WriteLine("3. Task 3");
            Console.WriteLine("4. Task 4");
            Console.WriteLine("5. Exit");

            int choice;
            bool isValidChoice = false;

            do
            {
                Console.Write("Enter number of task ");
                isValidChoice = int.TryParse(Console.ReadLine(), out choice);

                if (!isValidChoice || choice < 1 || choice > 6)
                {
                    Console.WriteLine("This task not exist");
                    isValidChoice = false;
                }
            } while (!isValidChoice);
            switch (choice)
            {
                case 1:
                    task1();
                    break;
                case 2:
                    task2();
                    break;
                case 3:
                    task3();
                    break;
                case 4:
                    task4();
                    break;
                case 5:
                    break;
            }
        }

        static int EvaluateFormula(string formula)
        {
            Stack<int> operands = new Stack<int>();
            Stack<char> operators = new Stack<char>();

            foreach (char ch in formula)
            {
                if (ch == '(')
                {
                    operators.Push(ch);
                }
                else if (char.IsDigit(ch))
                {
                    operands.Push(int.Parse(ch.ToString()));
                }
                else if (ch == 'm' || ch == 'M')
                {
                    operators.Push(ch);
                }
                else if (ch == ',' || ch == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != '(' && operands.Count >= 2)
                    {
                        char op = operators.Pop();
                        int operand2 = operands.Pop();
                        int operand1 = operands.Pop();

                        if (op == 'm')
                            operands.Push(Math.Min(operand1, operand2));
                        else if (op == 'M')
                            operands.Push(Math.Max(operand1, operand2));
                    }

                    if (ch == ')')
                    {
                        operators.Pop(); // Видаляємо відкриваючу дужку

                        if (operators.Count > 0 && (operators.Peek() == 'm' || operators.Peek() == 'M'))
                        {
                            char op = operators.Pop();
                            int operand2 = operands.Pop();
                            int operand1 = operands.Pop();

                            if (op == 'm')
                                operands.Push(Math.Min(operand1, operand2));
                            else if (op == 'M')
                                operands.Push(Math.Max(operand1, operand2));
                        }
                    }
                }
            }

            return operands.Pop();
        }

        static void task1()
        {
            Console.Write("Task 1\n");
            string filePath = "formula.txt"; // Замініть шлях на ваш файл
            string formula;

            try
            {
                formula = File.ReadAllText(filePath);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }

            int result = EvaluateFormula(formula);
            Console.WriteLine("Res " + formula + " = " + result);
        }
        static void task2()
        {
            Console.Write("Task 2\n");

        }
        static void task3()
        {
            Console.Write("Task 3\n");

        }
        static void task4()
        {
            Console.WriteLine("Task 4\n");
            
        }

    }
}
