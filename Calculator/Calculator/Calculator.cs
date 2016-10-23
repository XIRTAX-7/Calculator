using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        public double Calculate(string input)
        {
            return Counting(GetExpression(input));
        }

        private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(':
                    return 0;
                case ')':
                    return 1;
                case '+':
                    return 2;
                case '-':
                    return 2;
                case '*':
                    return 3;
                case '/':
                    return 3;
                default:
                    return 4;
            }
        }

        private bool IsDelimeter(char c)
        {
            return ((" =".IndexOf(c) != -1));
        }

        private bool IsOperator(char с)
        {
            return (("+-/*()".IndexOf(с) != -1));
        }

        private string GetExpression(string input)
        {
            var output = string.Empty;
            var operStack = new Stack<char>();

            for (var i = 0; i < input.Length; i++)
            {
                if (IsDelimeter(input[i]))
                    continue;
                if (Char.IsDigit(input[i]))
                {
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output += input[i];
                        i++;
                        if (i == input.Length)
                            break;
                    }
                    output += " ";
                    i--;
                }
                if (IsOperator(input[i]))
                {
                    if (input[i] == '(')
                    {
                        operStack.Push(input[i]);
                       // Console.WriteLine(input[i]);
                      //if (input[i++] == '-')
                    //  {
                       //   operStack.Push('0');
                     // }
                    }
                    else
                        if (input[i] == ')')
                        {
                            char s = operStack.Pop();
                            while (s != '(')
                            {
                                output += s.ToString() + ' ';
                                s = operStack.Pop();
                            }
                        }
                        else
                        {
                            if (operStack.Count > 0)
                                if (GetPriority(input[i]) <= GetPriority(operStack.Peek()))
                                    while (operStack.Count != 0)
                                    {
                                        if (GetPriority(input[i]) > GetPriority(operStack.Peek()))
                                            break;
                                        output += operStack.Pop().ToString() + " ";
                                    }
                            operStack.Push(char.Parse(input[i].ToString()));
                        }
                }
            }
            while (operStack.Count > 0)
                output += operStack.Pop() + " ";
            return output;
        }

        private double Counting(string input)
        {
            double result = 0;
            var temp = new Stack<double>();
            for (var i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    var a = string.Empty;
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length)
                            break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (IsOperator(input[i]))
                {
                    var a = temp.Pop();
                    var b = temp.Pop();
                    switch (input[i])
                    {
                        case '+': result = b + a;
                            break;
                        case '-': result = b - a;
                            break;
                        case '*': result = b * a;
                            break;
                        case '/': result = b / a;
                            break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }
    }
}

