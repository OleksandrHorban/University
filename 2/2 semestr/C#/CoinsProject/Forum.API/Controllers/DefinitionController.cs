using ForumDAL.Entities;
using ForumDAL.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionController : ControllerBase
    {
        private readonly ILogger<DefinitionController> _logger;
        private IUnitOfWork _ADOuow;
        public DefinitionController(ILogger<DefinitionController> logger,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Definition>>> GetAllDefinitionsAsync()
        {
            try
            {
                var results = await _ADOuow._definitionRepository.GetAllAsync();
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всі теги з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllDefinitionAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //GET: api/events/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Definition>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _ADOuow._definitionRepository.GetAsync(id);
                _ADOuow.Commit();
                if (result == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали івент з бази даних!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //POST: api/events
        [HttpPost]
        public async Task<ActionResult> PostEventAsync([FromBody] Definition evnt)
        {
            try
            {
                if (evnt == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }
                var created_id = await _ADOuow._definitionRepository.AddAsync(evnt);
                _ADOuow.Commit();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostEventAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //POST: api/events/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] Discussion evnt)
        {
            try
            {
                if (evnt == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт івенту є некоректним");
                }

                var event_entity = await _ADOuow._definitionRepository.GetAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow._discussionRepository.ReplaceAsync(evnt);
                _ADOuow.Commit();
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі UpdateEventAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //GET: api/events/Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _ADOuow._definitionRepository.GetAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow._definitionRepository.DeleteAsync(id);
                _ADOuow.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі DeleteByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        /// Додає зв'язок many to many між таблицями Discussion і Definition у таблицю DisDef
        /// 
        /// 
        /// <param name="discussionId"></param>
        /// <param name="definitionName"></param>
        /// <returns></returns>
        [HttpPost("Add Definition to Discussion  {discussionId}, {definitionName}")]
        public async Task<ActionResult> AddDefinitionToDiscussionAsync(int discussionId, string definitionName)
        {
            try
            {
                var event_entity = await _ADOuow._definitionRepository.GetAsync(discussionId);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {discussionId}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow._definitionRepository.AddDefToDis(discussionId, definitionName);
                _ADOuow.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі AddDefinitionToDiscussionAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
