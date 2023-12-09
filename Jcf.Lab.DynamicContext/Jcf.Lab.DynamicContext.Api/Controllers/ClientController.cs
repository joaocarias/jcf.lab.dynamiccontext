using Jcf.Lab.DynamicContext.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using AutoMapper;
using Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories;
using Jcf.Lab.DynamicContext.Api.Models.DTOs.Client;
using Jcf.Lab.DynamicContext.Api.Models.Records.Client;

namespace Jcf.Lab.DynamicContext.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : MyController
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientController(ILogger<ClientController> logger, IMapper mapper, IClientRepository clientRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            var apiResponse = new ApiResponse();
            try
            {
                var client = await _clientRepository.GetAsync(id);
                if (client == null)
                {
                    apiResponse.Error(["Não encontrado"], HttpStatusCode.NotFound);
                    return NotFound(apiResponse);
                }

                apiResponse.Result = _mapper.Map<ClientResponseDTO>(client);
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                apiResponse.Error([ex.Message]);
                return BadRequest(apiResponse);
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var apiResponse = new ApiResponse();
            try
            {
                apiResponse.Result = _mapper.Map<IEnumerable<ClientResponseDTO>>(await _clientRepository.GetAllAsync());
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
        public async Task<IActionResult> Create([FromBody] CreateClient create)
        {
            var apiResponse = new ApiResponse();
            try
            {
                var client = new Client(create.Name, create.ConnectionString);              
                await _clientRepository.CreateAsync(client);
                var clientResponseDTO = _mapper.Map<ClientResponseDTO>(client);
                apiResponse.Result = clientResponseDTO;
                apiResponse.StatusCode = HttpStatusCode.Created;
                return CreatedAtAction(nameof(Get), new { id = client.Id }, apiResponse);
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
