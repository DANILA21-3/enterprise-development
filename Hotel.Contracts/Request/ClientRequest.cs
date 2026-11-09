using System.ComponentModel.DataAnnotations;

namespace Hotel.Contracts.Request;

/// <summary>
/// Обработка запросов на создание сущностей
/// </summary>
public sealed class ClientRequest
{
    [Required, StringLength(100)]
    public string LastName { get; init; } = string.Empty;

    [Required, StringLength(100)]
    public string FirstName { get; init; } = string.Empty;

    [StringLength(100)]
    public string? Patronymic { get; init; }

    [Required]
    public DateTime? BirthDate { get; init; }

    [Required, StringLength(20)]
    public string NumberPassport { get; init; } = string.Empty;

    [Required, StringLength(50)]
    public string Citizenship { get; init; } = string.Empty;
}