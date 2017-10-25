namespace Aop_Attribute_TransparentProxy_Manual.Interfaces
{
    //BEFORE
    //IBefore runs before method executes and returns a value
    interface IBefore : IAspect
    {
        object OnBefore();
    }
}
