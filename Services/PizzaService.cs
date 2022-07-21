namespace Pizza.Services;

using Pizza.Models;

public static class PizzaService
{
    /// <summary>
    /// static pizza list available
    /// </summary>
    static List<Pizza> Pizzas { get; }

    /// <summary>
    /// if a pizza to be added, next id in line
    /// </summary>
    static int nextId = 3;

    /// <summary>
    /// Constructor which initialize the pizzalist with the premade menu
    /// </summary>
    static PizzaService()
    {
        Pizzas = new List<Pizza>
    {
        new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
        new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
    };
    }

    /// <summary>
    /// To receive all the list of available pizzas
    /// </summary>
    /// <returns>List of pizza modeled objects</returns>
    public static List<Pizza> GetAll() => Pizzas;

    /// <summary>
    /// To retrieve a specific pizza  
    /// </summary>
    /// <param name="id">Integer id of the pizza</param>
    /// <returns>Pizza modeled object relevant to the id</returns>
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    /// <summary>
    /// Adding a new pizza to the menu
    /// </summary>
    /// <param name="pizza">Expects a Pizza model object</param>
    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    /// <summary>
    /// Removing a pizza from the list
    /// </summary>
    /// <param name="id">integer id of the pizza to be removed</param>
    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    /// <summary>
    /// Updating details of an existing pizza on the list
    /// </summary>
    /// <param name="pizza">Updated pizza model object</param>
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }
}
