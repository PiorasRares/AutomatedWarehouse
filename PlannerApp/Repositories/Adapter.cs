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
            var response = client.GetStringAsync($"/StorageLocation?storageTypeId={storageTypeId}").Result;
            return JsonConvert.DeserializeObject<List<StorageLocation>>(response);
        }
        public List<Material> GetMaterials()
        {
            var response = client.GetStringAsync($"/Material/All").Result;
            return JsonConvert.DeserializeObject<List<Material>>(response);
        }
        public Container GetContainer(int storageLocationId)
        {
            var response = client.GetStringAsync($"/Container?storageLocationId={storageLocationId}").Result;
            return JsonConvert.DeserializeObject<List<Container>>(response).First();
        }
        public void PostTransferOrder(TransferOrder transferOrder)
        {
            string json = JsonConvert.SerializeObject(transferOrder);
            StringContent content = new StringContent(json,Encoding.UTF8,"application/json");
            client.PostAsync("/TransferOrder/AddTransferOrder", content);
        }
    }
}
