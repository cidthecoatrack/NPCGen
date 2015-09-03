﻿using System;
using System.Collections.Generic;

namespace CharacterGen.Common.Magics
{
    public class Magic
    {
        public Animal Animal { get; set; }
        public Dictionary<Int32, IEnumerable<String>> Spells { get; set; }

        public Magic()
        {
            Spells = new Dictionary<Int32, IEnumerable<String>>();
        }
    }
}