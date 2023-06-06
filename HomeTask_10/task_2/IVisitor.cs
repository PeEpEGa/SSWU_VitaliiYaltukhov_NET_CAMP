internal interface IVisitor
{
    double DeliveryForClothes(Clothes clothes);
    double DeliveryForElectronics(Electronics electronics);
    double DeliveryForProducts(Products products);
}