using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;

using firstApp.SourceBuilder.Interfaces;

namespace firstApp.Parser {
    class RawData {
        private string _name;
        private Dictionary<string, string> _parameters;

        public string Name { get => _name; }
        public Dictionary<string, string> Parameters { get => _parameters; }

        public RawData(string name, Dictionary<string, string> parameters) {
            this._name = name;
            this._parameters = parameters;
        }

        public override string ToString() {
            string result = "[" + this._name + "]\n";
            foreach (KeyValuePair<string, string> pair in this._parameters) {
                result += pair.Key + "=" + pair.Value + "\n";
            }
            return result;
        }
    }
}