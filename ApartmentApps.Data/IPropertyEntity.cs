namespace ApartmentApps.Data
{
    public interface IPropertyEntity :IBaseEntity
    {
        int? PropertyId { get; set; }
    }
    public interface IUserEntity : IPropertyEntity
    {
        string UserId { get; set; }
    }
}