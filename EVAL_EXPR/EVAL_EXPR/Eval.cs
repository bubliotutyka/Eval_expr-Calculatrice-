﻿using System;
using System.Collections.Generic;

namespace EVAL_EXPR
{
    class Eval
    {
        static void Main()
        {
            Eval eval = new Eval();
            eval.init();
        }

        //private string exprStr = "3+2*15-10"; // = 23
        //private string exprStr = "3+2*(15-10)+10"; // = 23
        //private string exprStr = "3+2*(15-(10+3)*4)+(10-4)*2"; // = -59 (89)
        //private string exprStr = "2+3*4-5+7*6/3-2*3*2+(2+3*4-5+7*6/3-2*3*2+(5-2)*2)*2";
        //private string exprStr = "(3+(4*(5/6-10)))";
        private string exprStr = "(((((42)))))";

        private List<string> rpnArray = new List<string>();
        private List<string> operatorArray = new List<string>();
        private int result { get; set; }

        public void init()
        {
            //this.restart();
            this.parseExprToRpn();
            this.calcRpn();
            Console.Read();
        }

        public void restart()
        {
            Console.Write("Expr: ");
            this.exprStr = Console.ReadLine();

            this.parseExprToRpn();
            this.calcRpn();

            Console.Write("restart: (y/n)  ");
            string restart = Console.ReadLine();

            if (restart == "y")
                this.restart();
            
           Console.Read();
        }

        private void parseExprToRpn()
        {
            int i = 0;

            while (this.exprStr.Length > i)
            {
                if (Char.IsNumber(this.exprStr[i]))
                {
                    string number = this.exprStr[i].ToString();

                    if (i + 1 < this.exprStr.Length)
                    {
                        while (i + 1 < this.exprStr.Length && Char.IsNumber(this.exprStr[i + 1]))
                        {
                            ++i;
                            number += this.exprStr[i].ToString();
                        }
                    }

                    this.rpnArray.Add(number);
                }
                else if (MyFunction.isOperator(this.exprStr[i].ToString()))
                {
                    if (this.operatorArray.Count > 0)
                    {
                        int lastIndex = this.operatorArray.Count - 1;
                        string lastOperator = this.operatorArray[lastIndex];
                        string newOperator = this.exprStr[i].ToString();

                        while ((!MyFunction.operatorPriority(lastOperator, newOperator) || MyFunction.sameOperatorPriority(lastOperator, newOperator)) && lastOperator != "(")
                        {
                            this.rpnArray.Add(lastOperator);
                            this.operatorArray = MyFunction.removeLastIndex(this.operatorArray);

                            if (this.operatorArray.Count > 0)
                            {
                                lastIndex = this.operatorArray.Count - 1;
                                lastOperator = this.operatorArray[lastIndex];
                            }
                            else
                            {
                                lastOperator = "(";
                            }
                        }

                    }

                    this.operatorArray.Add(this.exprStr[i].ToString());
                }
                else if (this.exprStr[i] == '(')
                {
                    this.operatorArray.Add(this.exprStr[i].ToString());
                }
                else if (this.exprStr[i] == ')')
                {
                    int lastIndex = this.operatorArray.Count - 1;
                    string lastOperator = this.operatorArray[lastIndex];
                    string newOperator = this.exprStr[i].ToString();

                    while (lastOperator != "(")
                    {
                        this.rpnArray.Add(lastOperator);
                        this.operatorArray = MyFunction.removeLastIndex(this.operatorArray);
                        
                        if (this.operatorArray.Count > 0)
                        {
                            lastIndex = this.operatorArray.Count - 1;
                            lastOperator = this.operatorArray[lastIndex];
                        }
                        else
                        {
                            lastOperator = "(";
                        }
                    }
                    this.operatorArray = MyFunction.removeLastIndex(this.operatorArray);
                }
                ++i;
            }

            while (this.operatorArray.Count > 0)
            {
                this.rpnArray.Add(this.operatorArray[this.operatorArray.Count - 1]);
                this.operatorArray = MyFunction.removeLastIndex(this.operatorArray);
            }
        }

        private void calcRpn()
        {
            Rpn rpn = new Rpn();
            int result = rpn.calc(this.rpnArray);

            Console.WriteLine(result.ToString());
        }
    }
}
