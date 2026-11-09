namespace Hotel.Application.Interfaces;

/// <summary>
/// Интерфейс для работы с запросами
/// </summary>
/// <typeparam name="TRequest">Запрос</typeparam>
/// <typeparam name="TDto">Dto</typeparam>
public interface ICrudService<TRequest, TDto>
{
    /// <summary>
    /// Получение всех записей
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<TDto>> GetAllAsync();

    /// <summary>
    /// Вернуть запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<TDto> GetAsync(int id);

    /// <summary>
    /// Добавление записи
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<TDto> CreateAsync(TRequest request);

    /// <summary>
    /// Обновление существующей записи
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task UpdateAsync(int id, TRequest request);

    /// <summary>
    /// Удалить запись
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(int id);
}