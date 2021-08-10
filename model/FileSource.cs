namespace firstApp.Model {
    class FileSource : BaseSource {
        private string _file;

        public override bool IsGood {
            get {
                // or throw exceprion, see File property setter
                if (_file.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0) {
                    return false;
                }
                return true;
            }
        }
        
        public string File {
            get => _file;
            set {
                if (value.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0) {
                    // we can 'throw new ArgumentException("Error setting FileSource file path. Invalid path chars.");'
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