using System;
using System.Collections.Generic;
using System.Text;

namespace Skedulo.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Question3,
        Question4
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
