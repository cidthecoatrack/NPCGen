﻿using CharacterGen.Tables;
using System;
using System.Collections.Generic;
using System.Xml;

namespace CharacterGen.Mappers.Domain.Collections
{
    public class CollectionsXmlMapper : CollectionsMapper
    {
        private StreamLoader streamLoader;

        public CollectionsXmlMapper(StreamLoader streamLoader)
        {
            this.streamLoader = streamLoader;
        }

        public Dictionary<String, IEnumerable<String>> Map(String tableName)
        {
            var filename = tableName + ".xml";
            var results = new Dictionary<String, IEnumerable<String>>();
            var xmlDocument = new XmlDocument();

            using (var stream = streamLoader.LoadFor(filename))
                xmlDocument.Load(stream);

            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                var items = new List<String>();
                var itemNodes = node.SelectNodes("item");

                foreach (XmlNode itemNode in itemNodes)
                    items.Add(itemNode.InnerText);

                var name = node.SelectSingleNode("name").InnerText;
                results.Add(name, items);
            }

            return results;
        }
    }
}