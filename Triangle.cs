using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
  
public class Triangle
{
    public double a;
    public double b;
    public double c;
    public Triangle(double A, double B, double C)
    {
        a = A;
        b = B;
        c = C;
    }
    public string outputA()
    {
        return Convert.ToString(a);
    }
    public string outputB()
    {
        return Convert.ToString(b);
    }
    public string outputC()
    {
        return Convert.ToString(c);
    }
    public double Perimeter()
    {
        double p = 0;
        p = a + b + c;
        return p;
    }
    public double Surface()
    {
        //double s = 0;
        double p = 0;
        p = (a + b + c) / 2;
        //s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
        return Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
    }
    public double Height()
    {
        double s = Surface();
        double h = 2 * s / a;
        return h;
    }
    public double Median()
    {
        double m = a / 2;
        return m;
    }
    public double GetSetA
    {
        get { return a; }
        set { a = value; }
    }
    public double GetSetB
    {
        get { return b; }
        set { b = value; }
    }
    public double GetSetC
    {
        get { return c; }
        set {c = value; }
    }
    public double GetKolm()
    {
        double c = Math.Sqrt(a * a + b * b);
        return c;
    }
    public bool ExistTriangle
    {
        get
        {
            if ((a + b < c) && (a + c < b) && (b + c < a))
                return false;
                else return true;
        }
    }
    public string CheckTriangleType()
    {
        if (ExistTriangle)
        {
            if (a == b && b == c)
            {
                return "Võrdkülgne kolmnurk";
            }
            else if (a == b || b == c || a == c)
            {
                if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) ||
                    Math.Pow(b, 2) + Math.Pow(c, 2) == Math.Pow(a, 2) ||
                    Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2))
                {
                    return "Võrdhaarne täisnurkne kolmnurk";
                }
                return "Võrdhaarne kolmnurk";
            }
            else
            {
                if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) ||
                    Math.Pow(b, 2) + Math.Pow(c, 2) == Math.Pow(a, 2) ||
                    Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2))
                {
                    return "Skaleeni täisnurkne kolmnurk";
                }
                return "Skaleeni kolmnurk";
            }
        }
        else
        {
            return "Kehtetu kolmnurk";
        }
    }
}     