﻿using System;
using System.IO;

namespace NPCGen.Core.Generation.Xml.Parsers.Interfaces
{
    public interface IStreamLoader
    {
        Stream LoadStream(String filename);
    }
}