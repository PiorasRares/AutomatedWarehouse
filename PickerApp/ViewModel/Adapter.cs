using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PickerApp.ViewModel
{
    public class Adapter
    {
        public HttpClient client = new HttpClient();
        public Adapter()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("https://autostoreapi.azurewebsites.net/");
        }


        //StorageTypes

        public Task<List<StorageType>> GetStorageType(string description)
        {
            var response = client.GetAsync($"StorageType?description={description}").Result;
            return response.Content.ReadAsAsync<List<StorageType>>();
        }

        //StorageLocation
        public Task<List<StorageLocation>> GetStorageLocations(int storageTypeId)
        {
            var response = client.GetAsync($"StorageLocation?storageTypeId={storageTypeId}").Result;
            return response.Content.ReadAsAsync<List<StorageLocation>>();
        }
        //Container
        public Task<List<Container>> GetContainer(int storageLocationId)
        {
            var response = client.GetAsync($"Container?storageLocationId={storageLocationId}").Result;
            return response.Content.ReadAsAsync<List<Container>>();
        }
        //Material
        public Task<List<Material>> GetMaterials(int containerId)
        {
            var response = client.GetAsync($"Material?containerId={containerId}").Result;
            return response.Content.ReadAsAsync<List<Material>>();
        }
        //TransferOrder
        public Task<List<TransferOrder>> GetTransferOrders(int containerId)
        {
            var response = client.GetAsync($"TransferOrder?containerId={containerId}").Result;
            return response.Content.ReadAsAsync<List<TransferOrder>>();
        }

    }
}
