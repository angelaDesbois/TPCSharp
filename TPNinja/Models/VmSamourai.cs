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
        public List<Arme> armes { get; set; }
        public int? armesId { get; set; }

    }
}