using BO;
using BOTP6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPNinja.Models
{
    public class VmSamourai
    {
        public Samourai samourai { get; set; }
        public List<Arme> armes { get; set; } = new List<Arme>();
        public int? armesId { get; set; }
        public List<ArtMartial> artMartials { get; set;  } =  new List<ArtMartial>();

        public List<int> artMatialIdSelected { get; set; } = new List<int>();
       // public int? artMatialIdSelected { get; set; }



    }
}