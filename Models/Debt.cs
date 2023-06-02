using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Models
{
	public class Debt
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Debtor_Name { get; set; }

        public string Amount { get; set; }

        public string Phone_Number { get; set; }

        public string Goods_Purchased { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

