using CustomJqueryValidator.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomJqueryValidator.Data
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
        public string Code { get; set; }
    }
}
