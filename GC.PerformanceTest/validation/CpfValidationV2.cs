using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.PerformanceTest.validation
{
    public static class CpfValidationV2
    {
        public static bool ValidCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            string clearCpf = cpf.Trim();
            clearCpf = clearCpf.Replace(".", "");
            clearCpf = clearCpf.Replace("-", "");

            if (clearCpf.Length != 11)
                return false;

            var totalDigI = 0;
            var totalDigII = 0;

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

            for (int position = 0; position < clearCpf.Length - 2; position++)
            {
                totalDigI += (clearCpf[position] - '0') * (10 - position);
                totalDigII += (clearCpf[position] - '0') * (11 - position);

                /*
                    To example, do:
                    Console.WriteLine('3'.GetType());
                    Console.WriteLine(('3' - '0').GetType());
                 */
            }

            var modI = totalDigI % 11;
            if (modI < 2) modI = 0;
            else modI = 11 - modI;

            if ((clearCpf[9] - '0') != modI)
                return false;

            totalDigII += modI * 2;

            var modII = totalDigII % 11;
            if (modII < 2) modII = 0;
            else modII = 11 - modII;

            if ((clearCpf[10] - '0') != modII)
                return false;

            return true;
        }
    }
}
