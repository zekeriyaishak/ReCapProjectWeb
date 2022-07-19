// See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

//CarTest();

//BrandTest();

ColorTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetAll())
    {
        Console.WriteLine(car.Description);
    }
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    foreach (var brand in brandManager.GetAll())
    {
        Console.WriteLine(brand.BrandName);
    }
}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    foreach (var color in colorManager.GetAll())
    {
        Console.WriteLine(color.ColorName);
    }
}