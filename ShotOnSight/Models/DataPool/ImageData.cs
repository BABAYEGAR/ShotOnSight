using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShotOnSight.Models.DataFactory;
using ShotOnSight.Models.Entities;

namespace ShotOnSight.Models.DataPool
{
    public class ImageData
    {
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        /// <param name="categoryBaseAddress"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Image>> DeSerializeMultipleImagesData(string stringData,string categoryBaseAddress)
        {
            var convertedImages = new List<Image>();

            //deserialize json object
            var deserializedImages = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            foreach (var item in (IEnumerable) deserializedImages)
            {
                //convert json items to vms.data.objects
                var jObject = JObject.Parse(item.ToString());
                JToken jCategory = null;
                JToken jSubCategory = null;
                JToken jUser = null;
                JToken jCamera = null;
                JToken jLocation = null;
                if (jObject["ImageCategory"] != null && jObject["ImageCategory"].HasValues)
                {
                    jCategory = jObject["ImageCategory"].First;
                }
                if (jObject["AppUser"] != null && jObject["AppUser"].HasValues)
                {
                    jUser = jObject["AppUser"].First;
                }
                if (jObject["Camera"] != null && jObject["Camera"].HasValues)
                {
                    jCamera = jObject["Camera"].First;
                }
                if (jObject["ImageSubCategory"] != null && jObject["ImageSubCategory"].HasValues)
                {
                    jSubCategory = jObject["ImageSubCategory"].First;
                }
                if (jObject["Location"] != null && jObject["Location"].HasValues)
                {
                    jLocation = jObject["Location"].First;
                }
                var image = new Image
                {
                    ImageId = (long)jObject["ImageId"],
                    Title = (string)jObject["Title"],
                    Theme = (string)jObject["Theme"],
                    Caption = (string)jObject["Caption"],
                    Inspiration = (string)jObject["Inspiration"],
                    Description = (string)jObject["Description"],
                    DateCreated = (DateTime)jObject["DateCreated"],
                    AppUserId = (long)jObject["AppUserId"],
                    ImageCategoryId = (long)jObject["ImageCategoryId"],
                    ImageSubCategoryId = (long)jObject["ImageSubCategoryId"],
                    CameraId = (long)jObject["CameraId"],
                    LocationId = (long)jObject["LocationId"],
                    SellingPrice = (long)jObject["SellingPrice"],
                    Status = (string)jObject["Status"],
                };
                if (jCategory != null)
                {
                    var imageCategory = new ImageCategory
                    {
                        Name = (string)jCategory["Name"],
                        ImageCategoryId = (long)jCategory["ImageCategoryId"]
                    };
                    image.ImageCategory = imageCategory;
                }
                if (jSubCategory != null)
                {
                    var subCategory = new ImageSubCategory
                    {
                        Name = (string)jSubCategory["Name"],
                        ImageCategoryId = (long)jSubCategory["ImageCategoryId"],
                        ImageSubCategoryId = (long)jSubCategory["ImageSubCategoryId"]
                    };
                    image.ImageSubCategory = subCategory;
                }
                if (jUser != null)
                {
                    var appUser = new AppUser
                    {
                        Name = (string)jUser["Name"],
                        Username = (string)jUser["Username"],
                        AppUserId = (long)jUser["ImageCategoryId"]
                    };
                    image.AppUser = appUser;
                }
                if (jCamera != null)
                {
                    var camera = new Camera
                    {
                        Name = (string)jCamera["Name"],
                        CameraId = (long)jCamera["CameraId"]
                    };
                    image.Camera = camera;
                }
                if (jLocation != null)
                {
                    var location = new Location
                    {
                        Name = (string)jCamera["Name"],
                        LocationId = (long)jCamera["LocationId"]
                    };
                    image.Location = location;
                }
                convertedImages.Add(image);
            }

            return convertedImages;
        }
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        ///         /// <param name="categoryBaseAddress"></param>
        /// <returns></returns>
        public async Task<Image> DeSerializeSingleImageData(string stringData, string categoryBaseAddress)
        {
            //deserialize json object
            var deserializedProducts = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            //convert json items to vms.data.objects
            var jObject = JObject.Parse(deserializedProducts.ToString());
            JToken jCategory = null;
            JToken jSubCategory = null;
            JToken jUser = null;
            JToken jCamera = null;
            JToken jLocation = null;
            if (jObject["ImageCategory"] != null && jObject["ImageCategory"].HasValues)
            {
                jCategory = jObject["ImageCategory"].First;
            }
            if (jObject["AppUser"] != null && jObject["AppUser"].HasValues)
            {
                jUser = jObject["AppUser"].First;
            }
            if (jObject["Camera"] != null && jObject["Camera"].HasValues)
            {
                jCamera = jObject["Camera"].First;
            }
            if (jObject["ImageSubCategory"] != null && jObject["ImageSubCategory"].HasValues)
            {
                jSubCategory = jObject["ImageSubCategory"].First;
            }
            if (jObject["Location"] != null && jObject["Location"].HasValues)
            {
                jLocation = jObject["Location"].First;
            }
            var image = new Image
            {
                ImageId = (long)jObject["ImageId"],
                Title = (string)jObject["Title"],
                Theme = (string)jObject["Theme"],
                Caption = (string)jObject["Caption"],
                Inspiration = (string)jObject["Inspiration"],
                Description = (string)jObject["Description"],
                DateCreated = (DateTime)jObject["DateCreated"],
                AppUserId = (long)jObject["AppUserId"],
                ImageCategoryId = (long)jObject["ImageCategoryId"],
                ImageSubCategoryId = (long)jObject["ImageSubCategoryId"],
                CameraId = (long)jObject["CameraId"],
                LocationId = (long)jObject["LocationId"],
                SellingPrice = (long)jObject["SellingPrice"],
                Status = (string)jObject["Status"],
            };
            if (jCategory != null)
            {
                var imageCategory = new ImageCategory
                {
                    Name = (string)jCategory["Name"],
                    ImageCategoryId = (long)jCategory["ImageCategoryId"]
                };
                image.ImageCategory = imageCategory;
            }
            if (jSubCategory != null)
            {
                var subCategory = new ImageSubCategory
                {
                    Name = (string)jSubCategory["Name"],
                    ImageCategoryId = (long)jSubCategory["ImageCategoryId"],
                    ImageSubCategoryId = (long)jSubCategory["ImageSubCategoryId"]
                };
                image.ImageSubCategory = subCategory;
            }
            if (jUser != null)
            {
                var appUser = new AppUser
                {
                    Name = (string)jUser["Name"],
                    Username = (string)jUser["Username"],
                    AppUserId = (long)jUser["ImageCategoryId"]
                };
                image.AppUser = appUser;
            }
            if (jCamera != null)
            {
                var camera = new Camera
                {
                    Name = (string)jCamera["Name"],
                    CameraId = (long)jCamera["CameraId"]
                };
                image.Camera = camera;
            }
            if (jLocation != null)
            {
                var location = new Location
                {
                    Name = (string)jCamera["Name"],
                    LocationId = (long)jCamera["LocationId"]
                };
                image.Location = location;
            }
            return image;
        }

  
     
    }
}