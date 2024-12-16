using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewWebAPI_MAB.Models;
using NewWebAPI_MAB.Repositories;

namespace NewWebAPI_MAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region GetAll Users
        [HttpGet]
        public IActionResult Index()
        {
            var users = _userRepository.SelectAll();
            return Ok(users);
        }
        #endregion

        #region GetByID User
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.SelectByPK(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        #endregion

        #region Delete User
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var isDeleted = _userRepository.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
        #endregion

        #region InsertUser
        [HttpPost]
        public IActionResult InsertUser([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            bool isInserted = _userRepository.Insert(user);

            if (isInserted)
                return Ok(new { Message = "User inserted..." });
            return StatusCode(500, "An error occureed");
        }
        #endregion


        #region UpdateUser
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel user)
        {
            if (user == null || id != user.UserID)
            {
                return BadRequest();
            }

            var isUpdated = _userRepository.Update(user);

            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion
    }
}
