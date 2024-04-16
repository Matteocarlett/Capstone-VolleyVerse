using System.ComponentModel.DataAnnotations;

namespace VolleyVerse.Models
{
    public class RegisterViewModel
    {
        private string _nome;
        private string _cognome;
        private string _email;

        [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
        public string Nome
        {
            get => _nome;
            set => _nome = value?.Trim().ToLowerInvariant();
        }

        [Required(ErrorMessage = "Il campo Cognome è obbligatorio.")]
        public string Cognome
        {
            get => _cognome;
            set => _cognome = value?.Trim().ToLowerInvariant();
        }

        [Required(ErrorMessage = "Il campo Email è obbligatorio.")]
        [EmailAddress(ErrorMessage = "Inserisci un indirizzo email valido.")]
        public string Email
        {
            get => _email;
            set => _email = value?.Trim().ToLowerInvariant();
        }

        [Required(ErrorMessage = "Il campo Password è obbligatorio.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La password e la conferma della password non corrispondono.")]
        public string ConfirmPassword { get; set; }

        public string Ruolo { get; set; }
    }
}
