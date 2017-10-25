using Aop_Attribute_TransparentProxy_Manual.BaseClasses;
using Aop_Attribute_TransparentProxy_Manual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aop_Attribute_TransparentProxy_Manual.Attributes
{
    public class LogAttribute : AspectBase, IBeforeVoid, IAfterVoid
    {
        public void OnBefore()
        {
            Console.WriteLine(string.Format("Methods: {0}", AspectContext.Instance.MethodName));
            Console.WriteLine(string.Format("Args: {0}", string.Join(",", AspectContext.Instance.Arguments)));
        }

        public void OnAfter(object value)
        {
            Console.WriteLine("On After Logging...");
        }
    }
}
