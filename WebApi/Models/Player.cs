namespace WebApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public DateOnly Birthdate { get; set; }
        public bool Sex { get; set; }
        public string Email { get; set; } = string.Empty;
        public string CellphoneNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }

    }
}
