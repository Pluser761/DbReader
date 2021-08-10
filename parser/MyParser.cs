using System;
using System.Collections.Generic;
using System.IO;

using firstApp.Parser.Interfaces;

namespace firstApp.Parser {
    enum State {
        Name,
        Parameters,
        AddToList,
        Skip
    }
    class MyParser : IParser {

        private string tempLine;
        private StreamReader streamReader;

        public StreamReader StreamReader {
            get => this.streamReader;
            set {
                this.streamReader = value;
            }
        }

        public MyParser() {
            this.streamReader = null;
        }

        public MyParser(StreamReader streamReader) {
            this.streamReader = streamReader;
        }


        public List<RawData> getData() {
            if (this.streamReader == null) {
                Console.WriteLine("No streamreader assigned");
                return null;
            }
            List<RawData> result = new List<RawData>();
            string name = "";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            State state = State.Name;

            this.tempLine = this.streamReader.ReadLine();
            while (this.tempLine != null || state == State.AddToList)
            {
                switch (state) {
                    case State.Name:
                        if (this.tempLine[0] == '[' && this.tempLine[this.tempLine.Length - 1] == ']') {
                            name = this.tempLine.Substring(1, this.tempLine.Length - 2);
                            state = State.Parameters;
                        }
                        else {
                            Console.WriteLine("Error reading name. Skipping.");
                            state = State.Skip;
                            // we can skip through State, or just exit with "System.Environment.Exit(-1);"
                        }
                        this.tempLine = this.streamReader.ReadLine();
                        break;
                    case State.Parameters:
                        parameters = this.getParams();
                        state = State.AddToList;
                        break;
                    case State.AddToList:
                        result.Add(new RawData(name, parameters));
                        name = "";
                        parameters = new Dictionary<string, string>();
                        state = State.Name;
                        this.tempLine = this.streamReader.ReadLine();
                        break;
                    case State.Skip:
                        while (this.tempLine != null && this.tempLine != "") {
                            this.tempLine = this.streamReader.ReadLine();
                        }
                        state = State.Name;
                        this.tempLine = this.streamReader.ReadLine();
                        break;
                }
            }
            return result;
        }


        private Dictionary<string, string> getParams() {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            while (this.tempLine != "" && this.tempLine != null) {
                string[] spl = this.tempLine.Split('=', 2);
                // or Split('=') and check if where is more separators and catch error
                var s = spl.Length;
                switch(spl.Length) {
                    case 1:
                        Console.WriteLine("Error reading param. Separator not found.");
                        // or just exit with "System.Environment.Exit(-1);"
                        continue;
                    case 2:
                        parameters.Add(spl[0], spl[1]);
                        break;
                    default:
                        Console.WriteLine("Error reading param.");
                        // or just exit with "System.Environment.Exit(-1);"
                        continue;
                }
                this.tempLine = this.streamReader.ReadLine();
            }
            return parameters;
        }
    }
}