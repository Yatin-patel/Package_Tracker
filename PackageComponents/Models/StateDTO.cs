﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageComponents.Models
{
    public class StateDTO
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool Published { get; set; }
        public bool DisplayOrder { get; set; }
    }
}
