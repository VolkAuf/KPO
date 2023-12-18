using AllDeductedBusinessLogic.BindingModels;
using AllDeductedBusinessLogic.Interfaces;
using AllDeductedBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllDeductedBusinessLogic.BusinessLogics
{
    public class GroupLogic
    {
        private readonly IGroupStorage _groupStorage;

        public GroupLogic(IGroupStorage groupStorage)
        {
            _groupStorage = groupStorage;
        }

        public List<GroupViewModel> Read(GroupBindingModel model)
        {
            if (model == null)
                return _groupStorage.GetFullList();

            if (model.Id.HasValue)
                return new List<GroupViewModel> { _groupStorage.GetElement(model) };

            return _groupStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(GroupBindingModel model)
        {
            if (model.Id.HasValue)
                _groupStorage.Update(model);
            _groupStorage.Insert(model);
        }

        public void Delete(GroupBindingModel model)
        {
            GroupViewModel element = _groupStorage.GetElement(new GroupBindingModel { Id = model.Id });
            if (element == null)
                throw new Exception("Элемент не найден");

            _groupStorage.Delete(model);
        }
    }
}