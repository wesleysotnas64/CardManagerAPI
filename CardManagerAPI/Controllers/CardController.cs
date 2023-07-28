using Microsoft.AspNetCore.Mvc;
using CardManagerAPI.Data;
using CardManagerAPI.Models;

namespace CardManagerAPI.Controllers
{
    [ApiController]
    [Route("card-manager-api/")]
    public class CardController : ControllerBase
    {
        [HttpGet("get-all-cards")]
        public IActionResult GetAllCards()
        {
            DBManager dbm = new DBManager();

            List<Card> cards = dbm.GetAllCards();

            return Ok(cards);
        }

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

        [HttpDelete("delete-card/cardid")]
        public IActionResult DeleteCard(int cardid)
        {
            DBManager dbm = new DBManager();

            dbm.DeleteCard(cardid);

            return NoContent();
        }

        [HttpPut("update-card")]
        public IActionResult UpdateCard(Card card)
        {
            DBManager dbm = new DBManager();

            dbm.UpdateCard(card);

            return NoContent();
        }
    }

}
