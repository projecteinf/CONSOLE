using System.ComponentModel.DataAnnotations;

namespace mba.apiref
{
    public partial class Email {
        public Email(string email, string type)
        {
            this.email = email;
            this.type = type;
        }
        public override string ToString()
        {
            return $"Email: {email}, Type: {type}";
        }
    }
}