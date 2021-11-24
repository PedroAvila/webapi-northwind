using AutoMapper;
using Newtonsoft.Json;
using Prueba.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public List<CategoryDto> Index()
        {
            var result = _categoryRepository.GetAll();
            var listCategoryDto = AutoMap.Mapper.Map<List<CategoryDto>>(result);
            return listCategoryDto;
        }
    }
}
