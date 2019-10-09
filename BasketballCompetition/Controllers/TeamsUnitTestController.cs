using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BasketballCompetition.Models;

namespace BasketballCompetition.Controllers
{
    public class TeamsUnitTestController : Controller
    {
        [NonAction]
        public List<Teams> GetTeamList()
        {
            return new List<Teams>
            {      new Teams
                {
                    TeamId = 18101,
                    TeamName = "Star",
                    Age = 32,
                    Phone = "0291251989",

                },
                   new Teams
                {
                    TeamId = 18102,
                    TeamName = "Lakers",
                    Age = 22,
                    Phone = "0221251989",

                },
            };
        }


        public IActionResult Index()
        {
            var teams = from s in GetTeamList() select s;
            return View(teams);
        }
        public IActionResult Teams()
        {
            var teams = from e in GetTeamList()
                        orderby e.TeamId
                        select e;
            return View(teams);
        }
    }
}