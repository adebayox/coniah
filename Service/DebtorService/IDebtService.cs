using System;
using Invoice.Dtos;
using Invoice.Models;

namespace Invoice.Service.DebtorService
{
	public interface IDebtService
	{
        object Debts { get; }

        Task<ServiceResponse<List<GetDebtorDto>>> GetAllDebts();

        Task<ServiceResponse<List<GetDebtorDto>>> AddDebt(AddDebtorDto newDebt);

        Task<ServiceResponse<GetDebtorDto>> UpdateDebt(UpdateDebtDto updatedDebt);

        Task<ServiceResponse<List<GetDebtorDto>>> DeleteDebt(string name);

        Task<ServiceResponse<DebtReportDto>> GetDebtReport(DateTime startDate, DateTime endDate);
    }
}

