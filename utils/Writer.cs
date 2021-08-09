using System.Collections.Generic;
using System.IO;

using firstApp.Model.Interfaces;

namespace firstApp.Writers {
    class Writer {
        public Writer() {

        }

        public void write(List<ISource> list) {
            List<StreamWriter> streams = new List<StreamWriter>(){
                new StreamWriter("base_0.txt"),
                new StreamWriter("base_1.txt"),
                new StreamWriter("base_2.txt"),
                new StreamWriter("base_3.txt"),
                new StreamWriter("base_4.txt")
            };
            StreamWriter badStream = new StreamWriter("bad_data.txt");
            int i = 0;

            foreach (ISource source in list) {
                if (source.IsGood) {
                    streams[i++].Write(source);
                }
                else {
                    badStream.Write(source);
                }
            }

            foreach (StreamWriter streamWriter in streams) {
                streamWriter.Close();
            }
            badStream.Close();
        }
    }
}