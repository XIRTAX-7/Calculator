using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Calculator
{
    class Inspector
    {
        public bool isInspector(string expr)
        {
            var Calculator = new Calculator();
            var error = false;
            var BracketLeft = 0; var BracketRight = 0;
            var Number = expr.Length - 1;
            expr = new Regex("(--)|(\\+\\+)").Replace(expr, "+");

            //Пустая строка
            if (string.IsNullOrEmpty(expr) == true)
            {
                Console.WriteLine("Введите корректное выражение!");
                return true;
            }
            //Проверка на валидность введенных символов 

            if (Regex.Match(expr, "[!|@|#|$|%|^|&|№|;|:|?|,|.|<|>|'|`|~|}|{|_]").Success)
            {
                Console.WriteLine("Введите корректное выражение!");
                return true;
            }


            if ((expr[0] == '/') || (expr[0] == '*') || (expr[0] == '+') || (expr[0] == ')'))
            {
                error = true;
                Console.WriteLine("Введите корректное выражение!");
                return true;
            }


            if ((expr[Number] == '*') || (expr[Number] == '/') || (expr[Number] == '+') || (expr[Number] == '-'))
                error = true;

            for (var i = 0; ((i < expr.Length) && (error == false)); i++)
            {
                if (expr[i] == '"')
                {
                    error = true;
                    Console.WriteLine("Введите корректное выражение!");
                    return true;
                }
                if (expr[i] == '(')
                    BracketLeft++;

                if (expr[i] == ')')
                    BracketRight++;

                if ((i >= 0) && (i < Number))
                    if ((expr[i] == '0') && (expr[i + 1] == '/') && (i < expr.Length - 1))
                        error = true;
                //Много знаков подряд
                if ((i < expr.Length) && ((expr[i] == '*') || (expr[i] == '/') || (expr[i] == '+') || (expr[i] == '-'))
                    && ((expr[i + 1] == '*') || (expr[i + 1] == '/') || (expr[i + 1] == '-') || (expr[i + 1] == '+')))
                    error = true;

                //После ( проверка записи
                if (((expr[i] == '(') && (i >= 0)) && ((expr[i + 1] == '/') || (expr[i + 1] == '+') || (expr[i + 1] == '*')))
                    error = true;

                ///Перед ) проверка записи
                if (((expr[i] == ')') && (i > 0)) && ((expr[i - 1] == '/') || (expr[i - 1] == '+') || (expr[i - 1] == '*') || (expr[i - 1] == '-')))
                    error = true;

                //Перед ( проверка записи
                if ((expr[i] == '(') && (i > 0))
                    if (expr[i - 1] == '(') { }
                    else
                        if ((expr[i - 1] == '/') || (expr[i - 1] == '+') || (expr[i - 1] == '*') || (expr[i - 1] == '-')) { }
                        else
                            error = true;


                if ((expr[i] == ')') && (i > 0) && (i < expr.Length - 1))
                    if (expr[i + 1] == ')') { }
                    else
                        if ((expr[i + 1] == '/') || (expr[i + 1] == '+') || (expr[i + 1] == '*') || (expr[i + 1] == '-')) { }
                        else
                            error = true;

                if ((expr[i] == '(') && (expr[i + 1] == '-'))
                {
                    expr = expr.Insert(i + 1, "0");

                }
            }



            if ((error == true) || (Regex.Match(expr, "[a-zA-Z]").Success) || (Regex.Match(expr, "[а-яА-ЯёЁ]").Success)
                || (BracketLeft != BracketRight) || (!Regex.Match(expr, "[0-9]").Success))
            {
                Console.WriteLine("Введите корректное выражение!");
                error = false;
                return true;
            }

            if (expr[0] == '-')
                Console.WriteLine(Calculator.Calculate("0" + expr));
            else
                Console.WriteLine(Calculator.Calculate(expr));

            return false;
        }
    }
}
