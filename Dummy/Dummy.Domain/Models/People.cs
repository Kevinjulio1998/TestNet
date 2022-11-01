using System;

namespace Dummy.Domain.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
