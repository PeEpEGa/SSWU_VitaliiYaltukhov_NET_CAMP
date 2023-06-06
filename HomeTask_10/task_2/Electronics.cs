internal class Electronics : IGoods
{
    public Electronics(double weight, double size)
    {
        Weight = weight;
        Size = size;
    }

    public double Weight { get; set; }
    public double Size { get; set; }
    public static double MaxSize { get; set; } = 150;

    public double CalculationOfTheCostOfDelivery()
    {
        double extra = Size > MaxSize ? 1.5 : 1;
        return DeliveryPrices.RegularDeliveryPrice * extra;
    }

    public double Accept(IVisitor visitor)
    {
        return visitor.DeliveryForElectronics(this);
    }
}