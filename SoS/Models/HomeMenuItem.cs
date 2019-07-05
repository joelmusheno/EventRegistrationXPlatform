using System;
using System.Collections.Generic;
using System.Text;

namespace SoS.Models
{
    public enum MenuItemType
    {
        Registrations,
        Schedule,
        SignIn,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
