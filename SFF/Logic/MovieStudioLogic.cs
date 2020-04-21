using System;
using System.Collections.Generic;
using SFF.Logic;


namespace SFF.Logic
{
    public class MovieStudioLogic : IProperty
    {
        public string Name { get; set; }
        public string City { get; set; }

        private MovieStudioLogic()
        {

        }

        public MovieStudioLogic(string City)
        {
            this.City = City;
        }
        public MovieStudioLogic(string Name, string City)
        {
            this.Name = Name;
            this.City = City;
        }
    }
}