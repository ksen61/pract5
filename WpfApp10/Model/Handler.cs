using System.Collections.Generic;
using System;
using System.Data;
using System.Linq;
using WpfApp10.ViewModel.Helpers;

namespace WpfApp10.Model
{
    internal class Handler : Prompter
    {
        private static Handler example = new Handler();
        private string text;
        private DataTable table;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                Changed();
            }
        }

        public DataTable Table
        {
            get { return table; }
            set
            {
                table = value;
                Changed();
            }
        }

        public DataTable SetTable()
        {
            string term = Text.Replace(" ", "");
            List<string> variables = GetVariables(term);
            if (variables.Count < 2)
            {
                return null;
            }
            string term1 = ConvertTerm(term);
            Table = GenerateTable(variables, term1);
            SaveExample(Text, Table);
            return Table;
        }

        public void SaveExample(string text, DataTable dataTable)
        {
            example.Text = text;
            example.Table = dataTable;
        }

        public Handler GetExample()
        {
            return example;
        }

        private List<string> GetVariables(string term)
        {
            List<string> variables = new List<string>();

            IEnumerable<char> chars = term.Distinct();

            foreach (char c in chars)
            {
                if (char.IsLetter(c))
                {
                    variables.Add(c.ToString());
                }
            }

            return variables;
        }

        private string ConvertTerm(string term)
        {
            char[] signs = SignTerm(term);
            List<char> outputList = new List<char>();
            Stack<char> operators = new Stack<char>();

            foreach (char sign in signs)
            {
                if (Operands(sign))
                {
                    outputList.Add(sign);
                }
                else if (PrefixFunction(sign))
                {
                    operators.Push(sign);
                }
                else if (sign == '(')
                {
                    operators.Push(sign);
                }
                else if (sign == ')')
                {
                    while (operators.Count > 0 && operators.Peek() != '(')
                    {
                        outputList.Add(operators.Pop());
                    }

                    operators.Pop();

                    if (operators.Count > 0 && PrefixFunction(operators.Peek()))
                    {
                        outputList.Add(operators.Pop());
                    }
                }
                else if (BinaryOperator(sign))
                {
                    while (operators.Count > 0 &&
                           (PrefixFunction(operators.Peek()) ||
                            OperatorPrecedence(sign) <= OperatorPrecedence(operators.Peek()) ||
                            (LeftAssociative(sign) && OperatorPrecedence(sign) == OperatorPrecedence(operators.Peek()))))
                    {
                        outputList.Add(operators.Pop());
                    }

                    operators.Push(sign);
                }
            }

            while (operators.Count > 0)
            {
                outputList.Add(operators.Pop());
            }

            return string.Join(" ", outputList);
        }

        private char[] SignTerm(string term)
        {
            List<char> signs = new List<char>();
            int i = 0;

            while (i < term.Length)
            {
                if (Operators(term[i]))
                {
                    signs.Add(term[i]);
                    i++;
                }
                else if (Operands(term[i]))
                {
                    char operand = term[i];

                    while (i + 1 < term.Length && Operands(term[i + 1]))
                    {
                        operand += term[i + 1];
                        i++;
                    }

                    signs.Add(operand);
                    i++;
                }
                else if (term[i] == '(' || term[i] == ')')
                {
                    signs.Add(term[i]);
                    i++;
                }
            }

            return signs.ToArray();
        }

        private bool Operands(char sign)
        {
            return !Operators(sign) && sign != '(' && sign != ')' && char.IsLetter(sign);
        }

        private bool Operators(char sign)
        {
            return sign == '¬' || sign == '∧' || sign == '∨' || sign == '⊕' ||
                   sign == '↑' || sign == '↓' || sign == '↔' || sign == '→';
        }

        private bool PrefixFunction(char sign)
        {
            return sign == '¬';
        }

        private bool BinaryOperator(char sign)
        {
            return sign == '∧' || sign == '∨' || sign == '⊕' || sign == '↑' ||
                   sign == '↓' || sign == '↔' || sign == '→';
        }

        private int OperatorPrecedence(char sign)
        {
            switch (sign)
            {
                case '¬':
                    return 4;
                case '∧':
                    return 3;
                case '∨':
                    return 2;
                case '⊕':
                case '↑':
                case '↓':
                case '↔':
                case '→':
                    return 1;
                default:
                    return 0;
            }
        }

        private bool LeftAssociative(char sign)
        {
            return true;
        }

        private DataTable GenerateTable(List<string> variables, string term)
        {
            int rowCount = (int)Math.Pow(2, variables.Count);
            DataTable truthTable = new DataTable();

            foreach (string variable in variables)
            {
                truthTable.Columns.Add(variable);
            }

            truthTable.Columns.Add(term, typeof(bool));

            List<List<bool>> variableValues = new List<List<bool>>();

            for (int i = 0; i < rowCount; i++)
            {
                List<bool> values = new List<bool>();

                string binary = Convert.ToString(i, 2).PadLeft(variables.Count, '0');

                foreach (char bit in binary)
                {
                    bool value = bit == '1';
                    values.Add(value);
                }

                variableValues.Add(values);
            }

            foreach (List<bool> values in variableValues)
            {
                DataRow row = truthTable.NewRow();

                for (int i = 0; i < variables.Count; i++)
                {
                    row[i] = values[i];
                }

                bool result = EvaluateTerm(term, values, variables);
                row[term] = result;

                truthTable.Rows.Add(row);
            }

            return truthTable;
        }

        private bool EvaluateTerm(string term, List<bool> variableValues, List<string> variables)
        {
            Stack<bool> stack = new Stack<bool>();

            foreach (char sign in term)
            {
                if (Operands(sign))
                {
                    int variableIndex = variables.IndexOf(sign.ToString());
                    bool value = variableValues[variableIndex];
                    stack.Push(value);
                }
                else if (Operators(sign))
                {
                    if (sign == '¬')
                    {
                        bool operand = stack.Pop();
                        bool result = ApplyOperator(sign, operand);
                        stack.Push(result);
                    }
                    else
                    {
                        bool operand2 = stack.Pop();
                        bool operand1 = stack.Pop();
                        bool result = ApplyOperator(sign, operand1, operand2);
                        stack.Push(result);
                    }
                }
            }

            return stack.Pop();
        }

        private bool ApplyOperator(char sign, bool operand1, bool operand2 = false)
        {
            switch (sign)
            {
                case '∧':
                    return operand1 && operand2;
                case '∨':
                    return operand1 || operand2;
                case '⊕':
                    return operand1 ^ operand2;
                case '↑':
                    return !operand1 || !operand2;
                case '↓':
                    return !operand1 && !operand2;
                case '↔':
                    return operand1 == operand2;
                case '→':
                    return !operand1 || operand2;
                case '¬':
                    return !operand1;
                default:
                    throw new ArgumentException("Неверный оператор: " + sign);
            }
        }
    }
}
