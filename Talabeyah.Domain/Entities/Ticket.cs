﻿namespace Talabeyah.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool IsHandled { get; set; }
    }
}
