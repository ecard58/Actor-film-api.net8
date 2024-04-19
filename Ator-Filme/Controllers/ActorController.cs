using Ator_Filme.Dtos.Actor;
using Ator_Filme.Models;
using Ator_Filme.Services.ActorService;
using Microsoft.AspNetCore.Mvc;

namespace Ator_Filme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorInterface _actorInterface;

        public ActorController(IActorInterface actorInterface)
        {
            _actorInterface = actorInterface;
        }

        [HttpGet("ListActors")]
        public async Task<ActionResult<ResponseModel<List<ActorModel>>>> ListActors()
        {
            var actors = await _actorInterface.ListActors();
            return Ok(actors);
        }

        [HttpGet("GetActorById/{actorId}")]
        public async Task<ActionResult<ResponseModel<ActorModel>>> GetActorById(int actorId)
        {
            var actor = await _actorInterface.GetActorById(actorId);
            return Ok(actor);
        }

        [HttpPost("CreateActor")]
        public async Task<ActionResult<ResponseModel<List<ActorModel>>>> CreateActor(CreateActorDto createActorDto)
        {
            var actors = await _actorInterface.CreateActor(createActorDto);
            return Ok(actors);
        }

        [HttpPut("EditActor")]
        public async Task<ActionResult<ResponseModel<List<ActorModel>>>> EditActor(EditActorDto editActorDto)
        {
            var actor = await _actorInterface.EditActor(editActorDto);
            return Ok(actor);
        }

        [HttpDelete("DeleteActor")]
        public async Task<ActionResult<ResponseModel<List<ActorModel>>>> DeleteActor(int actorId)
        {
            var actors = await _actorInterface.DeleteActor(actorId);
            return Ok(actors);
        }
    }
}
