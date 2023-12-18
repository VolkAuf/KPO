﻿using AllDeductedBusinessLogic.BindingModels;
using AllDeductedBusinessLogic.Interfaces;
using AllDeductedBusinessLogic.ViewModels;
using AllDeductedDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
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
                    .Include(rec => rec.Group)
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
                    .Include(rec => rec.Group)
                    .Where(rec => rec.Name.Contains(model.Name))
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
                    .Include(rec => rec.Group)
                    .FirstOrDefault(rec => rec.Name == model.Name ||
                    rec.Id == model.Id);

                return discipline != null ? CreateViewModel(discipline) : null;
            }
        }
    }
}
