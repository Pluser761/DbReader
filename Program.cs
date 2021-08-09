using System;
using System.IO;
using System.Collections.Generic;

using firstApp.Model.Interfaces;
using firstApp.SourceBuilder.Interfaces;
using firstApp.SourceBuilder;
using firstApp.Readers;
using firstApp.Writers;

using firstApp.Parser;

namespace firstApp {
    class Program {
        static void Main(string[] args) {
            Dictionary<Predicate<RawData>, ISourceBuilder> settings = new Dictionary<Predicate<RawData>, ISourceBuilder>() {
                { delegate (RawData data) {
                    if (data.Parameters.ContainsKey("Connect")) {
                        if (data.Parameters["Connect"].Contains("File")) {
                            return true;
                        }
                    }
                    return false;
                }, new FileSourceBuilder() },
                { delegate (RawData data) {
                    if (data.Parameters.ContainsKey("Connect")) {
                        if (data.Parameters["Connect"].Contains("Srvr")) {
                            return true;
                        }
                    }
                    return false;
                }, new DataBaseSourceBuilder() }
            };
 
            Reader reader = new Reader(new StreamReader("data.txt"), settings, new MyParser());
            List<ISource> list = reader.getData();

            Writer writer = new Writer();
            writer.write(list);
        }

    }
}
