using Ninject;

namespace ApartmentApps.Tests
{
    public class PropertyControllerTest<TController> : PropertyTest
    {
        public override void Init()
        {
            base.Init();
            Context.Kernel.Bind<TController>().ToSelf();
            Controller = Context.Kernel.Get<TController>();
        }

        public TController Controller { get; set; }
    }
}