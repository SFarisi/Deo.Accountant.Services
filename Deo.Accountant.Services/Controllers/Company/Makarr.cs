using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deo.Accountant.Services.Controllers.Company
{
    [ApiController]
    [Route("[controller]")]
    public class Makarr<T> : ControllerBase where T : class
    {
        public readonly Deo.Provider.AllyCompany db;
        public Makarr(Deo.Provider.AllyCompany data)
        {
            db = data;
        }

        [HttpGet]
        public IList<T> GetAll()
        {
            Deo.Mutiyat.Repository.CRUD.Makarr<T> crud = new Mutiyat.Repository.CRUD.Makarr<T>();
            return crud.GetAll();
        }

        [HttpGet("{id}")]
        public T GetById(T id)
        {
            Deo.Mutiyat.Repository.CRUD.Makarr<T> crud = new Mutiyat.Repository.CRUD.Makarr<T>();
            return crud.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T record)
        {
            Deo.Mutiyat.Repository.CRUD.Makarr<T> crud = new Mutiyat.Repository.CRUD.Makarr<T>();
            await crud.AddAsync(record);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] T record)
        {
            Deo.Mutiyat.Repository.CRUD.Makarr<T> crud = new Mutiyat.Repository.CRUD.Makarr<T>();

            crud.Update(record);

            return Ok(record);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(T id)
        {
            Deo.Mutiyat.Repository.CRUD.Makarr<T> crud = new Mutiyat.Repository.CRUD.Makarr<T>();

            crud.Delete(id);

            return Ok("true!");

        }

    }
}
