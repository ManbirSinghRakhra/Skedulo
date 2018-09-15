using System.Collections.Generic;

namespace Skedulo.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Org { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Interests> Interests { get; set; }
        public bool IsRichest { get; set; }
    }
}
