namespace QwestAPI.Models
{
    public interface IQwestAPIDatabaseSettings
    {
        string QwestCollectionName {get; set;}
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}