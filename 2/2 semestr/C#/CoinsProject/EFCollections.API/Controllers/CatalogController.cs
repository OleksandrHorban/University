using EFCollections.DAL.Entities;
using EFCollections.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCollections.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private IUnitOfWork _ADOuow;
        public CatalogController(ILogger<CatalogController> logger,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
            _ADOuow = ado_unitofwork;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var results = await _ADOuow.CatalogRepository.GetAsync();
                _logger.LogInformation($"Отримали всі пости з бази даних!");
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        //GET: api/events/Id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await _ADOuow.CatalogRepository.GetByIdAsync(id);
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
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        //GET: api/events/Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _ADOuow.CatalogRepository.GetByIdAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"Івент із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }

                await _ADOuow.CatalogRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі DeleteByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] CoinsCatalog catalog)
        {
            try
            {
                var existingCatalog = await _ADOuow.CatalogRepository.GetByIdAsync(id);
                if (existingCatalog == null)
                {
                    _logger.LogInformation($"Каталог з Id: {id} не знайдено.");
                    return NotFound();
                }

                existingCatalog.Name = catalog.Name; // Оновлення інших властивостей каталогу

                await _ADOuow.CatalogRepository.UpdateAsync(existingCatalog);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція не вдалась! Помилка у методі UpdateAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Щось пішло не так!");
            }
        }

        //[HttpGet("filterByYear/{year}")]
        //public async Task<ActionResult> FilterByYearAsync(int year)
        //{
        //    try
        //    {
        //        var results = await _ADOuow.CatalogRepository.FilterByYearAsync(year);
        //        _logger.LogInformation($"Отримано каталоги за рік {year} з бази даних!");
        //        return Ok(results);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі FilterByYearAsync() - {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Щось пішло не так!");
        //    }
        //}

        //[HttpGet("filterByName/{name}")]
        //public async Task<ActionResult> FilterByNameAsync(string name)
        //{
        //    try
        //    {
        //        var results = await _ADOuow.CatalogRepository.FilterByNameAsync(name);
        //        _logger.LogInformation($"Отримано каталоги з назвою '{name}' з бази даних!");
        //        return Ok(results);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі FilterByNameAsync() - {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Щось пішло не так!");
        //    }
        //}

    }
}
