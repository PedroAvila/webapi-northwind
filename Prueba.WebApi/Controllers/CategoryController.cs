using AutoMapper;
using Newtonsoft.Json;
using Prueba.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Prueba.WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<List<CategoryDto>> Index()
        {
            var result = await _categoryRepository.GetAll();
            var listCategoryDto = AutoMap.Mapper.Map<List<CategoryDto>>(result);
            return listCategoryDto;
        }

        // GET: api/Category/5
        /// <summary>
        /// Obtiene un objeto por su id
        /// </summary>
        /// <remarks>
        /// Obtiene un objeto por su id
        /// </remarks>
        /// <param name="id">ID del objeto</param>
        /// <response code="401">Unauthorized. No se ha indicado o es incorrecto el Token JWT de acceso.</response>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado</response>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(CategoryDto))]
        public async Task<IHttpActionResult> Single(int id)
        {
            var entity = await _categoryRepository.Single(id);
            if (entity == null)
            {
                return NotFound();
            }
            var categoryDto = AutoMap.Mapper.Map<CategoryDto>(entity);
            return Ok(categoryDto);
        }
    }
}
