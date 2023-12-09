using AutoMapper;
using Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories;
using Jcf.Lab.DynamicContext.Api.Models;
using Jcf.Lab.DynamicContext.Api.Models.DTOs.User;
using Jcf.Lab.DynamicContext.Api.Models.Records.User;
using Jcf.Lab.DynamicContext.Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Jcf.Lab.DynamicContext.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : MyController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository, IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            var apiResponse = new ApiResponse();
            try
            {
                var user = await _userRepository.GetAsync(id);
                if (user == null)
                {
                    apiResponse.Error(["Não encontrado"], HttpStatusCode.NotFound);
                    return NotFound(apiResponse);
                }

                apiResponse.Result = _mapper.Map<UserResponseDTO>(user);
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                apiResponse.Error(new List<string> { ex.Message });
                return BadRequest(apiResponse);
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var apiResponse = new ApiResponse();
            try
            {
                apiResponse.Result = _mapper.Map<IEnumerable<UserResponseDTO>>(await _userRepository.GetAllAsync());
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                apiResponse.Error(new List<string> { ex.Message });
                return BadRequest(apiResponse);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Novo([FromBody] CreateUser create)
        {
            var apiResponse = new ApiResponse();
            try
            {
                var user = _mapper.Map<User>(create);
                user.SetPassword(PasswordUtil.CreateHashMD5(create.Password));

                await _userRepository.CreateAsync(user);
                var userResponseDTO = _mapper.Map<UserResponseDTO>(user);
                apiResponse.Result = userResponseDTO;
                apiResponse.StatusCode = HttpStatusCode.Created;
                return CreatedAtAction(nameof(Get), new { id = user.Id }, apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                apiResponse.Error([ex.Message]);
                return BadRequest(apiResponse);
            }
        }
    }
}
