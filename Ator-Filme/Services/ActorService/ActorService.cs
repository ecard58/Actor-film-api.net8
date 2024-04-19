using Ator_Filme.Data;
using Ator_Filme.Dtos.Actor;
using Ator_Filme.Models;
using Microsoft.EntityFrameworkCore;

namespace Ator_Filme.Services.ActorService
{
    public class ActorService : IActorInterface
    {
        private readonly AppDbContext _context;

        public ActorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ActorModel>>> CreateActor(CreateActorDto createActorDto)
        {
            ResponseModel<List<ActorModel>> resposta = new ResponseModel<List<ActorModel>>();
            try
            {
                var actor = new ActorModel
                {
                    Name = createActorDto.Name
                };

                _context.Add(actor);
                await _context.SaveChangesAsync();

                resposta.Data = await _context.Actors.ToListAsync();
                resposta.Message = "Actor successfully created.";
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ActorModel>>> DeleteActor(int actorId)
        {
            ResponseModel<List<ActorModel>> resposta = new ResponseModel<List<ActorModel>>();
            try
            {
                var actor = await _context.Actors.FirstOrDefaultAsync(ab => ab.Id == actorId);
                if (actor == null)
                {
                    resposta.Message = "Actor not found.";
                    return resposta;
                }
                _context.Remove(actor);
                await _context.SaveChangesAsync();
                resposta.Data = await _context.Actors.ToListAsync();

                resposta.Message = "Actor successfully deleted.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ActorModel>>> EditActor(EditActorDto editActorDto)
        {
            ResponseModel<List<ActorModel>> resposta = new ResponseModel<List<ActorModel>>();
            try
            {
                var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == editActorDto.Id);
                if(actor == null)
                {
                    resposta.Message = "Actor not found.";
                    return resposta;
                }

                actor.Name = editActorDto.Name;
                
                _context.Update(actor);
                await _context.SaveChangesAsync();

                resposta.Data = await _context.Actors.ToListAsync();
                resposta.Message = "Actor successfully edited.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ActorModel>> GetActorById(int actorId)
        {
            ResponseModel<ActorModel> resposta = new ResponseModel<ActorModel>();
            try
            {
                var actor = await _context.Actors.FirstOrDefaultAsync(ab => ab.Id == actorId);

                if (actor == null)
                {
                    resposta.Message = "Actor not found.";
                    return resposta;
                }
                resposta.Data = actor;
                resposta.Message = "Actor found.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ActorModel>>> ListActors()
        {
            ResponseModel<List<ActorModel>> resposta = new ResponseModel<List<ActorModel>>();
            try
            {
                var actors = await _context.Actors.ToListAsync();

                resposta.Data = actors;
                resposta.Message = "Actors collected.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
