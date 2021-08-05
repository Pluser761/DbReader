using System;
using System.IO;
using System.Collections.Generic;

using firstApp.Model.Interfaces;
using firstApp.SourceBuilder.Interfaces;


namespace firstApp.Readers {
    class Reader {
        private string filePath;
        private StreamReader sr;
        private Dictionary<string, ISourceBuilder> settings;
        private List<ISource> result;
        private string tempLine;
        private string tempName;
        private Dictionary<string, string> tempParams;

        public Reader(string filePath, Dictionary<string, ISourceBuilder> settings) {
            this.filePath = filePath;
            this.settings = settings;
        }

        public List<ISource> getData() {
            this.result = new List<ISource>();

            this.tempParams = new Dictionary<string, string>();
            this.sr = new StreamReader(this.filePath);
            this.tempLine = sr.ReadLine();
            while (this.tempLine != null)
            {
                if (this.tempLine != "") {
                    this.callBuilder();
                }
                if (this.tempLine[0] == '[' && this.tempLine[this.tempLine.Length - 1] == ']') {
                    this.tempLine = this.tempLine.Substring(1, this.tempLine.Length - 2);
                    this.tempName = this.tempLine;
                }
                else {
                    this.getParams(this.tempParams);
                }
                this.tempLine = sr.ReadLine();
            }
            this.callBuilder();
            sr.Close();

            return this.result;
        }

        private void getParams(Dictionary<string, string> additionalParams) {
            while (this.tempLine != "" && this.tempLine != null)
            {
                string[] spl = this.tempLine.Split('=', 2);
                additionalParams.Add(spl[0], spl[1]);
                this.tempLine = sr.ReadLine();
            }
        }

        private ISource callBuilder() {
            ISource source = null;
            if (this.tempParams.ContainsKey("Connect")) {
                string[] connectSettings = this.tempParams["Connect"].Split('=');
                ISourceBuilder sourceBuilder;
                if (this.settings.ContainsKey(connectSettings[0])) {
                    sourceBuilder = this.settings[connectSettings[0]];
                    source = sourceBuilder.build(this.tempName, this.tempParams);
                    if (source != null) {
                        this.result.Add(source);
                    }
                    else {
                        Console.WriteLine("Warning! Can't find \'Connect\' parameter, skipping");
                    }
                }
            }
            this.tempParams = new Dictionary<string, string>();
            return source;
        }
}
}