namespace Hotel.Contracts.DTO;

public sealed record ClientDto(
    int Id,
    string LastName,
    string FirstName,
    string? Patronymic,
    DateTime BirthDate,
    string NumberPassport,
    string Citizenship);
