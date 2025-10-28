using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CategoryAPI.NUnitTests
{
    public class CatNunit : WebApplicationFactory<program>


    {
        private HttpClient _client;
        [SetUp] public void SetUp() { _client = this.CreateClient(); }

        [Test] // POST
        public async Task Post_AddsCategory()
        {
            var category = new { CategoryName = "Snacks", Description = "Chips and light snacks" };
            var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
            var resp = await _client.PostAsync("/api/categories", content);
            var respBody = await resp.Content.ReadAsStringAsync();
            Console.WriteLine(respBody); // Diagnostics
            Assert.AreEqual(HttpStatusCode.Created, resp.StatusCode); // Expects 201 Created
        }

        [Test] // PUT
        public async Task Put_UpdatesCategory()
        {
            var update = new { CategoryID = 4, CategoryName = "Dairy Updated", Description = "All types of cheese and dairy products" };
            var content = new StringContent(JsonConvert.SerializeObject(update), Encoding.UTF8, "application/json");
            var resp = await _client.PutAsync("/api/categories/4", content);
            Assert.AreEqual(HttpStatusCode.NoContent, resp.StatusCode);
        }

        [Test]
        public async Task Delete_RemovesCategory()
        {
            // 1. Add a test category via POST
            var category = new { CategoryName = "Snacks", Description = "Chips and light snacks" };
            var content = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");
            var resp = await _client.PostAsync("/api/categories", content);
            var respBody = await resp.Content.ReadAsStringAsync();

            // 2. Extract the generated CategoryID from the response
            var created = JsonConvert.DeserializeObject<dynamic>(respBody);
            int idToDelete = created.categoryID;

            // 3. Delete the category using the new ID
            var deleteResp = await _client.DeleteAsync($"/api/categories/{idToDelete}");
            Assert.AreEqual(HttpStatusCode.NoContent, deleteResp.StatusCode);
        }

    }
}