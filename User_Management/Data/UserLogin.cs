using System.ComponentModel.DataAnnotations;

namespace User_Management.Data;

public partial class UserLogin
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }


    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? Dob { get; set; }

    public int? Gender { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")]
    public string? EmailAddress { get; set; }

    [Required]
    public string? Password { get; set; }
}
