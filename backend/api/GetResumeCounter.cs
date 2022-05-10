using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Company.Function
{
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static  HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureResumeVisitCount",collectionName:"Counter",ConnectionStringSetting ="AzureResumeConnectionString",Id ="1",PartitionKey ="1")] Counter counter, // Fetch the data from the CosmosDB 
            [CosmosDB(databaseName:"AzureResumeVisitCount",collectionName:"Counter",ConnectionStringSetting ="AzureResumeConnectionString",Id ="1",PartitionKey ="1")] out  Counter updatedCounter,// send the update value to the CosmosDB       

            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

           updatedCounter = counter; // set the same content of the CosmosDB 
           updatedCounter.Count +=1; // Increase the count by 1 and  update the database 
           
           var jsonToReturn = JsonConvert.SerializeObject(counter);

           return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
           {
               Content = new StringContent(jsonToReturn,Encoding.UTF8,"application/json")
           };

        }
    }
}
