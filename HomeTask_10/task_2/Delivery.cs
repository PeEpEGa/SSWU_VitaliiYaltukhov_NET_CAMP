internal class Delivery : IVisitor
{
    public double DeliveryForClothes(Clothes clothes)
    {
        return clothes.CalculationOfTheCostOfDelivery();
    }

    public double DeliveryForElectronics(Electronics electronics)
    {
        return electronics.CalculationOfTheCostOfDelivery();
    }

    public double DeliveryForProducts(Products products)
    {
        return products.CalculationOfTheCostOfDelivery();
    }
}