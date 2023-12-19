using AllDeductedBusinessLogic.BindingModels;
using AllDeductedBusinessLogic.Interfaces;
using AllDeductedBusinessLogic.ViewModels;
using AllDeductedDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllDeductedDatabaseImplement.Implements
{
    public class DisciplineStorage : IDisciplineStorage
    {
        private DisciplineViewModel CreateViewModel(Discipline discipline)
        {
            return new DisciplineViewModel
            {
                Id = discipline.Id,
                Name = discipline.Name,
                HoursCount = discipline.HoursCount,
                
            };
        }

        public List<DisciplineViewModel> GetFullList()
        {
            using (var context = new Context())
            {
                return context.Disciplines
                    .Include(rec => rec.Provider)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.DisciplineGroup)
                    .ThenInclude(rec => rec.Group)
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public List<DisciplineViewModel> GetFilteredList(DisciplineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new Context())
            {

                return context.Disciplines
                    .Include(rec => rec.Provider)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.DisciplineGroup)
                    .ThenInclude(rec => rec.Group)
                    .Where(rec => (rec.ProviderId == model.ProviderId))
                    .Select(CreateViewModel)
                    .ToList();
            }
        }

        public DisciplineViewModel GetElement(DisciplineBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new Context())
            {
                var discipline = context.Disciplines
                    .Include(rec => rec.Provider)
                    .ThenInclude(rec => rec.User)
                    .Include(rec => rec.DisciplineGroup)
                    .ThenInclude(rec => rec.Group)
                    .FirstOrDefault(rec => rec.Name == model.Name ||
                    rec.Id == model.Id);

                return discipline != null ? CreateViewModel(discipline) : null;
            }
        }

        public void Delete(DisciplineBindingModel model)
        {
            using (var context = new Context())
            {
                Discipline element = context.Disciplines.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Disciplines.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public void Insert(DisciplineBindingModel model)
        {
            using (var context = new Context())
            {
                context.Add(CreateModel(model, new Discipline()));
                context.SaveChanges();
            }
        }

        public void Update(DisciplineBindingModel model)
        {
            using (var context = new Context())
            {
                Discipline element = context.Disciplines.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }

                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        private Discipline CreateModel(DisciplineBindingModel model, Discipline discipline)
        {
            discipline.HoursCount = model.HoursCount;
            discipline.Name = model.Name;
            discipline.ProviderId = model.ProviderId;

            return discipline;
        }
    }
}
