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
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            var idFiltered = await _context.customersdb.Where(i => i.Id == 1).ToListAsync();
            var phoneFiltered = await _context.customersdb.Where(i => i.Phone == 1).ToListAsync();
            var nameFiltered = await _context.customersdb.Where(i => i.Name == "Veli").ToListAsync();
            var createdAtFiltered = await _context.customersdb.Where(i => i.createdAt.Year >= 2020).ToListAsync();
            var updateAtFiltered = await _context.customersdb.Where(i => i.updateAt.Year >= 2020).ToListAsync();
            var getAll = await _context.customersdb.ToListAsync();
            return Ok(getAll);
        }
        //Get request parse id
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
