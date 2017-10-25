namespace Aop_Attribute_TransparentProxy_Manual.Interfaces
{
    //IBeforeVoid runs before method executes and doesnt return any value
    public interface IBeforeVoid : IAspect
    {
        void OnBefore();
    }
}
