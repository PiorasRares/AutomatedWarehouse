using DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlannerApp.Repositories
{
    public class Adapter
    {
        public HttpClient client = new HttpClient();
        public Adapter()
        {
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = new Uri("https://autostoreapi.azurewebsites.net/");
        }

        public List<StorageType> GetStorageTypes(string description)
        {
            var response = client.GetStringAsync($"/StorageType?description={description}").Result;
            return JsonConvert.DeserializeObject<List<StorageType>>(response);
        }
        public List<StorageLocation> GetStorageLocations(int storageTypeId)
        {
           return client.GetFromJsonAsync<List<StorageLocation>>($"/StorageLocation?storageTypeId={storageTypeId}").Result;
        }
    }
}
