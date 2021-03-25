using Appointment.API.Data.Contracts;
using Appointment.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace Appointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;

        public SecurityController(IUnitOfWork unitOfWork, IMapper mapper, ISecurityService securityService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _securityService = securityService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequestDto model)
        {
            var response = _securityService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}