using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShotOnSight.Models.Entities;


namespace ShotOnSight.Models.DataFactory
{
    public class AppUserFactory
    {
        public async Task<IEnumerable<AppUser>> GetAllUsersAsync(string baseAddress)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            IEnumerable<AppUser> users = new List<AppUser>();
         
            using (var httpClient = new HttpClient())
            {
                // Do the actual request and await the response
                var httpResponse = await httpClient.GetAsync(baseAddress);
                if (httpResponse != null)
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var stringData = httpResponse.Content.ReadAsStringAsync().Result;
                        users = await Task.Run(() => JsonConvert.DeserializeObject<List<AppUser>>(stringData));
                    }
            }
            return users;
        }

    }
}