using System;
namespace Invoice.Dtos
{
	public class DebtReportDto
	{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<GetDebtorDto> Debts { get; set; }
    }
}

