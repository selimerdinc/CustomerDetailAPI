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
        public async Task<IActionResult> Get([FromQuery] fromQuery request)
        {


            IQueryable<Customer> query = _context.customersdb.AsNoTracking();


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

            if (!String.IsNullOrWhiteSpace(request.lastName))
            {
                query = query.Where(x => x.lastName == request.lastName);
            }

            if (request.Phone != null)
            {
                query = query.Where(x => x.Phone == request.Phone);
            }

            if (request.createdAt != null)
            {
                query = query.Where(x => x.createdAt == request.createdAt);
            }

            if (request.updateAt != null)
            {
                query = query.Where(x => x.updateAt == request.updateAt);
            }

            if (request.isEnabled != null)
            {
                query = query.Where(x => x.isEnabled == request.isEnabled);
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
            var deneme = await _context.customersdb.FindAsync(id);
            if (deneme == null)
                return BadRequest("Deneme not found.");
            return Ok(deneme);
        }

        //Post request- Adding process was succes
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddWebExample(Customer webExample)
        {
            _context.customersdb.Add(webExample);
            await _context.SaveChangesAsync();
            return Ok(await _context.customersdb.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateWebExample(Customer request)
        {
            var dbdeneme = await _context.customersdb.FindAsync(request.Id);
            if (dbdeneme == null)
                return BadRequest("Deneme not found.");

            dbdeneme.Name = request.Name;
            dbdeneme.lastName = request.lastName;
            dbdeneme.Phone = request.Phone;
            dbdeneme.createdAt = request.createdAt;
            dbdeneme.updateAt = request.updateAt;
            dbdeneme.isEnabled = request.isEnabled;


            await _context.SaveChangesAsync();
            return Ok(await _context.customersdb.ToListAsync());
        }
        // Delete process on id
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> Delete(int id)
        {
            var dvdeneme = await _context.customersdb.FindAsync(id);
            if (dvdeneme == null)
                return BadRequest("Deneme not found.");

            _context.customersdb.Remove(dvdeneme);

            await _context.SaveChangesAsync();
            return Ok(await _context.customersdb.ToListAsync());

        }
    }
}
