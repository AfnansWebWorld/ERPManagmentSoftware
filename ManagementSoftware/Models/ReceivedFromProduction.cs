﻿namespace ManagementSoftware.Models
{
    public class ReceivedFromProduction
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
