using AutoMapper;
using DrugStore.Controllers.Models;
using DrugStore.Controllers.Models.DTO;
using DrugStore.Data;
using DrugStore.Services.Iservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DrugStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _database;
        private readonly IUser _user;
        private readonly ResponseDTO _reponse = new ResponseDTO();
        private readonly IJwt _jwt;
        public UserController(IMapper mapper, ApplicationDbContext context, IUser user, IJwt jwt)
        {
            _mapper = mapper;
            _user = user;
            _database = context;
            _jwt = jwt; 
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddUser(AddUserDTO newuser)
        {
            //First step of Posting is Mapping
            var newusr = _mapper.Map<User>(newuser);
            //Call the AddUser function
            var res = await _user.AddUser(newusr);
            _reponse.Result = res;
            _reponse.Message = "User created";
            return Ok(_reponse);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetUser(Guid id)
        {

            //var GetUsr = await _database.users.Where(user => user.Id == id).FirstOrDefaultAsync();
            var adduser = _user.GetUser(id);
            if (adduser == null)
            {
                return NotFound("User Not Found");
            }
            
            _reponse.Result = adduser;
            return Ok(_reponse);


        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var AllUsrs = await _user.GetUsersList();
            _reponse.Result = AllUsrs;
            return Ok(_reponse);
        }
    }
}
