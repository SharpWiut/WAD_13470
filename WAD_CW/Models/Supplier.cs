using System.ComponentModel.DataAnnotations;

namespace SPI.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        private string _name;

        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                _name = value;
            }
        }

        public string? ContactPerson { get; set; }

        private string _email;

        [Required(ErrorMessage = "Email is required")]
        public string Email
        {
            get => _email;
            set { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email cannot be null or empty");
                }
                _email = value;
            }
        }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public DateTime LastContactDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<SparePart>? SpareParts { get; set; }

    }
}
