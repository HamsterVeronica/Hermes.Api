
namespace Hermes.Api.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string SecretWord { get; set; }
    }
}
