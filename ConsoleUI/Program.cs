    // See https://aka.ms/new-console-template for more information

using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

//CarTest();

//BrandTest();

//ColorTest();

static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    foreach (var car in carManager.GetAll().Data)
    {
        Console.WriteLine(car.Description);
    }
}

static void BrandTest()
{
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    foreach (var brand in brandManager.GetAll().Data)
    {
        Console.WriteLine(brand.BrandName);
    }
}

static void ColorTest()
{
    ColorManager colorManager = new ColorManager(new EfColorDal());
    foreach (var color in colorManager.GetAll().Data)
    {
        Console.WriteLine(color.ColorName);
    }
}
void UserAdd()
{
    UserManager userManager = new UserManager(new EfUserDal());
    User u1 = new User();
    u1.FirstName = "dfsdf";
    u1.LastName = "dfsdf";
    u1.Email = "dfdsfs@hotmail.com";
    u1.Password = "123";
     
    userManager.AddUser(u1);

    
}
//UserAdd();

