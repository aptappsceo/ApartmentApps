namespace ApartmentApps.Api.Modules
{
    public abstract class PortalComponent<TResultViewModel> : IPortalComponent, IPortalComponentTyped<TResultViewModel> where TResultViewModel : ComponentViewModel
    {
        public abstract TResultViewModel ExecuteResult();

        public ComponentViewModel Execute()
        {
            return ExecuteResult();
        }
    }
}