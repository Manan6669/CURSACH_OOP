using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kursovoi
{
    public partial class Photochepter
    {
        public int CodePhChepter { get; set; }
        public int CodeTitle { get; set; }
        public string PathPhChepter { get; set; }

        public virtual Title CodeTitleNavigation { get; set; }
    }
}
