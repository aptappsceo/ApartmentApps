using System.Reflection;

namespace ApartmentApps.Forms
{
    public interface IFormProvider
    {
        FormModel CreateFormFor(object model);
        //FormModel CreateFormForMethod(MethodInfo methodInfo);
    }
}