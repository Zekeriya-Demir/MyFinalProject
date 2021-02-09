using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        // Northwind vt de id string olduğu için string tanımladık.
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyntactName { get; set; }
        public string City { get; set; }
    }
}
