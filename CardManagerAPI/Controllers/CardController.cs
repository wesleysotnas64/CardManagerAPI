using Microsoft.AspNetCore.Mvc;
using CardManagerAPI.Data;
using CardManagerAPI.Models;

namespace CardManagerAPI.Controllers
{
    [ApiController]
    [Route("card-manager-api/")]
    public class CardController : ControllerBase
    {
        [HttpGet("get-card/id")]
        public IActionResult GetCard(int id)
        {
            DBManager dbm = new DBManager();

            Card card = dbm.GetCard(id);

            return Ok(card);
        }
    }

}
