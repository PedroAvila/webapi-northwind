using Prueba.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Prueba.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;
        
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("base/ListarCustomer")]
        public async Task<List<CustomerDto>> Index()
        {
            var result = await _customerRepository.GetAll();
            var listCustomerDto = AutoMap.Mapper.Map<List<CustomerDto>>(result);
            return listCustomerDto;
        }

        [HttpGet]
        [Route("base/GetCustomer")]
        public async Task<PaginadorGenerico<CustomerDto>> GetCustomer(string buscar, string orden = "CustomerID", string tipoOrden = "ASC", int pagina = 1, int registrosPorPagina = 10)
        {
            List<CustomerDto> _customerDto;
            PaginadorGenerico<CustomerDto> _paginadorGenerico;

            var result = await _customerRepository.GetAll();
            _customerDto = AutoMap.Mapper.Map<List<CustomerDto>>(result);

            if (!string.IsNullOrEmpty(buscar))
            {
                foreach (var item in buscar.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    _customerDto = _customerDto.Where(x => x.ContactName.Contains(item) ||
                                                        x.CompanyName.Contains(item) ||
                                                        x.City.Contains(item)).ToList();
                }
            }

            switch (orden)
            {
                case "CustomerID":
                    if (tipoOrden.ToLower() == "desc")
                        _customerDto = _customerDto.OrderByDescending(x => x.CustomerID).ToList();
                    else if (tipoOrden.ToLower() == "asc")
                        _customerDto = _customerDto.OrderBy(x => x.CustomerID).ToList();
                    break;
                case "CompanyName":
                    if (tipoOrden.ToLower() == "desc")
                        _customerDto = _customerDto.OrderByDescending(x => x.CompanyName).ToList();
                    else if (tipoOrden.ToLower() == "asc")
                        _customerDto = _customerDto.OrderBy(x => x.CompanyName).ToList();
                    break;
                case "ContactName":
                    if (tipoOrden.ToLower() == "desc")
                        _customerDto = _customerDto.OrderByDescending(x => x.ContactName).ToList();
                    else if (tipoOrden.ToLower() == "asc")
                        _customerDto = _customerDto.OrderBy(x => x.ContactName).ToList();
                    break;

                default:
                    if (tipoOrden.ToLower() == "desc")
                        _customerDto = _customerDto.OrderByDescending(x => x.CustomerID).ToList();
                    else if (tipoOrden.ToLower() == "asc")
                        _customerDto = _customerDto.OrderBy(x => x.CustomerID).ToList();
                    break;
            }

            // Paginación
            int totalRegistros = 0;
            int totalPaginas = 0;
            // Números total de registros de la tabla Customers
            totalRegistros = _customerDto.Count();
            // Obtenemos la página de registros de la tabla Customers
            _customerDto = _customerDto.Skip((pagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();
            // Número total de páginas de la tabla Customers
            totalPaginas = (int)Math.Ceiling((double)totalRegistros / registrosPorPagina);
            // Instanciaamos la clase de paginación y asignamos los nuevos valores
            _paginadorGenerico = new PaginadorGenerico<CustomerDto>()
            {
                RegistrosPorPagina = registrosPorPagina,
                TotalRegistros = totalRegistros,
                TotalPaginas = totalPaginas,
                PaginaActual = pagina,
                BusquedaActual = buscar,
                OrdenActual = orden,
                TipoOrdenActual = tipoOrden,
                Resultado = _customerDto
            };
            return _paginadorGenerico;
        }

    }
}