namespace ApartmentApps.Api
{
    public interface IEntityAdded<TEntityType>
    {
        void EntityAdded(TEntityType entity);
    }
}