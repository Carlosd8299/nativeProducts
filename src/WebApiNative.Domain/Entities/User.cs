using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApiNative.Domain.Entities
{
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
    }
}
