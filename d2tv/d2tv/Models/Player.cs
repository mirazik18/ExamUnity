using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace d2tv.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public string GameName { get; set; }
        public string SteamProfileUrl { get; set; }
        public string PositionInGame { get; set; }
        public string AvatarUrl { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        public int CountyCodeId { get; set; }
        [ForeignKey("CountyCodeId")]
        public Country Country { get; set; }
        public string Role { get; set; }
        public int EarnedMoney { get; set; }

    }
}
