using System.Linq.Expressions;

namespace Hotel.Domain.Interfaces;

public interface IRepository<T> where T : class, IEntity
{
    /// <summary>
    /// Получение всех сущностей
    /// </summary>
    /// <returns></returns>
    public Task<IReadOnlyList<T>> GetAllAsync();

    /// <summary>
    /// Вернуть сущность
    /// </summary>
    /// <param name="id">Id сущности</param>
    /// <returns>Сущность</returns>
    public Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Добавление сущностей
    /// </summary>
    /// <param name="entity">сущность</param>
    /// <returns></returns>
    public Task<T> AddAsync(T entity);

    /// <summary>
    /// Изменить параметры сущности
    /// </summary>
    /// <param name="id">Id обновляемой сущности</param>
    /// <param name="update"></param>
    /// <returns></returns>
    public Task UpdateAsync(int id, Action<T> update);

    /// <summary>
    /// Удаление сущности 
    /// </summary>
    /// <param name="id">Id удаляемой сущности</param>
    /// <returns></returns>
    public Task DeleteAsync(int id);

    /// <summary>
    /// Проверка существования сущности по значению поля
    /// </summary>
    /// <param name="predicate">значение поля</param>
    /// <returns></returns>
    public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
}