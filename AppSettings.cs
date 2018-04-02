using System;

namespace core_react_template
{
    public class AppSettings
    {        
        public CosmosDb CosmosDb { get; set; }
    }

    public class CosmosDb
    {
        public string Endpoint { get; set; }
        public string Key { get; set; }
    }
}
