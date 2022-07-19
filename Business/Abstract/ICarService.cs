﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);

        List<CarDetailsDto> GetCarDetails();

        //Car GetCarsById(int id);
        void add(Car car);
        void delete(Car car);
        void update(Car car);
    }
}