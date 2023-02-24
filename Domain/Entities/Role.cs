using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
