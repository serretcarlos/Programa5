using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa5
{
    //&p-Programa4
    //&b=28
    class Program
    {
        //&i
        static void Main(string[] args)
        {
            double dp; //added
            double dof;
            double x;
            dof = 0;
            x = 1;
            dp = 0;  //added
            try
            {
                //&d=1
                dp = double.Parse(Console.ReadLine());  //added
                dof = double.Parse(Console.ReadLine());
                double num_seg;
                //&d=1
                num_seg = 10;

                //&d=3
                Simpson simpson = new Simpson(x, dof, num_seg); //&m
                double CorrigeX = simpson.FuncionP() - dp;
                double correccion = 0.5;
                num_seg = 1000; // added
                char changesimbol = '-';

                //d=4
                if (simpson.FuncionP() != dp)
                {
                    if (CorrigeX > 0)
                    {
                        x -= correccion;
                        changesimbol = 'p';
                    }
                    else if (CorrigeX < 0)
                    {
                        x += correccion;
                        changesimbol = 'n';
                    }
                    simpson = new Simpson(x, dof, num_seg);
                    CorrigeX = simpson.FuncionP() - dp;
                }
                do
                {
                    if (CorrigeX > 0)
                    {
                        if (changesimbol == 'n')
                        {
                            correccion /= 2;
                            changesimbol = 'p';
                        }
                        x -= correccion;
                    }
                    else if (CorrigeX < 0)
                    {
                        if (changesimbol == 'p')
                        {
                            correccion /= 2;
                            changesimbol = 'n';
                        }
                        x += correccion;
                    }
                    simpson = new Simpson(x, dof, num_seg);
                    CorrigeX = simpson.FuncionP() - dp;
                }
                while (Math.Abs(CorrigeX) > 0.0000001); //&m

                Console.WriteLine("p = " + dp.ToString("N5") + "\ndof = " + dof + "\nx = " + x.ToString("N5"));  //&m
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
    }
}
