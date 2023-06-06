Clothes clothes = new Clothes(5, 12);
Electronics electronics = new Electronics(3, 200);
Products products = new Products(12, 30, DateTime.Now.AddDays(3));

List<IGoods> goods = new List<IGoods> { clothes, electronics, products};

Delivery delivery = new Delivery();

foreach (var item in goods)
{
    Console.WriteLine("Delivery price:" + item.Accept(delivery));
}