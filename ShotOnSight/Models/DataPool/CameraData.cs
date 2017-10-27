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
    public class CameraData
    {
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Camera>> DeSerializeMultipleImageCameraData(string stringData)
        {
            var convertedImageCameras = new List<Camera>();

            //deserialize json object
            var deserializedCameras = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            foreach (var item in (IEnumerable)deserializedCameras)
            {
                //convert json items to vms.data.objects
                var jObject = JObject.Parse(item.ToString());
                var camera = new Camera
                {
                    CameraId = (long)jObject["CameraId"],
                    Name = (string)jObject["Name"]
                };
                convertedImageCameras.Add(camera);
            }

            return convertedImageCameras;
        }
        /// <summary>
        ///     This method retrievs a list of all the products
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public async Task<Camera> DeSerializeSingleImageCameraData(string stringData)
        {

            //deserialize json object
            var deserializedCameras = await Task.Run(() => JsonConvert.DeserializeObject(stringData));
            //convert json items to vms.data.objects
            var jObject = JObject.Parse(deserializedCameras.ToString());
            var camera = new Camera
            {
                CameraId = (long)jObject["CameraId"],
                Name = (string)jObject["Name"]
            };

            return camera;
        }
    }
}
