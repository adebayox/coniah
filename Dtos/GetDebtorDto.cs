using System;
namespace Invoice.Dtos
{
	public class GetDebtorDto
	{
        public int Id { get; set; }

        public string Debtor_Name { get; set; }

        public string Amount { get; set; }

        public string Phone_Number { get; set; }

        public string Goods_Purchased { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

