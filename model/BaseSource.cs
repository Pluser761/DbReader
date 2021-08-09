using firstApp.Model.Interfaces;

namespace firstApp.Model {
    abstract class BaseSource : ISource {
        protected string _name;
        protected bool _isGood;
        public abstract bool IsGood { get; }

        public BaseSource(string name) {
            this._name = name;
            this._isGood = true;
        }

        public abstract override string ToString();
        
    }
}