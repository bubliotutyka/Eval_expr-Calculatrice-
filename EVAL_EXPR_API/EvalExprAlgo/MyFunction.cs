using System;
using System.Collections.Generic;

namespace EvalExprAlgo
{
    public class MyFunction
    {
        static public bool isOperator(string oper)
        {
            if (oper == "+" || oper == "-" || oper == "*" || oper == "/" || oper == "%")
                return true;
            return false;
        }

        static public bool operatorPriority(string lastOperator, string newOperator)
        {
            if ((lastOperator == "+" || lastOperator == "-") && (newOperator == "*" || newOperator == "/" || newOperator == "%"))
                return true;
            return false;
        }

        static public bool sameOperatorPriority(string lastOperator, string newOperator)
        {
            if ((lastOperator == "+" && lastOperator == "-") && (newOperator == "+" && lastOperator == "-"))
                return true;
            else if ((lastOperator == "*" || lastOperator == "/" || lastOperator == "%") && (newOperator == "*" || newOperator == "/" || newOperator == "%"))
                return true;
            return false;
        }

        static public List<string> removeLastIndex(List<string> array)
        {
            List<string> newList = new List<string>();
            int i = 0;

            while (i < array.Count - 1)
            {
                newList.Add(array[i]);
                ++i;
            }

            return newList;
        }
    }
}
