using System.Collections.Generic;

namespace PDX.PBOT.App.Data.Models
{
    public class Lookup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Content> Contents { get; set; }
    }
}