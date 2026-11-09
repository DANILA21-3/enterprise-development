using Hotel.Application.Interfaces;
using Hotel.Contracts.DTO;
using Hotel.Contracts.Request;
using Hotel.Domain.Entities;
using Hotel.Domain.Interfaces;

namespace Hotel.Application.Services;

public class ClientService(IRepository<Client> repository)
    : CrudService<Client, ClientRequest, ClientDto>(repository), IClientService
{
    protected override Task<Client> BuildEntityAsync(ClientRequest request, int id) =>
        Task.FromResult(new Client
        {
            Id = id,
            LastName = request.LastName,
            FirstName = request.FirstName,
            Patronymic = request.Patronymic,
            BirthDate = request.BirthDate!.Value,
            NumberPassport = request.NumberPassport,
            Citizenship = request.Citizenship
        });

    protected override void CopyValues(Client source, Client target)
    {
        target.LastName = source.LastName;
        target.FirstName = source.FirstName;
        target.Patronymic = source.Patronymic;
        target.BirthDate = source.BirthDate;
        target.NumberPassport = source.NumberPassport;
        target.Citizenship = source.Citizenship;
    }

    protected override ClientDto ToDto(Client entity) => entity.ToDto();
}