using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ShotOnSight.Models.DataPool;
using ShotOnSight.Models.Entities;

namespace ShotOnSight.Models.DataFactory
{
    public class ImageCategoryFactory
    {

        public async Task<IEnumerable<ImageCategory>> GetAllImageCategoriesAsync(string baseAddress)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            IEnumerable<ImageCategory> imageCategory = new List<ImageCategory>();
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(baseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        imageCategory = await new ImageCategoryData().DeSerializeMultipleImageCategoryData(stringData);

                    }
            }
            return imageCategory;
        }

        public async Task<ImageCategory> GetImageCategoryAsync(string baseAddress, long? categoryId)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            var productCategory = new ImageCategory();
            baseAddress = baseAddress + categoryId;
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(baseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        productCategory = await new ImageCategoryData().DeSerializeSingleImageCategoryData(stringData);
                        ;
                    }
            }
            return productCategory;
        }
    }
}
