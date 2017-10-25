using Aop_Attribute_TransparentProxy_Manual.Attributes;

namespace Aop_Attribute_TransparentProxy_Manual
{
    public class Student : IStudent
    {
        [Log]
        [Cache(CacheDuration = 10)]
        public string RegisterToLesson(string lessonName)
        {
            return string.Format("Lesson Registration Info : {0}", lessonName);
        }

    }
}
