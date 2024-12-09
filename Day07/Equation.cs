using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Day07
{
    public class Equation
    {
        double answer;
        double[] numberSequence;
        string[] operators;
        public List<double> results;
        public double trueExpression;

        public Equation(double answer, double[] numberSequence, string[] operators) { 
            this.answer = answer;
            this.numberSequence = numberSequence;
            this.operators = operators;
            this.results = new List<double>();
        }

        public bool Evaluate()
        {
            this.Generate(numberSequence[0].ToString());
            trueExpression = results.FirstOrDefault(val => val == answer);

            return trueExpression != default;
        }

        private void Generate(string currentEquation, int index = 0)
        {
            if (index == numberSequence.Length - 1)
            {
                results.Add(double.Parse(currentEquation));
                return;
            }

            foreach (string op in this.operators) {
                string newExpression = "";

                if(op == "||")
                {
                    newExpression = Concat($"{currentEquation} {op} {numberSequence[index + 1]}");
                }
                else
                {
                    // the .0 forces dataTable to recognize it as double rather than int which can cause an OverflowException
                    newExpression = EvaluateEquation($"{currentEquation}.0 {op} {numberSequence[index + 1]}.0");
                }


                this.Generate(newExpression, index + 1);
            }
        }

        static string EvaluateEquation(string expression)
        {
            DataTable dataTable = new DataTable();
            return Convert.ToInt64(dataTable.Compute(expression, string.Empty)).ToString();
        }

        static string Concat(string expression)
        {
            return String.Join("", expression.Split(" || "));
        }
    }
}
