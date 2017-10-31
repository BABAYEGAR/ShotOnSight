using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShotOnSight.Models.Entities;

namespace ShotOnSight.Models.DataFactory
{
    public class LocationFactory
    {

        public async Task<IEnumerable<Location>> GetAllImageLocationsAsync(string baseAddress)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            IEnumerable<Location> locations = new List<Location>();
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(baseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        locations = await Task.Run(() => JsonConvert.DeserializeObject<List<Location>>(stringData));

                    }
            }
            return locations;
        }
    }
}
