namespace Movies_API.ConfigurationBindingClasses
{
    public class DatabaseConfiguration
    {
        public string? ConnectionString { get; set; }
        public string? Database{ get; set; }

        public string? Table {  get; set; }
        public string? Collection {  get; set; }
    }
}
