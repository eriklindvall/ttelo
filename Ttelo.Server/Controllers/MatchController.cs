using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Ttelo.Server.Business;
using Ttelo.Shared.Model;

namespace Ttelo.Server.Controllers
{
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        private IBusinessLayer _businessLayer;

        public MatchController(IBusinessLayer businessLayer)
        {
            _businessLayer = businessLayer;
        }

        [HttpGet("[action]")]
        public IEnumerable<Match> List()
        {
            return _businessLayer.GetMatchesInLocalTime().ToList();
        }

        [HttpPost("[action]")]
        public void Create(int winner, int loser)
        {
            _businessLayer.CreateMatch(winner, loser);
        }

        [HttpDelete("[action]")]
        public void Delete(int id)
        {
            _businessLayer.DeleteMatch(id);
        }
    }
}
