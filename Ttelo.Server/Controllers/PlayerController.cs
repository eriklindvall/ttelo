using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Ttelo.Server.Business;
using Ttelo.Shared.Model;

namespace Ttelo.Server.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private IBusinessLayer _businessLayer;

        public PlayerController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }
        
        [HttpGet("[action]")]
        public IEnumerable<Player> List(string sort = "rating")
        {
            if (sort == "name")
            {
                return _businessLayer.GetPlayersByName().ToList();
            }
            return _businessLayer.GetPlayersByRank().ToList();
        }

        [HttpPost("[action]")]
        public void Create(string name)
        {
            _businessLayer.CreatePlayer(name);
        }

        [HttpPut("[action]")]
        public void Update([FromBody] Player player)
        {
            _businessLayer.SetName(player);
        }

        [HttpPost("[action]")]
        public void Recalculate()
        {
            _businessLayer.Recalculate();

        }
    }
}
