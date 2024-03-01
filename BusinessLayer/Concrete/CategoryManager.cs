﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccesLayer.Concrete.Repository;
using EntityLayer.Concrete;
using DataAccesLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void CategoryAddBL(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categorydal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categorydal.Get(x=>x.CategoryID==id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List();
        }


    }
}
