using System;
using System.Collections.Generic;
using System.IO;

using firstApp.Model.Interfaces;
using firstApp.Parser;
using firstApp.Parser.Interfaces;
using firstApp.SourceBuilder.Interfaces;

namespace firstApp.Readers {
    class Reader {
        private StreamReader streamReader;
        private Dictionary<Predicate<RawData>, ISourceBuilder> settings;
        private IParser parser;

        public Reader(StreamReader streamReader, Dictionary<Predicate<RawData>, ISourceBuilder> settings, IParser parser) {
            this.streamReader = streamReader;
            this.settings = settings;
            this.parser = parser;
            this.parser.StreamReader = streamReader;
        }

        public List<ISource> getData() {
            List<ISource> result = new List<ISource>();
            List<RawData> rawData = this.parser.getData();
            ISource source = null;
            
            foreach (RawData data in rawData) {
                source = this.callBuilder(data);
                if (source != null) {
                    result.Add(source);
                    source = null;
                }
            }

            return result;
        }

        private ISource callBuilder(RawData data) {
            foreach (KeyValuePair<Predicate<RawData>, ISourceBuilder> setting in this.settings) {
                if (setting.Key(data)) {
                    return setting.Value.build(data);
                }
            }
            Console.WriteLine("Predicate's not found.");
            return null;
        }
}
}