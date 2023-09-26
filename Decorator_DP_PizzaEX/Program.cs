using System;
    namespace DecoratorDesignPatternEX
{
    public interface Pizza
    {
        string MakePizza();
    }
    public class PlainPizza : Pizza
    {
        public string MakePizza()
        {
            return "Plain Pizza";
        }
    }
    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;

        public PizzaDecorator (Pizza pizza)
        {
            this.pizza = pizza;
        }
        public virtual string MakePizza()
        {
            return pizza.MakePizza();
        }
    }
    public class CheckenPizza : PizzaDecorator
    {
        public CheckenPizza(Pizza pizza) : base(pizza)
        {

        }
        public override string MakePizza()
        {
            return base.MakePizza() + AddChicken();
        }
        private string AddChicken()
        {
            return ", Chicken Added";
        }
    }
    public class VegPizza : PizzaDecorator
    {
        public VegPizza(Pizza pizza) : base(pizza)
        {

        }
        public override string MakePizza()
        {
            return base.MakePizza() + AddVeg();
        }
        private string AddVeg()
        {
            return ", Vegetables Added";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PlainPizza plainPizzaObj = new PlainPizza();

            string plainPizza = plainPizzaObj.MakePizza();
            Console.WriteLine(plainPizza);
            
            PizzaDecorator chickenPizzaDecorator = new CheckenPizza(plainPizzaObj);
           
            string chickenPizza = chickenPizzaDecorator.MakePizza();
            Console.WriteLine("\n'" + chickenPizza + "' using ChickenPizzaDecorator");

            PizzaDecorator vegPizzaDecorator = new VegPizza(plainPizzaObj);
            string vegPizza = vegPizzaDecorator.MakePizza();
            Console.WriteLine("\n'" + vegPizza + "' using VegPizzaDecorator");
            Console.Read();
        }
    }
}