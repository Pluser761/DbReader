using firstApp.Model.Interfaces;

namespace firstApp.Model {
    abstract class BaseSource : ISource {
        protected string _name;

        public BaseSource(string name) {
            this._name = name;
        }

        public abstract override string ToString();
        
    }
}