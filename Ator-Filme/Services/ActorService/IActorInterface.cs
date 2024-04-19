using Ator_Filme.Dtos.Actor;
using Ator_Filme.Models;

namespace Ator_Filme.Services.ActorService
{
    public interface IActorInterface
    {
        Task<ResponseModel<List<ActorModel>>> ListActors();
        Task<ResponseModel<ActorModel>> GetActorById(int actorId);
        Task<ResponseModel<List<ActorModel>>> CreateActor(CreateActorDto createActorDto);
        Task<ResponseModel<List<ActorModel>>> EditActor(EditActorDto editActorDto);
        Task<ResponseModel<List<ActorModel>>> DeleteActor(int actorId);

    }
}
