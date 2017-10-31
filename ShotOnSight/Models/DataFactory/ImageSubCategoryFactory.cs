using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShotOnSight.Models.Entities;

namespace ShotOnSight.Models.DataFactory
{
    public class ImageSubCategoryFactory
    {

        public async Task<IEnumerable<ImageSubCategory>> GetAllImageSubCategoriesAsync(string baseAddress)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            IEnumerable<ImageSubCategory> categories = new List<ImageSubCategory>();
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(baseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        categories = await Task.Run(() => JsonConvert.DeserializeObject<List<ImageSubCategory>>(stringData));

                    }
            }
            return categories;
        }
    }
}
