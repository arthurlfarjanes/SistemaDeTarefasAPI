using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Respositories.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;   
        }
        
        // Endpoint para buscar todas as tarefas
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
        {
            List<TarefaModel> tarefas = await _tarefaRepository.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        // Endpoint para buscar uma única tarefa
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepository.BuscarPorId(id);
            return Ok(tarefa);
        }

        // Endpoint para cadastrar tarefa
        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepository.Adicionar(tarefaModel);
            return Ok(tarefa);
        }

        // Endpoint para atualizar tarefa
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepository.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }

        // Endpoint para deletar tarefa
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Apagar(int id)
        {
            bool apagado = await _tarefaRepository.Apagar(id);
            return Ok(apagado);
        }
    }
}
