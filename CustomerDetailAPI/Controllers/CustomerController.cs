using Microsoft.AspNetCore.Mvc;
using CustomerDetailAPI.DB;
using Microsoft.EntityFrameworkCore;
using CustomerDetailAPI;

namespace customerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly DataContext _context;


        public CustomerController(DataContext context)
        {
            _context = context;
        }


        //Get request 
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] FromQueryCustomer request)
        {


            IQueryable<Customer> query = _context.CustomersDb.AsNoTracking();


            /*if(idFiltered!=null && idFiltered.Any())
            {
                response.AddRange(idFiltered); //tek tek veri giriþi saðlamak için kullanýlýr.
          
            } */

            if (request.Id > 0)
            {
                query = query.Where(x => x.Id == request.Id);
                
            }
            if (request.Id < 0) 
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

            if (request.IsEnabled != null)
            {
                query = query.Where(x => x.IsEnabled == request.IsEnabled);
            }

            return Ok(query.ToList());


        }




        //Get request parse id
        /*  [HttpGet("{name}")]
          public async Task<ActionResult<List<Customer>>> Get(String Name)
          {
              var deneme = await _context.customersdb.FindAsync(Name);
              if (deneme == null)
                  return BadRequest("Deneme not found.");
              return Ok(deneme);
          }*/
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Customer>>> Get(int id)
        {
            var getRequest = await _context.CustomersDb.FindAsync(id);
            if (getRequest == null)
                return BadRequest("Deneme not found.");
            return Ok(getRequest);
        }

        //Post request- Adding process was succes
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer customerAdd)
        {
            _context.CustomersDb.Add(customerAdd);
            await _context.SaveChangesAsync();
            return Ok(await _context.CustomersDb.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer request)
        {
            var updateCustomer = await _context.CustomersDb.FindAsync(request.Id);
            if (updateCustomer == null)
                return BadRequest("Deneme not found.");

            updateCustomer.Name = request.Name;
            updateCustomer.LastName = request.LastName;
            updateCustomer.Phone = request.Phone;
            updateCustomer.CreatedAt = request.CreatedAt;
            updateCustomer.UpdateAt = request.UpdateAt;
            updateCustomer.IsEnabled = request.IsEnabled;


            await _context.SaveChangesAsync();
            return Ok(await _context.CustomersDb.ToListAsync());
        }
        // Delete process on id
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var deleteRequest = await _context.CustomersDb.FindAsync(id);
            if (deleteRequest == null)
                return BadRequest("Deneme not found.");

            _context.CustomersDb.Remove(deleteRequest);

            await _context.SaveChangesAsync();
            return Ok(await _context.CustomersDb.ToListAsync());

        }
    }
}
