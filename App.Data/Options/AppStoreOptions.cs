namespace PDX.PBOT.App.Data.Options
{
    public class AppStoreOptions
    {
        public string DefaultSchema { get; set; } = null;

        public TableConfiguration Lookup { get; set; } = new TableConfiguration("Lookup");
        public TableConfiguration Content { get; set; } = new TableConfiguration("Content");
    }
}