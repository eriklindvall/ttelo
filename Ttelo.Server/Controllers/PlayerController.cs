using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Ttelo.Server.DataAccess;
using Ttelo.Server.Business;
using Ttelo.Shared.Model;

namespace Ttelo.Server.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private IDataAccessLayer _dataAccessLayer;
        private IBusinessLayer _businessLayer;

        public PlayerController(IDataAccessLayer dataAccessLayer, IBusinessLayer businessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
            _businessLayer = businessLayer;
        }
        
        [HttpGet("[action]")]
        public IEnumerable<Player> List(string sort = "rating")
        {
            if (sort == "name")
            {
                return _dataAccessLayer.GetAllPlayers().OrderBy(p => p.Name).ToList();
            }
            return _dataAccessLayer.GetAllPlayers().OrderByDescending(p => p.Rating).ToList();
        }

        [HttpPost("[action]")]
        public void Create(string name)
        {
            _businessLayer.CreatePlayer(name);
        }

        [HttpPut("[action]")]
        public void Update([FromBody] Player player)
        {
            _dataAccessLayer.SetName(player);
        }

        [HttpPost("[action]")]
        public void Recalculate()
        {
            _businessLayer.Recalculate();

        }
    }
}
