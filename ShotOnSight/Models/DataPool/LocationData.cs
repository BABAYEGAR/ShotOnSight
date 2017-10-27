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
    public class LocationData
    {
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Location>> DeSerializeMultipleImageLocationData(string stringData)
        {
            var convertedImageLocations = new List<Location>();


            //deserialize json object
            var deserializedLocations = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            foreach (var item in (IEnumerable)deserializedLocations)
            {
                //convert json items to vms.data.objects
                var jObject = JObject.Parse(item.ToString());
                var location = new Location
                {
                    LocationId = (long)jObject["LocationId"],
                    Name = (string)jObject["Name"]
                };
                convertedImageLocations.Add(location);
            }

            return convertedImageLocations;
        }
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public async Task<Location> DeSerializeSingleLocationData(string stringData)
        {

            //deserialize json object
            var deserializedImages = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            //convert json items to vms.data.objects
            var jObject = JObject.Parse(deserializedImages.ToString());
            var location = new Location
            {
                LocationId = (long)jObject["LocationId"],
                Name = (string)jObject["Name"]
            };

            return location;
        }
    }
}
