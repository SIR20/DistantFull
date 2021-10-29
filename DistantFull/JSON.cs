using System.Text;
using System.Collections.Generic;
using Json.Net;
namespace JSON
{
    class toJSON
    {
        private StringBuilder JBuilder = new StringBuilder();
        public void AddKeyValue(string key, string value) => JBuilder.Append($"\"{key}\":\"{value}\",");
        public string GetJSON()
        {
            string JSONStr = $"{{{JBuilder}}}";
            JSONStr = JSONStr.Remove(JSONStr.LastIndexOf(','), 1);
            return JSONStr;
        }
        public void Clear() => JBuilder.Clear();
    }

    class JSONto
    {
        private Dictionary<string, string> JDict = new Dictionary<string, string>();
        private string jsonstr = "";
        public string JSONStr
        {
            get
            {
                return jsonstr;
            }

            set
            {
                toDict(value);
            }
        }

        private void toDict(string s)
        {
            jsonstr = s;
            JDict = JsonNet.Deserialize<Dictionary<string,string>>(s);
        }

        public JSONto(string s) => toDict(s);
        public JSONto()
        {
            
        }
        public string GetValue(string key) => JDict[key];
    }
}
