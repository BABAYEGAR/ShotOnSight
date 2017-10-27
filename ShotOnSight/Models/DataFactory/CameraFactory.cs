using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ShotOnSight.Models.DataPool;
using ShotOnSight.Models.Entities;

namespace ShotOnSight.Models.DataFactory
{
    public class CameraFactory
    {

        public async Task<IEnumerable<Camera>> GetAllImageLocationsAsync(string baseAddress)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            IEnumerable<Camera> cameras = new List<Camera>();
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(baseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        cameras = await new CameraData().DeSerializeMultipleImageCameraData(stringData);

                    }
            }
            return cameras;
        }

        public async Task<Camera> GetImageCameraAsync(string baseAddress, long? cameraId)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            var camera = new Camera();
            baseAddress = baseAddress + cameraId;
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(baseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        camera = await new CameraData().DeSerializeSingleImageCameraData(stringData);
                        
                    }
            }
            return camera;
        }
    }
}
