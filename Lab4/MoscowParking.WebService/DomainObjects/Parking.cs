using System;
using System.Collections.Generic;
using System.Text;

namespace MoscowParking.DomainObjects
{
    public class Parking : DomainObject
    {
        public string Name { get; set; }

        public string PlaceNumber { get; set; }

        public string AdmArea { get; set; }

        public string District { get; set; }

        public string Address { get; set; }

        public string Hours { get; set; }

        public int CountSpaces { get; set; }
    }
}