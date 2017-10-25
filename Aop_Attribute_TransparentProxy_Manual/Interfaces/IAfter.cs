namespace Aop_Attribute_TransparentProxy_Manual.Interfaces
{
    //AFTER
    //IAfter runs after method executes and returns a value
    public interface IAfter : IAspect
    {
        object OnAfter(object value);
    }
}
