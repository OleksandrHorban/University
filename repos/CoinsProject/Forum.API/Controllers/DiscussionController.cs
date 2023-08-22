using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ForumDAL.Entities;
//using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using ForumDAL.Repositories.Contracts;
using Forum.BLL.Interfaces;
using Forum.BLL.DTOs;

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscussionController : ControllerBase
    {
        private readonly ILogger<DiscussionController> _logger;
        private readonly IDiscussionService _postService;
        private IUnitOfWork _ADOuow;
        public DiscussionController(ILogger<DiscussionController> logger,
            IUnitOfWork ado_unitofwork, IDiscussionService postService)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
            _postService = postService;
        }

        [HttpGet("BLL-GetById")]
        public async Task<ActionResult<DiscussionDto>> GetPostById(int id)
        {
            var discussions = await _postService.GetDiscussionById(id);
            
            try
            {
                _ADOuow.Commit();
                if (discussions == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали івент з бази даних!");
                    return Ok(discussions);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetPostById() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("BLL-GetAllDiscussions")]
        public async Task<ActionResult<IEnumerable<DiscussionDto>>> GetAllDiscussions()
        {
            try
            {
                var results = await _postService.GetAllDiscussions();
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllDiscussions() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        [HttpGet("GetAverageLikes")]
        public async Task<ActionResult<int>> GetAverageLikesAsync()
        {
            try
            {
                var results = await _postService.GetAverageLikes();
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAverageLikes() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discussion>>> GetAllDiscussionsAsync()
        {
            try
            {
                var results = await _ADOuow._discussionRepository.GetAllAsync();
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllDiscussionsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }

        //GET: api/events/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Discussion>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _ADOuow._discussionRepository.GetAsync(id);
                _ADOuow.Commit();
                if (result  == null)
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
        public async Task<ActionResult> DiscussionEventAsync([FromBody] Discussion evnt)
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
                var created_id = await _ADOuow._discussionRepository.AddAsync(evnt);
                _ADOuow.Commit();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі DiscussionEventAsync - {ex.Message}");
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

                var event_entity =  await _ADOuow._discussionRepository.GetAsync(id);
                if(event_entity == null)
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
                var event_entity = await _ADOuow._discussionRepository.GetAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow._discussionRepository.DeleteAsync(id);
                _ADOuow.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі DeleteByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "та шо ж таке!");
            }
        }

       
        /// Додає зв'язок мені ту мені між таблицями Discussion і Definition у таблицю DisDef
        /// <param name="discussionId"></param>
        /// <param name="definitionName"></param>
        /// <returns></returns>
        [HttpPost("AddDefToDis (adding id's to DisDef)")]
        public async Task<ActionResult> AddDefinitionToDiscussionAsync(int discussionId, string definitionName)
        {
            try
            {
                var event_entity = await _ADOuow._discussionRepository.GetAsync(discussionId);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {discussionId}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow._discussionRepository.AddDefToDis(discussionId, definitionName);
                _ADOuow.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі AddDefinitionToDiscussionAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }





        [HttpGet("GetAllDefinitionsByDiscussionId")]
        public async Task<ActionResult<IEnumerable<Discussion>>> GetAllDefinitionsByDiscussionId(int discussionId)
        {
            try
            {
                var results = await _ADOuow._discussionRepository.GetAllDefinitionByDiscussionIdAsync(discussionId);
                _ADOuow.Commit();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllDefinitionsByDiscussionId() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
