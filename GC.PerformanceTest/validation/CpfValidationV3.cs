using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.PerformanceTest.validation
{
    public static class CpfValidationV3
    {
        public struct Cpf
        {
            private readonly string _value;
            public readonly bool IsValid;

            private Cpf(string value)
            {
                _value = value;

                if (value == null)
                {
                    IsValid = false;
                    return;
                }

                var position = 0;
                var totalDigI = 0;
                var totalDigII = 0;
                var dv1 = 0;
                var dv2 = 0;
                bool isEquals = true;
                var lastDigit = -1;


                foreach (var c in value)
                {
                    if (char.IsDigit(c))
                    {
                        var digit = c - '0';
                        if (position != 0 && lastDigit != digit)
                            isEquals = false;

                        lastDigit = digit;

                        if (position < 9)
                        {
                            totalDigI += digit * (10 - position);
                            totalDigII += digit * (11 - position);
                        }
                        else if (position == 9)
                            dv1 = digit;
                        else if (position == 10)
                            dv2 = digit;

                        position++;
                    }
                }

                if (position > 11 || isEquals)
                {
                    IsValid = false;
                    return;
                }

                var modI = totalDigI % 11;
                modI = modI < 2 ? 0 : 11 - modI;

                if (dv1 != modI)
                {
                    IsValid = false;
                    return;
                }

                totalDigII += modI * 2;
                var modII = totalDigII % 11;
                modII = modII < 2 ? 0 : 11 - modII;

                IsValid = dv2 == modII;
            }

            public static implicit operator Cpf(string value) => new Cpf(value);

            public override string ToString() => _value;
        }

        public static bool ValidCpf(string cpf) => ((Cpf)cpf).IsValid;
    }
}
