﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Entities
{
    public class OwnerRepair
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int RepairId { get; set; }
    }
}