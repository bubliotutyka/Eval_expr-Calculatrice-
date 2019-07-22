using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVAL_EXPR
{
    class Rpn
    {
        List<string> rpnArr;

        public int calc(List<string> rpnArr)
        {
            this.rpnArr = rpnArr;
            int i = 0;

            while (this.rpnArr.Count > 1)
            {
                int nbr1;
                int nbr2;

                if (int.TryParse(this.rpnArr[i], out nbr1) && int.TryParse(this.rpnArr[i + 1], out nbr2) && !int.TryParse(this.rpnArr[i + 2], out int nbr3))
                {
                    string oper = this.rpnArr[i + 2];

                    if (oper == "+")
                        this.add(nbr1, nbr2, i);
                    else if (oper == "-")
                        this.remove(nbr1, nbr2, i);
                    else if (oper == "*")
                        this.multiply(nbr1, nbr2, i);
                    else if (oper == "/")
                        this.division(nbr1, nbr2, i);
                    else if (oper == "%")
                        this.modulo(nbr1, nbr2, i);
                    i = 0;
                }
                else
                    ++i;
            }

            return Convert.ToInt32(this.rpnArr[0]);
        }

        private void add(int nbr1, int nbr2, int i)
        {
            this.updateRpnArr(nbr1 + nbr2, i);
        }

        private void remove(int nbr1, int nbr2, int i)
        {
            this.updateRpnArr(nbr1 - nbr2, i);
        }

        private void multiply(int nbr1, int nbr2, int i)
        {
            this.updateRpnArr(nbr1 * nbr2, i);
        }

        private void division(int nbr1, int nbr2, int i)
        {
            if (nbr2 == 0)
                this.updateRpnArr(int.MaxValue, i);
            else
                this.updateRpnArr(nbr1 / nbr2, i);
        }

        private void modulo(int nbr1, int nbr2, int i)
        {
            while (nbr1 >= nbr2)
            {
                nbr1 = nbr1 - nbr2;
            }
            this.updateRpnArr(nbr1, i);
        }

        private void updateRpnArr(int nbr, int index)
        {
            List<string> updatedRpnArr = new List<string>();

            for (int i = 0; this.rpnArr.Count > i; ++i)
            {
                if (i < index || i > index + 2)
                    updatedRpnArr.Add(this.rpnArr[i]);
                else if (i == index)
                    updatedRpnArr.Add(nbr.ToString());
            }

            this.rpnArr = updatedRpnArr;
        }
    }
}
