using System;
using Invoice.Dtos;
using Invoice.Models;
using Invoice.Service.DebtorService;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtController : ControllerBase
	{
        private readonly IDebtService _debtService;

        public DebtController(IDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetDebtorDto>>>> Get()
        {
            return Ok(await _debtService.GetAllDebts());
        }

        [HttpPost("add-debtor")]
        public async Task<ActionResult<ServiceResponse<List<GetDebtorDto>>>> AddDebt(AddDebtorDto newDebt)
        {

            return Ok(await _debtService.AddDebt(newDebt));
        }

        [HttpPut("edit-debtor-info")]
        public async Task<ActionResult<ServiceResponse<GetDebtorDto>>> UpdatedDebt(UpdateDebtDto updatedDebt)
        {
            var response = await _debtService.UpdateDebt(updatedDebt);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetReport")]
        public async Task<ActionResult<ServiceResponse<DebtReportDto>>> GetReport(DateTime startDate, DateTime endDate)
        {
            var serviceResponse = await _debtService.GetDebtReport(startDate, endDate);
            return Ok(serviceResponse);
        }
    }
}

