namespace ApartmentApps.Api
{
    public interface IEntityRemoved<TEntityType>
    {
        void EntityRemoved(TEntityType entity);
    }
}