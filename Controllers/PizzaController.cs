namespace Pizza.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Pizza.Models;
    using Pizza.Services;

    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        /// <summary>
        /// Get request calls for the GetAll() method of the PizzaService to retrieve all the pizzas available
        /// </summary>
        /// <returns>List of Pizza model objects available</returns>
        [HttpGet]
        public ActionResult<List<Pizza>> Get() => PizzaService.GetAll();
    
        /// <summary>
        /// Specific pizza be received upon naming the id
        /// </summary>
        /// <param name="id">pizza id</param>
        /// <returns>Pizza item</returns>
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id) {
            var pizza = PizzaService.Get(id);
            //check whether the pizza is empty
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }
        /// <summary>
        /// Creates a pizza using Pizza Create Service
        /// </summary>
        /// <param name="pizza">Pizza object that needs to be added/created</param>
        /// <returns>IActionResult with respect to the action</returns>
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            //return Ok(pizza); //what if there's an error, so should I go with a bool out instead of void on services
            return CreatedAtAction(nameof(Create), new {id = pizza.Id},pizza);
        }
        /// <summary>
        /// Update the details of an existing pizza using the pizza id
        /// </summary>
        /// <param name="id">int id of the pizza to be updated</param>
        /// <param name="pizza">content updated pizza object</param>
        /// <returns>IActionResult with respect to the action</returns>
        [HttpPut()]
        public IActionResult Update(int id,Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }
            var originalPizza = PizzaService.Get(id);
            if(originalPizza is null)
            {
                return NotFound(id);
            }
            PizzaService.Update(pizza);
            return NoContent();
        }
        /// <summary>
        /// Delete a pizza
        /// </summary>
        /// <param name="id">int id of the pizza to be deleted</param>
        /// <returns>IActionResult with respect to the action</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var originalPizza = PizzaService.Get(id);
            if (originalPizza is null)
            {
                return NotFound(id);
            }
            PizzaService.Delete(id);
            return NoContent();
        }
    }
}