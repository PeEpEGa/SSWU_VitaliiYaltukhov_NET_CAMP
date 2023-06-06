internal class Clothes : IGoods
{
    public Clothes(double weight, double size)
    {
        Weight = weight;
        Size = size;
    }

    public double Weight { get; set; }
    public double Size { get; set; }

    public double Accept(IVisitor visitor)
    {
        return visitor.DeliveryForClothes(this);
    }

    public double CalculationOfTheCostOfDelivery()
    {
        return DeliveryPrices.RegularDeliveryPrice;
    }
}