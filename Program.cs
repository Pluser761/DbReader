using System;
using System.Collections.Generic;
using System.IO;

using firstApp.Model.Interfaces;
using firstApp.Parser;
using firstApp.Readers;
using firstApp.SourceBuilder;
using firstApp.SourceBuilder.Interfaces;
using firstApp.Writers;

namespace firstApp {
    class Program {
        static void Main(string[] args) {
            if (args.Length != 1) {
                Console.WriteLine("No parameter sent");
                System.Environment.Exit(-1);
            }
            if (!File.Exists(args[0])) {
                Console.WriteLine("File does not exists.");
                System.Environment.Exit(-1);
            }

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

            StreamReader streamReader = new StreamReader(args[0]/*"data.txt"*/);
 
            Reader reader = new Reader(streamReader, settings, new MyParser());
            List<ISource> list = reader.getData();
            
            streamReader.Close();

            Writer writer = new Writer();
            writer.write(list);
        }

    }
}
