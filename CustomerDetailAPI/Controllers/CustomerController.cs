using Microsoft.AspNetCore.Mvc;
using CustomerDetailAPI.Services;

namespace CustomerDetailAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private List<Customer> _testProducts;

        public CustomerController(ICustomerRepository customer)
        {
            _customerRepository = customer;

        }

        //Get request 
        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] FromQueryCustomer request)
        {


            IQueryable<Customer> query = _customerRepository.GetAll();


            /*if(idFiltered!=null && idFiltered.Any())
            {
                response.AddRange(idFiltered); //tek tek veri giriþi saðlamak için kullanýlýr.
          
            } */

            if (request.Id > 0)
            {
                query = query.Where(x => x.Id == request.Id);

            }
            if (request.Id <= 0)
            {
                return NotFound();
            }

            //IsNullOrWhiteSpace => boþ veya null ise olmasý kontrolu saðlýyor
            if (!String.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(x => x.Name == request.Name);
            }

            if (!String.IsNullOrWhiteSpace(request.LastName))
            {
                query = query.Where(x => x.LastName == request.LastName);
            }

            if (request.Phone != null)
            {
                query = query.Where(x => x.Phone == request.Phone);
            }

            if (request.CreatedAt != null)
            {
                query = query.Where(x => x.CreatedAt == request.CreatedAt);
            }

            if (request.UpdateAt != null)
            {
                query = query.Where(x => x.UpdateAt == request.UpdateAt);
            }

            if (request.isEnabled != null)
            {
                query = query.Where(x => x.isEnabled == request.isEnabled);
            }

            return Ok(query.ToList());


        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getRequest = _customerRepository.GetById(id);
            if (getRequest == null)
                return BadRequest("Deneme not found.");
            return Ok(getRequest);
        }

        //Post request- Adding process was succes
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customerAdd)
        {
            _customerRepository.AddCustomer(customerAdd);

            return Ok(new { message = "User created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer request)
        {
            _customerRepository.UpdateCustomer(id, request);
            return Ok(new { message = "User updated" });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
            return Ok(new { message = "User deleted" });

        }
    }
    }

