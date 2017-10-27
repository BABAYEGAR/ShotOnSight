using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShotOnSight.Models.Entities;

namespace ShotOnSight.Models.DataPool
{
    public class AppUserData
    {
        public AppUser FetchUserData(string stringData)
        {
        
            //new jason object
            var jObject = JObject.Parse(stringData);
            JToken jRole = null;
            if (jObject["ImageCategory"] != null && jObject["ImageCategory"].HasValues)
            {
                jRole = jObject["Role"].First;
            }
            var user = new AppUser
            {
                AppUserId = (long) jObject["AppUserId"],
                Username = (string) jObject["Username"],
                Name = (string) jObject["Name"],
                Email = (string) jObject["Email"],
                Mobile = (string) jObject["Mobile"],
                RoleId = (long) jObject["RoleId"],
                Status = (string) jObject["Status"],
                Address = (string) jObject["Address"],
                ProfilePicture = (string) jObject["ProfilePicture"]
            };
            if (jRole != null)
            {
                var role = new Role
                {
                    RoleId = (long) jRole["AppUserId"],
                    Name = (string) jRole["Address"]
                };
                user.Role = role;
            }
     
            return user;
        }

        /// <summary>
        ///     This method retrievs a list of all the users
        /// </summary>
        /// <param name="stringData"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AppUser>> FetchAllUsersAsync(string stringData)
        {
            var convertedUsers = new List<AppUser>();


            //deserialize json object
            var jObjects = JObject.Parse(stringData);
            var deserializedUsers = await Task.Run(() => JsonConvert.DeserializeObject(jObjects.ToString()));
            foreach (var item in (IEnumerable) deserializedUsers)
            {
                //convert json items to vms.data.objects
                var jObject = JObject.Parse(item.ToString());
                JToken jRole = null;
                if (jObject["ImageCategory"] != null && jObject["ImageCategory"].HasValues)
                {
                    jRole = jObject["Role"].First;
                }
                var user = new AppUser
                {
                    AppUserId = (long)jObject["AppUserId"],
                    Username = (string)jObject["Username"],
                    Name = (string)jObject["Name"],
                    Email = (string)jObject["Email"],
                    Mobile = (string)jObject["Mobile"],
                    RoleId = (long)jObject["RoleId"],
                    Status = (string)jObject["Status"],
                    Address = (string)jObject["Address"],
                    ProfilePicture = (string)jObject["ProfilePicture"]
                };
                if (jRole != null)
                {
                    var role = new Role
                    {
                        RoleId = (long)jRole["AppUserId"],
                        Name = (string)jRole["Address"]
                    };
                    user.Role = role;
                }


                convertedUsers.Add(user);
            }

            return convertedUsers;
        }
    }
}