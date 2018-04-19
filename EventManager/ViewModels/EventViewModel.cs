using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventManager.Models;

namespace EventManager.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}