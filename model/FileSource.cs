using System;

using firstApp.Model;
using firstApp.Model.Interfaces;

namespace firstApp.Model {
    class FileSource : BaseSource {
        private string _file;
        
        public string File {
            get => _file;
            set {
                if (value.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0) {
                    throw new ArgumentException("Error setting FileSource file path. Invalid path chars.");
                }
                this._file = value;
            }
        }
        public FileSource(string name) : base(name) {

        }

        public override string ToString() {
            return "[" + this._name + "]\nConnect=File=\"" + 
            this._file + "\";\n";
        }
    }
}