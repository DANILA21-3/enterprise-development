namespace Hotel.Domain;

/// <summary>
/// Клиенты гостиницы
/// </summary>
public class Client
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// День рождения
    /// </summary>
    public required DateOnly BirthDate { get; set; }

    /// <summary>
    /// Серия паспорта
    /// </summary>
    public required SerialPassport { get; set; }

    /// <summary>
    /// Номер паспорта
    /// </summary>
    public required NumberPassport { get; set; }

    /// <summary>
    /// Гражданство
    /// </summary>
    public required string Citizenship { get; set; }

}
