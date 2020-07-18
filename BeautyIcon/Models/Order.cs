using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyIcon.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        [Display(Name="First name")]
        [Required]
        [StringLength(25)]
        public String FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        [StringLength(50)]
        public String LastName { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public String City { get; set; }
        public String State { get; set; }
        [Required]
        public String Country { get; set; }
        public String ZipCode { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        [BindNever]
        public decimal OrderTotal { get; set; }
        [BindNever]
        public DateTime OrderPlaced { get; set; }


    }
}
