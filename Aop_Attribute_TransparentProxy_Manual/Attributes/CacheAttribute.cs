using Aop_Attribute_TransparentProxy_Manual.BaseClasses;
using Aop_Attribute_TransparentProxy_Manual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aop_Attribute_TransparentProxy_Manual.Attributes
{
    public class CacheAttribute : AspectBase, IBefore, IAfterVoid
    {
        public int CacheDuration { get; set; }

        public object OnBefore()
        {
            string cacheKey = string.Format("Cache_{0}_{1}", AspectContext.Instance.MethodName, string.Join("_", AspectContext.Instance.Arguments));
            Console.WriteLine("On Before Caching");
            //Check the cache. if the value exist, you can return 
            //or collect data and after return.
            return true;
        }

        public void OnAfter(object value)
        {
            string cacheKey = string.Format("Cache_{0}_{1}", AspectContext.Instance.MethodName, string.Join("_", AspectContext.Instance.Arguments));
            Console.WriteLine("On After Caching");
            //Insert or Update cache value

        }
    }
}
