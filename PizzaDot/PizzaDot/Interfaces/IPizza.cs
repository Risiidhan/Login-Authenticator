using PizzaDot.Models;

namespace PizzaDot.Interfaces
{
    public interface IPizza
    {
        IEnumerable<Pizza> GetAllPizza();

        Pizza GetPizzaByID(int id);

        Pizza CreatePizza(Pizza pizza);

        Pizza UpdatePizza(int id, Pizza pizza);

        int DeletePizza(int id);
    }
}
