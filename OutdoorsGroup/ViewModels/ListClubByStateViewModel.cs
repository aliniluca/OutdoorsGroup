﻿using OutdoorsGroup.Models;

namespace OutdoorsGroup.ViewModels
{
    public class ListClubByStateViewModel
    {
        public IEnumerable<Club> Clubs { get; set; }
        public bool NoClubWarning { get; set; } = false;
        public string State { get; set; }
    }
}
