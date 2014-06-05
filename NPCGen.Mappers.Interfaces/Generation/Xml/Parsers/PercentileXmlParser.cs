﻿using NPCGen.Core.Generation.Xml.Parsers.Interfaces;
using NPCGen.Core.Generation.Xml.Parsers.Objects;
using System;
using System.Collections.Generic;
using System.Xml;

namespace NPCGen.Core.Generation.Xml.Parsers
{
    public class PercentileXmlParser : IPercentileXmlParser
    {
        private IStreamLoader streamLoader;

        public PercentileXmlParser(IStreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public IEnumerable<PercentileObject> Parse(String filename)
        {
            var results = new List<PercentileObject>();

            using (var stream = streamLoader.LoadStream(filename))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(stream);

                var objects = xmlDocument.DocumentElement.ChildNodes;
                foreach (XmlNode node in objects)
                {
                    var percentileObject = new PercentileObject();

                    percentileObject.LowerLimit = Convert.ToInt32(node.SelectSingleNode("lower").InnerText);
                    percentileObject.Content = node.SelectSingleNode("content").InnerText;
                    percentileObject.UpperLimit = Convert.ToInt32(node.SelectSingleNode("upper").InnerText);

                    results.Add(percentileObject);
                }
            }

            return results;
        }
    }
}