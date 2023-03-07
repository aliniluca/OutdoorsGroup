﻿using OutdoorsGroup.Models;

namespace OutdoorsGroup.ViewModels
{
    public class ListClubByCityViewModel
    {
        public IEnumerable<Club> Clubs { get; set; }
        public bool NoClubWarning { get; set; } = false;
        public string City { get; set; }
        public string State { get; set; }
    }
}
