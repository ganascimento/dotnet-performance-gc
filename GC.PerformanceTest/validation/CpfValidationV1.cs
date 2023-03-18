using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.PerformanceTest.validation
{
    public static class CpfValidationV1
    {
        public static bool ValidCpf(string cpf)
        {
            if (String.IsNullOrEmpty(cpf))
                return false;

            string clearCpf;
            clearCpf = cpf.Trim();
            clearCpf = clearCpf.Replace(".", "");
            clearCpf = clearCpf.Replace("-", "");

            if (clearCpf.Length != 11)
                return false;

            int[] cpfArray;
            int totalDigI = 0;
            int totalDigII = 0;
            int modI;
            int modII;

            switch (cpf)
            {
                case "00000000000":
                case "11111111111":
                case "22222222222":
                case "33333333333":
                case "44444444444":
                case "55555555555":
                case "66666666666":
                case "77777777777":
                case "88888888888":
                case "99999999999":
                    return false;
            }

            foreach (char c in clearCpf)
            {
                if (!char.IsNumber(c))
                    return false;
            }

            cpfArray = new int[11];
            for (int i = 0; i < 11; i++)
            {
                cpfArray[i] = int.Parse(clearCpf[i].ToString());
            }

            for (int position = 0; position < cpfArray.Length - 2; position++)
            {
                totalDigI += cpfArray[position] * (10 - position);
                totalDigII += cpfArray[position] * (11 - position);
            }

            modI = totalDigI % 11;
            if (modI < 2) modI = 0;
            else modI = 11 - modI;

            if (cpfArray[9] != modI)
                return false;

            totalDigII += modI * 2;

            modII = totalDigII % 11;
            if (modII < 2) modII = 0;
            else modII = 11 - modII;

            if (cpfArray[10] != modII)
                return false;

            return true;
        }
    }
}
