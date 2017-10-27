using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ShotOnSight.Models.DataPool;
using ShotOnSight.Models.Entities;

namespace ShotOnSight.Models.DataFactory
{
    public class ImageFactory
    {
        public async Task<IEnumerable<Image>> GetAllImagesAsync(string imageBaseAddress,
            string categoryBaseAddress, string subCategoryBaseAddress, string locationBaseAddress, string cameraBaseAddress)
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
                        images = await new ImageData().DeSerializeMultipleImagesData(stringData,
                            categoryBaseAddress);
                    }
            }
            return images;
        }

        public async Task<Image> GetImageAsync(string baseAddress, string categoryBaseAddress, long? productId)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            var image = new Image();
            baseAddress = baseAddress + productId;
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(baseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        //get particular product
                        image = await new ImageData()
                            .DeSerializeSingleImageData(stringData, categoryBaseAddress);
                    }
            }
            return image;
        }


    }
}