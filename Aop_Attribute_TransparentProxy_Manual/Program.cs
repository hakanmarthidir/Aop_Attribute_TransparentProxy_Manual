using Aop_Attribute_TransparentProxy_Manual.TransparentProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aop_Attribute_TransparentProxy_Manual
{
    class Program
    {
        static void Main(string[] args)
        {               
            //transparent proxy class for intercepting
            var s = TransparentProxy<Student, IStudent>.GenerateProxy();
            var text = s.RegisterToLesson("Math");
            Console.WriteLine(text);
            Console.ReadKey();
        }
    }
}
