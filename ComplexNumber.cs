using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpe
{
    public class ComplexNumber
    {
        public double real;
        public double imaginary;

        public ComplexNumber()
        {
            real = 0.0;
            imaginary = 0.0;
        }

        public static ComplexNumber operator +(ComplexNumber A, Number B)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.real = A.real + B.real;
            cn.imaginary = A.imaginary + B.imaginary;
            return cn;
        }

        public static ComplexNumber operator -(ComplexNumber A, Number B)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.real = A.real - B.real;
            cn.imaginary = A.imaginary - B.imaginary;
            return cn;
        }

        public static ComplexNumber operator *(ComplexNumber A, Number B)
        {
            ComplexNumber cn = new ComplexNumber();
            cn.real = A.real * B.real;
            cn.imaginary = A.imaginary * B.imaginary;
            return cn;
        }

        public static ComplexNumber operator /(ComplexNumber A, Number B)
        {
            if ((B.real == 0) || (B.imaginary == 0))
            {
                throw new DivideByZeroException();
            }
            ComplexNumber cn = new ComplexNumber();
            cn.real = A.real / B.real;
            cn.imaginary = A.imaginary / B.imaginary;
            return cn;
        }

        public new String ToString()
        {
            StringBuilder complex = new StringBuilder();
            complex.Append(real.ToString());
            complex.Append(this.imaginary >= 0.0 ? "+" : "");
            complex.Append(imaginary.ToString());
            complex.Append("i");
            return complex.ToString();
        }
    }
}
