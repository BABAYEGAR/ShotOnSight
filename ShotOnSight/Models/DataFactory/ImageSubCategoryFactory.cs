using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ShotOnSight.Models.DataPool;
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
                        categories = await new ImageSubCategoryData().DeSerializeMultipleImageSubCategoryData(stringData);

                    }
            }
            return categories;
        }

        public async Task<ImageSubCategory> GetImageSubCategoryAsync(string baseAddress, long? categoryId)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            var category = new ImageSubCategory();
            baseAddress = baseAddress + categoryId;
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(baseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        category = await new ImageSubCategoryData().DeSerializeSingleImageSubCategoryData(stringData);
                    }
            }
            return category;
        }
    }
}
