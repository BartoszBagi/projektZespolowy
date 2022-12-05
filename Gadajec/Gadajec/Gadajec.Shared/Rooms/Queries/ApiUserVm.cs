﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadajec.Shared.Rooms.Queries
{
    public class ApiUserVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<RoomForListVm> Users { get; set; } = new List<RoomForListVm>();
    }
}