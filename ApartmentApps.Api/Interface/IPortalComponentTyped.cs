namespace ApartmentApps.Api.Modules
{
    public interface IPortalComponentTyped<TResultViewModel> where TResultViewModel : ComponentViewModel
    {
        TResultViewModel ExecuteResult();
    }
}