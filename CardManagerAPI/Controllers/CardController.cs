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

        [HttpPost("add-card")]
        public IActionResult AddCard(Card card)
        {
            DBManager dbm = new DBManager();

            dbm.AddCard(card);

            return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
        }
    }

}
