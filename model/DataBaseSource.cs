using firstApp.Model;
using firstApp.Model.Interfaces;

namespace firstApp.Model {
    class DataBaseSource : BaseSource {
        private string _host;
        private string _port;
        private string _base_name;

        public string Host {
            get => _host;
            set => _host = value;
        }

        public string Port {
            get => _port;
            set => _port = value;
        }

        public string BaseName {
            get => _base_name;
            set => _base_name = value;
        }
        public override bool IsGood {
            get {
                if (_base_name == "" || _host == "") {
                    return false;
                }
                return true;
            }
        }
        
        public DataBaseSource(string name) : base(name) {
            
        }

        public override string ToString() {
            return "[" + this._name + "]\nConnect=Srvr=\"" + 
            (this._port == "" ? this._host : (this._host + ":" + this._port)) + 
            "\";Ref=\"" + this._base_name + "\";\n";
        }
    }
}