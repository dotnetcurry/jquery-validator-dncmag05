using CustomJqueryValidator.Data;
using CustomJqueryValidator.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomJqueryValidator.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Street { get; set; }
        [MaxLength(200)]
        public string Area { get; set; }
        [MaxLength(200)]
        public string State { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [DynamicLengthValidation("CountryId", "data-length", "SelectedCountryCodeLength")]
        public string Code { get; set; }

        [NotMapped]
        public int SelectedCountryCodeLength { get; set; }

    }
}