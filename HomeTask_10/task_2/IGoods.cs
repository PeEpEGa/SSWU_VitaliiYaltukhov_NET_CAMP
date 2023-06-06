internal interface IGoods
{
    public double Weight { get; set; }
    public double Size { get; set; }
    public double CalculationOfTheCostOfDelivery();
    public double Accept(IVisitor visitor);
}