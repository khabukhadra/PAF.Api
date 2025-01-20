using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMA.Application.NewEntities
{
    public class ClientUser  
    {

        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser User { get; set; }
        public int TotalHires { get; set; }
        public UserType UserType { get; set; } = UserType.Client;

        public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
        public ICollection<Ping> SentPings { get; set; } = new List<Ping>();
    }
}
 
