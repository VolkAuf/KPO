using System;
using AllDeductedBusinessLogic.BindingModels;
using AllDeductedBusinessLogic.Interfaces;
using AllDeductedBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AllDeductedDatabaseImplement.Models;

namespace AllDeductedDatabaseImplement.Implements
{
    public class GroupStorage : IGroupStorage
    {
        public GroupViewModel GetElement(GroupBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Context())
            {
                var group = context.Groups.Include(rec => rec.OrderGroups)
                    .ThenInclude(rec => rec.Order)
                    .Include(rec => rec.DisciplineGroups)
                    .ThenInclude(rec => rec.Discipline)
                    .Include(rec => rec.Provider)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return group != null ?
                new GroupViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    CuratorName = group.CuratorName,
                    Orders = group.OrderGroups.Select(recOG => recOG.OrderId).ToList(),
                    Discipline = group.DisciplineGroups.ToDictionary(recDG => recDG.DisciplineId, recDG => recDG.Discipline?.Name)
                } : null;
            }
        }

        public List<GroupViewModel> GetFilteredList(GroupBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Context())
            {
                return context.Groups
                .Include(rec => rec.OrderGroups)
                .ThenInclude(rec => rec.Order)
                .Include(rec => rec.DisciplineGroups)
                .ThenInclude(rec => rec.Discipline)
                .Where(rec => rec.ProviderId == model.ProviderId)
                .ToList()
                .Select(rec => new GroupViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    CuratorName = rec.CuratorName,
                    Orders = rec.OrderGroups.Select(recOG => recOG.OrderId).ToList(),
                    Discipline = rec.DisciplineGroups.ToDictionary(recDG => recDG.DisciplineId, recDG => recDG.Discipline?.Name)
                })
                .ToList();
            }
        }
        public List<GroupViewModel> GetFullList()
        {
            using (var context = new Context())
            {
                return context.Groups
                    .Include(rec => rec.OrderGroups)
                    .ThenInclude(rec => rec.Order)
                    .Include(rec => rec.DisciplineGroups)
                    .ThenInclude(rec => rec.Discipline)
                    .ToList()
                    .Select(rec => new GroupViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name,
                        CuratorName = rec.CuratorName,
                        Orders = rec.OrderGroups.Select(recOG => recOG.OrderId).ToList(),
                        Discipline = rec.DisciplineGroups.ToDictionary(recDG => recDG.DisciplineId, recDG => recDG.Discipline?.Name)
                    }).ToList();
            }
        }

        public void Delete(GroupBindingModel model)
        {
            using (var context = new Context())
            {
                Group element = context.Groups.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Groups.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public void Insert(GroupBindingModel model)
        {
            using (var context = new Context())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var group = CreateModel(model, new Group());
                        context.Add(group);
                        context.SaveChanges();
                        CreateModel(model, group, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(GroupBindingModel model)
        {
            using (var context = new Context())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Group element = context.Groups.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }

                        CreateModel(model, element);
                        context.SaveChanges();
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private Group CreateModel(GroupBindingModel model, Group group)
        {
            group.Name = model.Name;
            group.CuratorName = model.CuratorName;
            group.ProviderId = model.ProviderId;

            return group;
        }

        private Group CreateModel(GroupBindingModel model, Group group, Context context)
        {
            group.ProviderId = model.ProviderId;
            if (group.Id == 0)
            {
                context.Groups.Add(group);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var orderGroups = context.OrderGroups.Where(rec => rec.GroupId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.OrderGroups.RemoveRange(orderGroups.Where(recOS => !model.Order.Contains(recOS.GroupId))
                    .ToList());
                context.SaveChanges();

                foreach (var og in orderGroups)
                {
                    if (model.Order.Contains(og.OrderId))
                    {
                        model.Order.Remove(og.OrderId);
                    }
                }

                context.SaveChanges();


                var disciplineGroups = context.DisciplineGroups.Where(rec => rec.GroupId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.DisciplineGroups.RemoveRange(disciplineGroups.Where(recOS => !model.Discipline.ContainsKey(recOS.GroupId))
                    .ToList());
                context.SaveChanges();

                foreach (var og in disciplineGroups)
                {
                    if (model.Discipline.ContainsKey(og.DisciplineId))
                    {
                        model.Discipline.Remove(og.DisciplineId);
                    }
                }

                context.SaveChanges();
            }

            if(model.Order != null)
            {
                foreach (var order in model.Order)
                {
                    context.OrderGroups.Add(new OrderGroup
                    {
                        OrderId = order,
                        GroupId = group.Id
                    });
                    context.SaveChanges();
                }
            }

            if(model.Discipline != null)
            {
                foreach (var discipline in model.Discipline)
                {
                    context.DisciplineGroups.Add(new DisciplineGroup()
                    {
                        DisciplineId = discipline.Key,
                        GroupId = group.Id
                    });
                    context.SaveChanges();
                }
            }

            return group;
        }
    }
}
