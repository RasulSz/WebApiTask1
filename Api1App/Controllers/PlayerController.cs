using Api1App.Dtos;
using Api1App.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api1App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        public static List<Player> Players { get; set; } = new List<Player>
        {
            new Player
            {
                Id = 1,
                City = "Lankaran",
                PlayerName = "Rasul",
                Score = 100,
            },
            new Player
            {
                Id = 2,
                City = "Baku",
                PlayerName = "Nizami",
                Score = 100,
            },
            new Player
            {
                Id = 3,
                City = "Nakhcivan",
                PlayerName = "Yura",
                Score = 50,
            }
        };
        [HttpGet]
        public IEnumerable<PlayerDto> Get()
        {
            var result = Players.Select(x =>
            {
                return new PlayerDto
                {
                    Id = x.Id,
                    PlayerName = x.PlayerName,
                    Score = x.Score,
                };
            });
            return result;
        }

        [HttpGet("{id}")]
        public PlayerDto Get(int id)
        {
            var player = Players.FirstOrDefault(x => x.Id == id);
            if(player != null)
            {
                var dataToReturn = new PlayerDto
                {
                    Id = player.Id,
                    PlayerName = player.PlayerName,
                    Score = player.Score,
                };
                return dataToReturn;
            }
            return null;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PlayerAddDto dto)
        {
            try
            {
                var player = new Player
                {
                    City = dto.City,
                    PlayerName = dto.PlayerName,
                    Score = dto.Score,
                    Id = dto.Id,
                };
                Players.Add(player);
                return Ok(player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("id")]
        public IActionResult Put(int id,[FromBody] PlayerAddDto dto)
        {
            try
            {
                var item = Players.FirstOrDefault(x => x.Id == id);
                if(item == null)
                {
                    return NotFound();
                }
                item.City = dto.City;
                item.PlayerName = dto.PlayerName;
                item.Score = dto.Score;
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = Players.FirstOrDefault(p=>p.Id == id);
                if(item == null)
                {
                    return NotFound();
                }
                Players.Remove(item);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
