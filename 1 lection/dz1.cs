Product apple = new Product("apple", 90.5, 1000);
apple.DisplayProductInfo();
Product.PrintTaxRate();
Product.PrintTotalValueWithTax(apple);

Product orange = new Product("orange", 150, 1000);
orange.DisplayProductInfo();
Product.PrintTaxRate();
Product.PrintTotalValueWithTax(orange);

public class Product
{
    //нижнее подчеркивание это закрытое  поле
    private string _name;
    private double _price;
    public string Name{//доступно для чтения извне, но не для записи
        get{return _name;}
    } 
    
    public double Price{//доступно для чтения извне
        get{return _price;}
    } 
    
    public int quantity;
    private int productid;
    static int nextProductId = 1;
    const double taxRate = 0.1;
    readonly DateTime CreationDate; 
    
    public Product(string name, double price, int quantity)
    {
        _name = name;
        _price = price;
        CreationDate = DateTime.Now;
        this.quantity = quantity;
        ProductId = nextProductId++;
    }   
    public double TotalValue => _price * quantity;
    
    public void DisplayProductInfo()
    {
        Console.WriteLine($"Info of product: {_name}, {_price}, {quantity}, {CreationDate}");
    }
    
    public int ProductId
    {
        get{return productid;}
        set{productid = value;}
    }

    public static void PrintTaxRate()
    {
        Console.WriteLine($"TaxRate: {taxRate}");
    }
    public static void PrintTotalValueWithTax(Product product)
    {
        double TotalValueWithTax = product.TotalValue*(1+taxRate);
        Console.WriteLine($"TotalValueWithTax: {TotalValueWithTax}");
    }
}
