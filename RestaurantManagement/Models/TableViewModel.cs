﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class TableViewModel
    {
        public int TableId { get; set; }
        public int? WaiterId { get; set; }
        public bool IsAvailable { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string HallPlacing { get; set; }
        public List<BookingViewModel> Bookings { get; set; }
        public TableViewModel()
        {
            Bookings = new List<BookingViewModel>();
        }
    }
}
