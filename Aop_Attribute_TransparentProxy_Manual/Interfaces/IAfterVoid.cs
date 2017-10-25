namespace Aop_Attribute_TransparentProxy_Manual.Interfaces
{
    //IAfterVoid runs after method executes and doesnt return any value
    public interface IAfterVoid : IAspect
    {
        void OnAfter(object value);
    }
}
