﻿using System;
using System.Collections.Generic;
using NDB.Covid19.Models.DTOsForServer;

namespace NDB.Covid19.Models.DTOsForServer
{
    public class CountryListDTO
    {
        public List<CountryDetailsDTO> CountryCollection { get; set; }
    }
}