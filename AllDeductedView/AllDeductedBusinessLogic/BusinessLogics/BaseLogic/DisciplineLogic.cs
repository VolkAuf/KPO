using AllDeductedBusinessLogic.BindingModels;
using AllDeductedBusinessLogic.Interfaces;
using AllDeductedBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllDeductedBusinessLogic.BusinessLogics
{
    public class DisciplineLogic
    {
        private readonly IDisciplineStorage _disciplineStorage;
        public DisciplineLogic(IDisciplineStorage disciplineStorage)
        {
            _disciplineStorage = disciplineStorage;
        }
        public List<DisciplineViewModel> Read(DisciplineBindingModel model)
        {
            if (model == null)
            {
                return _disciplineStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DisciplineViewModel> { _disciplineStorage.GetElement(model) };
            }
            return _disciplineStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(DisciplineBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _disciplineStorage.Update(model);
            }
            else
            {
                _disciplineStorage.Insert(new DisciplineBindingModel
                {
                    Name = model.Name,
                    HoursCount = model.HoursCount,
                    ProviderId = model.ProviderId,
                });
            }
        }

        public void Delete(DisciplineBindingModel model)
        {
            DisciplineViewModel element = _disciplineStorage.GetElement(new DisciplineBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _disciplineStorage.Delete(model);
        }
    }
}
