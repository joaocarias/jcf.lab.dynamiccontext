using AutoMapper;
using Jcf.Lab.DynamicContext.Api.Data.Repositories;
using Jcf.Lab.DynamicContext.Api.Data.Repositories.IRepositories;
using Jcf.Lab.DynamicContext.Api.Models;
using Jcf.Lab.DynamicContext.Api.Models.DTOs.Client;
using Jcf.Lab.DynamicContext.Api.Models.DTOs.Report;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Jcf.Lab.DynamicContext.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : MyController
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        private readonly IUserRepository _userRepository;

        public ReportController(ILogger<ReportController> logger, IMapper mapper, IReportRepository reportRepository, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _reportRepository = reportRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var apiResponse = new ApiResponse();
            try
            {
                var user = await _userRepository.GetAsync(GetUserIdToken().GetValueOrDefault());
                if(user is null)
                {
                    apiResponse.Error(["Usuário Inválido"], HttpStatusCode.BadRequest);
                    return BadRequest(apiResponse);
                }
                    
                if(user?.Client is null || string.IsNullOrEmpty(user?.Client?.ConnectionString))
                {
                    apiResponse.Error(["Cliente Inválido ou connection string inválida"], HttpStatusCode.BadRequest);
                    return BadRequest(apiResponse);
                }

                var list = await _reportRepository.GetReportsAsync(user?.Client?.ConnectionString);
                if(list == null) 
                {
                    apiResponse.Error(["Não foi possível obter relatório"], HttpStatusCode.BadRequest);
                    return BadRequest(apiResponse);
                }

                apiResponse.Result = _mapper.Map<IEnumerable<ReportResponseDTO>>(list);
                return Ok(apiResponse);
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
