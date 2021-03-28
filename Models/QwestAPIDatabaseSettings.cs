namespace QwestAPI.Models
{
    public class QwestAPIDatabaseSettings: IQwestAPIDatabaseSettings
    {
        public string QwestCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}