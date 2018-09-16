using System.Collections.Generic;

namespace Skedulo.Models
{
    public class Items
    {
        public string avatar_url { get; set; }
        public string login { get; set; }
        public string type { get; set; }
        public int score { get; set; }
    }

    public class Users
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<Items> items { get; set; }
    }
}
