using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShotOnSight.Models.Entities;

namespace ShotOnSight.Models.DataPool
{
    public class ImageSubCategoryData
    {
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ImageSubCategory>> DeSerializeMultipleImageSubCategoryData(string stringData)
        {
            var convertedImageSubCategory = new List<ImageSubCategory>();

            //deserialize json object
            var deserializedCategories = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            foreach (var item in (IEnumerable)deserializedCategories)
            {
                //convert json items to vms.data.objects
                var jObject = JObject.Parse(item.ToString());
                var subCategory = new ImageSubCategory
                {
                    ImageSubCategoryId = (long)jObject["ImageSubCategoryId"],
                    Name = (string)jObject["Name"]
                };
                convertedImageSubCategory.Add(subCategory);
            }

            return convertedImageSubCategory;
        }
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public async Task<ImageSubCategory> DeSerializeSingleImageSubCategoryData(string stringData)
        {

            //deserialize json object
            var deserializedCameras = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            //convert json items to vms.data.objects
            var jObject = JObject.Parse(deserializedCameras.ToString());
            var subCategory = new ImageSubCategory
            {
                ImageSubCategoryId = (long)jObject["ImageSubCategoryId"],
                Name = (string)jObject["Name"]
            };

            return subCategory;
        }
    }
}
