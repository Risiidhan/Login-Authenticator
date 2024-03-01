using PizzaDot.Interfaces;
using PizzaDot.Models;

namespace PizzaDot.Services
{
    public class PizzaService : IPizza
    {
        private readonly ApplicationDBContext _context;

        public PizzaService(ApplicationDBContext dBContext)
        {
            _context = dBContext;
        }

        public Pizza CreatePizza(Pizza pizza)
        {
            if (pizza == null)
                return null;

            _context.Pizza.Add(pizza);
            _context.SaveChanges();
            return pizza;
        }

        public int DeletePizza(int id)
        {
            var pizzaToDelete = _context.Pizza.FirstOrDefault(p => p.id == id);

            if (pizzaToDelete == null)
                return 0;
            
            _context.Pizza.Remove(pizzaToDelete);
            _context.SaveChanges();
            return 1; 
        }

        public IEnumerable<Pizza> GetAllPizza()
        {
            return _context.Pizza.ToList();
        }

        public Pizza GetPizzaByID(int id)
        {
            var foundPizza = _context.Pizza.Where(x => x.id == id).FirstOrDefault() ?? null;
            return foundPizza;
        }

        public Pizza UpdatePizza(int id, Pizza pizza)
        {
            var foundPizza = _context.Pizza.Where(x => x.id == id).FirstOrDefault() ?? null;

            if (foundPizza == null)
                return null;

            foundPizza.name = pizza.name;
            foundPizza.topping = pizza.topping;
            _context.SaveChanges();
            return foundPizza;

        }


    }
}
