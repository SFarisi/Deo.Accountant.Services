using Microsoft.AspNetCore.Mvc;

namespace Deo.Accountant.Services.Controllers.Bookkeeping
{
    [ApiController]
    [Route("[controller]")]
    public class GBookkeeping<T> : ControllerBase where T : class
    {
        public readonly Deo.Provider.AllyBookkeeping db;
        public GBookkeeping(Deo.Provider.AllyBookkeeping data)
        {
            db = data;

        }

        [HttpGet]
        public IList<T> GetAll()
        {
            Deo.Mutiyat.Repository.CRUD.CRUD<T> crud = new Mutiyat.Repository.CRUD.CRUD<T>();
            return crud.GetAll();
        }

        [HttpGet("{id}")]
        public T GetById(T id)
        {
            Deo.Mutiyat.Repository.CRUD.CRUD<T> crud = new Mutiyat.Repository.CRUD.CRUD<T>();
            return crud.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T record)
        {
            Deo.Mutiyat.Repository.CRUD.CRUD<T> crud = new Mutiyat.Repository.CRUD.CRUD<T>();
            await crud.AddAsync(record);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] T record)
        {
            Deo.Mutiyat.Repository.CRUD.CRUD<T> crud = new Mutiyat.Repository.CRUD.CRUD<T>();

            crud.Update(record);

            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(T id)
        {
            Deo.Mutiyat.Repository.CRUD.CRUD<T> crud = new Mutiyat.Repository.CRUD.CRUD<T>();

            crud.Delete(id);

            return Ok("true!");

        }
    }
}
