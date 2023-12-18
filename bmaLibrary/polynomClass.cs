using bmaLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace bmaLibrary
{
    // Класс для представления многочленов над полем GF(2)
    
    public class Polynomial
    {
        public bool[] Coefficients { get; private set; }

        public int Degree
        {
            get
            {
                for (int i = Coefficients.Length - 1; i >= 0; i--)
                {
                    if (Coefficients[i])
                        return i;
                }
                return 0;
            }
        }

        public Polynomial(bool[] coefficients)
        {
            Coefficients = new bool[coefficients.Length];
            Array.Copy(coefficients, Coefficients, coefficients.Length);
        }

        public Polynomial(bool[] coefficients, string state)
        {
            Coefficients = new bool[Math.Max(coefficients.Length, state.Length)];
            for (int i = 0; i < coefficients.Length; i++)
            {
                Coefficients[i] = coefficients[i];
            }

        }

        public Polynomial(int degree)
        {
            Coefficients = new bool[degree+1];
            Coefficients[degree] = false;
            
        }

        public Polynomial(string input)
        {
            string[] terms = input.Split('+');
            int maxDegree = terms.Select(t => t.Contains('^') ? int.Parse(t.Split('^')[1]) : 0).Max();
            Coefficients = new bool[maxDegree + 1];
            

            foreach (string term in terms)
            {
                if (term.StartsWith("x^"))
                {
                    int degree = int.Parse(term.Split('^')[1]);
                    Coefficients[degree] ^= true;
                }
                if (term.StartsWith("1"))
                    Coefficients[0] = true;
            }
            if (Degree == 0)
                throw new ArgumentException("Enter valid polynomial");
        }

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            int maxDegree = Math.Max(p1.Degree, p2.Degree);
            bool[] resultCoefficients = new bool[maxDegree + 1];
            

            for (int i = 0; i <= maxDegree; i++)
            {
                bool c1 = i <= p1.Degree ? p1.Coefficients[i] : false;
                bool c2 = i <= p2.Degree ? p2.Coefficients[i] : false;
                resultCoefficients[i] ^= c1 ^ c2;
            }
            return new Polynomial(resultCoefficients);
        }


        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            int resultDegree = p1.Degree + p2.Degree;
            bool[] resultCoefficients = new bool[resultDegree + 1];

            for (int i = 0; i <= p1.Degree; i++)
            {
                for (int j = 0; j <= p2.Degree; j++)
                {
                    if (p1.Coefficients[i] && p2.Coefficients[j])
                    {
                        resultCoefficients[i + j] ^= true;
                    }
                }
            }

            return new Polynomial(resultCoefficients);
        }

        public Polynomial Shift(int deg)
        {
            int resultDegree = Degree + deg;
            bool[] resultCoefficients = new bool[resultDegree + 1];

            for (int i = 0; i <= Degree; i++)
            {
                if (i + deg <= resultDegree)
                {
                    resultCoefficients[i + deg] = Coefficients[i];
                }
            }
            
            return new Polynomial(resultCoefficients);
        }
        public static Polynomial operator /(Polynomial dividend, Polynomial divisor)
        {
            if (divisor.IsZero())
            {
                throw new DivideByZeroException("Cannot divide by zero polynomial");
            }

            Polynomial remainder = new Polynomial(dividend.Coefficients);
            int quotientDegree = dividend.Degree - divisor.Degree;

            if (quotientDegree < 0)
            {
                return new Polynomial(new bool[0]);
            }

            bool[] quotientCoefficients = new bool[quotientDegree + 1];

            for (int i = quotientDegree; i >= 0; i--)
            {
                if (remainder.Coefficients[remainder.Degree])
                {
                    quotientCoefficients[i] = true;
                    remainder = remainder + (divisor * new Polynomial(i));
                }
            }

            return new Polynomial(quotientCoefficients);
        }

        public void Expand(int L)
        {
            
            bool[] resultCoefficients = new bool[L+1];
            Array.Copy(this.Coefficients, resultCoefficients, this.Coefficients.Length);
            this.Coefficients = resultCoefficients;
        }

        public override string ToString()
        {
            if (IsZero())
            {
                return "0";
            }

            List<string> terms = new List<string>();
            

            for (int i = Coefficients.Length - 1; i >= 0; i--)
            {
                if (Coefficients[i])
                {
                    if (i == 0)
                    {
                        terms.Add("1");
                    }
                    else
                    {
                        terms.Add($"x^{i}");
                    }
                }
            }

            return string.Join("+", terms);
        }

        public bool IsZero()
        {
            return Coefficients.All(c => !c);
        }
    }


}
