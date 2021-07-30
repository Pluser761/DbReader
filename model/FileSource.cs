using System;

namespace firstApp.Model {
    class FileSource : BaseSource {
        private string _name;
        private string _file;
        
        public string File {
            get => _file;
            set {
                if (value.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0) {
                    throw new ArgumentException("Error setting FileSource file path. Invalid path chars.");
                }
            }
        }
        public FileSource(string name) {
            this._name = name;
        }
    }
}