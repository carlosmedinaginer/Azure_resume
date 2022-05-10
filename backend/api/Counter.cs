using Newtonsoft.Json;

namespace Company.Function

{
    public class Counter 
    {
        [JsonProperty(PropertyName ="id")] // Make sure it matches the proper name in Cosmos DB 
        public string Id {get;set;}
        
        [JsonProperty(PropertyName ="count")]
        public int Count {get;set;}
    }
}