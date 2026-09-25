namespace Hotel.Domain;

public class Client
{
    public required int Id { get; set; }

    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public string? Patronymic { get; set; }

    public required DateOnly BirthDate { get; set; }

    public required SerialPassport { get; set; }
    public required NumberPassport { get; set; }

    public required string Citizenship { get; set; }

}
