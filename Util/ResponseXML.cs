using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chu_core_webapi.Util
{
    public class ResponseXML
    {
        [JsonProperty(PropertyName = "Head")]
        Head head;
        [JsonProperty(PropertyName = "Body")]
        Body body;
    }
    internal class Head
    {
        [JsonProperty(PropertyName = "param")]
        List<Param> paramList;
    }
    internal class Body
    {
        [JsonProperty(PropertyName = "param")]
        List<Param> paramList;
    }
    internal class Param
    {
        [JsonProperty(PropertyName = "@name")]
        string name;
        [JsonProperty(PropertyName = "#text")]
        string text;
    }
}
