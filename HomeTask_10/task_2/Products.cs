internal class Products : IGoods
{
    public Products(double weight, double size, DateTime date)
    {
        Weight = weight;
        Size = size;
        Date = date;
    }

    public double Weight { get; set; }
    public double Size { get; set; }
    public DateTime Date { get; set; }

    public double Accept(IVisitor visitor)
    {
        return visitor.DeliveryForProducts(this);
    }

    public double CalculationOfTheCostOfDelivery()
    {
        double days = (DateTime.Now - Date).TotalDays;
        double extra = days > 5 ? 1 : 1.5;
        return DeliveryPrices.RegularDeliveryPrice * extra;
    }
}