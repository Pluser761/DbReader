using firstApp.Model.Interfaces;
using firstApp.Parser;

namespace firstApp.SourceBuilder.Interfaces {
    interface ISourceBuilder {
        public ISource build(RawData rawData);
    }
}