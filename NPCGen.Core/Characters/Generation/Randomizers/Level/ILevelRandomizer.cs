﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPCGen.Core.Characters.Generation.Randomizers.Level
{
    public interface ILevelRandomizer
    {
        Int32 Randomize();
    }
}