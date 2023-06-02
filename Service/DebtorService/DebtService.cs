using System;
using AutoMapper;
using Invoice.Data;
using Invoice.Dtos;
using Invoice.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Service.DebtorService
{
	public class DebtService : IDebtService
	{
        private static List<Debt> Debts = new List<Debt>
        {
            new Debt(),

        };
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DebtService(IMapper mapper, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        object IDebtService.Debts => throw new NotImplementedException();

        public async Task<ServiceResponse<List<GetDebtorDto>>> AddDebt(AddDebtorDto newDebt)
        {
            var serviceResponse = new ServiceResponse<List<GetDebtorDto>>();
            var debt = _mapper.Map<Debt>(newDebt);
            _context.Debts.Add(debt);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Debts
           .Select(c => _mapper.Map<GetDebtorDto>(c))
           .ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDebtorDto>>> DeleteDebt(string name)
        {
            var serviceResponse = new ServiceResponse<List<GetDebtorDto>>();
            try
            {
                var debt = await _context.Debts
                    .FirstOrDefaultAsync(c => c.Debtor_Name == name);
                if (debt is null)

                    throw new Exception($"Debtor with Name '{name}' not found.");

                _context.Debts.Remove(debt);

                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Debts
                        .Select(c => _mapper.Map<GetDebtorDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDebtorDto>>> GetAllDebts()
        {
            var serviceResponse = new ServiceResponse<List<GetDebtorDto>>();
            var debts = await _context.Debts.ToListAsync();
            serviceResponse.Data = debts.Select(c => _mapper.Map<GetDebtorDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<DebtReportDto>> GetDebtReport(DateTime startDate, DateTime endDate)
        {
            var serviceResponse = new ServiceResponse<DebtReportDto>();

            try
            {
                var debts = await _context.Debts
                    .Where(l => l.CreatedAt >= startDate && l.CreatedAt <= endDate)
                    .ToListAsync();

                var laptopReportDto = new DebtReportDto
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    Debts = _mapper.Map<List<GetDebtorDto>>(debts)
                };

                serviceResponse.Data = laptopReportDto;
            }
            catch (Exception ex)
            {
                // Handle any exceptions and set appropriate error message
                serviceResponse.Success = false;
                serviceResponse.Message = "Error occurred while retrieving the laptop report.";
                // You can log the exception for further investigation
                // logger.LogError(ex, "Error occurred while retrieving the laptop report.");
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDebtorDto>> UpdateDebt(UpdateDebtDto updatedDebt)
        {
            var serviceResponse = new ServiceResponse<GetDebtorDto>();
            try
            {
                var debt
                        = await _context.Debts
                        .FirstOrDefaultAsync(c => c.Debtor_Name == updatedDebt.Debtor_Name);
                if (debt is null)
                    throw new Exception($"Debtor with Name '{updatedDebt.Debtor_Name}'not found.");

                debt.Debtor_Name = updatedDebt.Debtor_Name;
                debt.Amount = updatedDebt.Amount;
                debt.Phone_Number = updatedDebt.Phone_Number;
                debt.Goods_Purchased = updatedDebt.Goods_Purchased;
                debt.CreatedAt = updatedDebt.CreatedAt;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetDebtorDto>(debt);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}

