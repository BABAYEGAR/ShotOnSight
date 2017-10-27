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
    public class ImageCategoryData
    {
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ImageCategory>> DeSerializeMultipleImageCategoryData(string stringData)
        {
            var convertedImageCategories = new List<ImageCategory>();


            //deserialize json object
            var deserializedImages = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            foreach (var item in (IEnumerable)deserializedImages)
            {
                //convert json items to vms.data.objects
                var jObject = JObject.Parse(item.ToString());
                var jCategory = jObject["ImageCategory"];
                var imageCategory = new ImageCategory
                {
                    Name = (string)jObject["Name"],
                    ImageCategoryId = (long)jObject["ImageCategoryId"]
                };
                convertedImageCategories.Add(imageCategory);
            }

            return convertedImageCategories;
        }
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public async Task<ImageCategory> DeSerializeSingleImageCategoryData(string stringData)
        {

            //deserialize json object
            var deserializedImages = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            //convert json items to vms.data.objects
            var jObject = JObject.Parse(deserializedImages.ToString());
            var imageCategory = new ImageCategory
            {
                Name = (string)jObject["Name"],
                ImageCategoryId = (long)jObject["ImageCategoryId"]
            };

            return imageCategory;
        }
    }
}
