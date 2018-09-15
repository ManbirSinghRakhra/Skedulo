using System.Collections.Generic;

namespace Skedulo.Models
{
    public class People
    {
        public People()
        {
            Skills = new List<Skills>();
            Interests = new List<Interests>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Org { get; set; }
        public List<Skills> Skills { get; set; }
        public List<Interests> Interests { get; set; }
        public bool IsRichest { get; set; }
    }
}
