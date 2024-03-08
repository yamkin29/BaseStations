using System.ComponentModel.DataAnnotations;

namespace BaseStations.Models
{
    public class BaseStation
    {
        [Key]
        public int Id { get; set; }

        public string Number { get; set; }

        public string Frequency { get; set; }

        public string Coordinates { get; set; }

        public string Address { get; set; }

        public string Operator { get; set; }
    }
}
