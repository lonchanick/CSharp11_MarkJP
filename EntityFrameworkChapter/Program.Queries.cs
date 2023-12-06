using Microsoft.EntityFrameworkCore;
using Packt.Shared;

partial class Program
{
    public static void QueryingCategories()
    {
        using (Northwind NorthWindDB = new())
        {
            IQueryable<Category>? categories = NorthWindDB.Categories?.Include(c => c.Products);
           
            Info(categories?.ToQueryString()??"NullQueryString");
            
            if(categories is null || !categories.Any())
            {
            Fail("No Category(ies) Found") ;
            return;
            }

            foreach(var c in categories)
                WriteLine("categoty {0} has {1} products", c.CategoryName, c.Products.Count());
        }
        
    }
    public static void FilteredIncludes()
    {
        string input;
        int amountParsed;

        do{
            Write("Enter minimun amount in stock required: ");
            input = ReadLine()!;
        }while(!int.TryParse(input, out amountParsed));
        
        
        using(Northwind dbcontext = new())
            {
                IQueryable<Category>? categories = dbcontext.Categories?
                .Include(c => c.Products.Where(p => p.Stock >= amountParsed));
                // IQueryable<Category>? categories = db.Categories?
                // .Include(c => c.Products.Where(p => p.Stock >= stock));

                Info(categories?.ToQueryString()??"NullQueryString");
                
            
                if((categories is null) || (!categories.Any()))
                {
                    Fail("Error - fail operation");
                }

                WriteLine("\nMinimal amount {0}",amountParsed);
                foreach(var c in categories!)
                {
                    WriteLine("categoty: {0} has {1} products", c.CategoryName, c.Products.Count());
                    foreach(Product p in c.Products)
                        WriteLine("\tAmount({0}) - {1}",p.Stock,p.ProductName);
                }
            }
    }
    public static void QueryingProducts()
    {
        string input;
        decimal inputOut;
        do
        {
            Write("Enter a price: ");
            input=ReadLine()!;
        }while(!decimal.TryParse(input, out inputOut));

        using (Northwind db = new())
        {
            IQueryable<Product>? products = db.Products?
            .Where(p => p.Cost > inputOut);

            Info(products?.ToQueryString()??"NullQueryString");

            if((products is null)||(!products.Any()))
            {
                Fail("No product found.");
                return;
            }


            WriteLine("Products with a price higher than {0:$#,##0.00}:\n", inputOut);
            foreach(var p in products!)
                WriteLine("Product: {0}\nPrice: {1:$#,##0.00}\nStock: {2}\n", p.ProductName, p.Cost,p.Stock);
        }
    }
}