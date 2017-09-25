using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KGVC.Models
{
    public static  class GraphModel
    {
        const  string ChangePassword = "https://graph.windows.net/me/changePassword?api-version=1.6";
        [JsonProperty("currentPassword")]
        public static string  currentPassword { get; set; }

        [JsonProperty("newPassword")]
        public static string newPassword { get; set; }

    
    }
}
