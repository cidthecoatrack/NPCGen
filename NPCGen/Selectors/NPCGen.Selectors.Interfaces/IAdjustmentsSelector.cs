﻿using System;
using System.Collections.Generic;

namespace NPCGen.Selectors.Interfaces
{
    public interface IAdjustmentsSelector
    {
        Dictionary<String, Int32> SelectAdjustmentsFrom(String tableName);
    }
}