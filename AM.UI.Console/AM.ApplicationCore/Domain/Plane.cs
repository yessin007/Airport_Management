﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
   public enum PlaneType { Boing, Airbus }
    public class Plane
    {
        
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }

        public int PlaneId { get; set; }

        public PlaneType PlaneType { get; set; }
        public ICollection<Flight> FlightsPlane { get; set; }
        public override string ToString()
        
        {
            return this.PlaneId+" "+this.Capacity;
        }

        public Plane(PlaneType planeType, int capacity, DateTime manufactureDate)
        {
            PlaneType = planeType;
            Capacity = capacity;
            ManufactureDate = manufactureDate;
        }


        public Plane() { }

        
    }



    
}
