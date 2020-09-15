using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Core.Entities
{
    public class Master
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public virtual List<Repair> Repairs { get; set; }
    }
}
