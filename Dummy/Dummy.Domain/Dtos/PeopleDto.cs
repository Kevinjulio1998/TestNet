
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dummy.Domain.Models;

namespace Dummy.Domain.Dtos
{
    public class PeopleDto
    {
     
        public string Document { get; set; }
        public string FullName { get; set; }

        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Contact { get; set; }
        public int TypeContactId { get; set; }
        public IEnumerable<TypeContact> TypeContact { get; set; }
        public dynamic ContactInformation { get; set; }
    }
}
