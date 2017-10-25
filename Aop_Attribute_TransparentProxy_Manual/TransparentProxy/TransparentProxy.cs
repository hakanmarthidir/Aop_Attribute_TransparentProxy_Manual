using Aop_Attribute_TransparentProxy_Manual.BaseClasses;
using Aop_Attribute_TransparentProxy_Manual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace Aop_Attribute_TransparentProxy_Manual.TransparentProxy
{
    //quotation
    public class TransparentProxy<T, TI> : RealProxy where T : TI, new() 
    {
        private TransparentProxy(): base(typeof(TI)) 
        { }
        
        public static TI GenerateProxy()
        {
            var instance = new TransparentProxy<T, TI>();
            return (TI)instance.GetTransparentProxy();
        }
        
        public override IMessage Invoke(IMessage msg)
        {
            var methodCallMessage = msg as IMethodCallMessage;
            ReturnMessage returnMessage = null;

            try
            {
                
                var realType = typeof(T);
                var mInfo = realType.GetMethod(methodCallMessage.MethodName);
                var aspects = mInfo.GetCustomAttributes(typeof(IAspect), true);                
                FillAspectContext(methodCallMessage);
                object response = null;                
                CheckBeforeAspect(response, aspects);
                object result = null;                
                if (response != null)
                {
                    returnMessage = new ReturnMessage(response, null, 0, methodCallMessage.LogicalCallContext, methodCallMessage);
                }
                else
                {                    
                    result = methodCallMessage.MethodBase.Invoke(new T(), methodCallMessage.InArgs);
                    returnMessage = new ReturnMessage(result, null, 0, methodCallMessage.LogicalCallContext, methodCallMessage);
                }
                CheckAfterAspect(result, aspects);                
                return returnMessage;
            }
            catch (Exception ex)
            {
                return new ReturnMessage(ex, methodCallMessage);
            }
        }

        private void FillAspectContext(IMethodCallMessage methodCallMessage)
        {
            AspectContext.Instance.MethodName = methodCallMessage.MethodName;
            AspectContext.Instance.Arguments = methodCallMessage.InArgs;
        }

        private void CheckBeforeAspect(object response, object[] aspects)
        {
            foreach (IAspect loopAttribute in aspects)
            {
                if (loopAttribute is IBeforeVoid)
                {
                    ((IBeforeVoid)loopAttribute).OnBefore();
                }
                else if (loopAttribute is IBefore)
                {
                    response = ((IBefore)loopAttribute).OnBefore();
                }
            }
        }

        private void CheckAfterAspect(object result, object[] aspects)
        {
            foreach (IAspect loopAttribute in aspects)
            {
                if (loopAttribute is IAfterVoid)
                {
                    ((IAfterVoid)loopAttribute).OnAfter(result);
                }
            }
        }       
    }
}
