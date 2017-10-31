using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShotOnSight.Models.Entities;

namespace ShotOnSight.Models.DataFactory
{
    public class ImageFactory
    {
        public async Task<IEnumerable<Image>> GetAllImagesAsync(string imageBaseAddress)
        {
            if (imageBaseAddress == null) throw new ArgumentNullException(nameof(imageBaseAddress));
            IEnumerable<Image> images = new List<Image>();
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(imageBaseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        images = await Task.Run(() => JsonConvert.DeserializeObject<List<Image>>(stringData));
                    }
            }
            return images;
        }
    }
}