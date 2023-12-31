﻿using AllDeductedBusinessLogic.BindingModels;
using AllDeductedBusinessLogic.Interfaces;
using AllDeductedBusinessLogic.ViewModels;
using AllDeductedDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllDeductedDatabaseImplement.Implements
{
    public class StudyingStatusStorage : IStudyingStatusStorage
    {
        public void Delete(StudyingStatusBindingModel model)
        {
            using (var context = new Context())
            {
                StudyingStatus status = context.StudyingStatuses.FirstOrDefault(rec => rec.Id == model.Id);
                if (status != null)
                {
                    context.StudyingStatuses.Remove(status);
                    context.SaveChanges();
                }
                Student student = context.Students.FirstOrDefault(rec => rec.Id == model.StudentId);
                if (student != null)
                {
                    student.StudyingStatus = null;
                    context.Students.Update(student);
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public StudyingStatusViewModel GetElement(StudyingStatusBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Context())
            {
                StudyingStatus studyingStatus = context.StudyingStatuses
                .Include(rec => rec.Provider)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return studyingStatus != null ?
                new StudyingStatusViewModel
                {
                    Id = studyingStatus.Id,
                    StudentId = studyingStatus.StudentId,
                    DateCreate = studyingStatus.EnrollmentDate,
                    StudyingForm = studyingStatus.StudyingForm,
                    StudyingBase = studyingStatus.StudyingBase,
                    Course = studyingStatus.Course
                } :
                null;
            }
        }

        public List<StudyingStatusViewModel> GetFilteredList(StudyingStatusBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new Context())
            {
                return context.StudyingStatuses
                .Include(rec => rec.Provider)
                .Include(rec => rec.Student)
                .ThenInclude(rec => rec.OrderStudents)
                .ThenInclude(rec => rec.Order)
                .ThenInclude(rec => rec.OrderGroups)
                .ThenInclude(rec => rec.Group)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.EnrollmentDate.Date == model.DateCreate.Date) 
                || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.EnrollmentDate.Date >= model.DateFrom.Value.Date 
                && rec.EnrollmentDate.Date <= model.DateTo.Value.Date) || (rec.ProviderId == model.ProviderId))
                .ToList()
                .Select(rec => new StudyingStatusViewModel
                {
                    Id = rec.Id,
                    StudentId = rec.StudentId,
                    DateCreate = rec.EnrollmentDate,
                    StudyingForm = rec.StudyingForm,
                    StudyingBase = rec.StudyingBase,
                    Course = rec.Course,
                    GroupName = rec.Student.OrderStudents
                        .Select(recOS => recOS.Order)
                        .SelectMany(recO => recO.OrderGroups)
                        .Select(recOG => recOG.Group)
                        .LastOrDefault()?.Name
                })
                .ToList();
            }
        }

        public List<StudyingStatusViewModel> GetFullList()
        {
            using (var context = new Context())
            {
                return context.StudyingStatuses
                .Select(rec => new StudyingStatusViewModel
                {
                    Id = rec.Id,
                    StudentId = rec.StudentId,
                    StudyingForm = rec.StudyingForm,
                    StudyingBase = rec.StudyingBase,
                    Course = rec.Course,
                    DateCreate = rec.EnrollmentDate
                })
                .ToList();
            }
        }

        public void Insert(StudyingStatusBindingModel model)
        {
            using (var context = new Context())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        StudyingStatus status = new StudyingStatus
                        {
                            EnrollmentDate = DateTime.Now,
                            ProviderId = model.ProviderId,
                            StudentId = model.StudentId,
                            StudyingBase = model.StudyingBase,
                            StudyingForm = model.StudyingForm,
                            Course = model.Course
                        };
                        context.StudyingStatuses.Add(status);
                        context.SaveChanges();
                        CreateModel(model, status, context);
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

        public void Update(StudyingStatusBindingModel model)
        {
            using (var context = new Context())
            {
                StudyingStatus element = context.StudyingStatuses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                
                CreateModel(model, element, context);
                context.SaveChanges();
            }
        }

        private StudyingStatus CreateModel(StudyingStatusBindingModel model, StudyingStatus studyingStatus, Context context)
        {
            if (model == null)
            {
                return null;
            }
                
            Student element = context.Students.FirstOrDefault(rec => rec.Id == model.StudentId);
            if (element != null)
            {
                if (element.StudyingStatus == null)
                {
                    element.StudyingStatus = new StudyingStatus();
                }
                studyingStatus.StudyingBase = model.StudyingBase;
                studyingStatus.StudyingForm = model.StudyingForm;
                studyingStatus.ProviderId = model.ProviderId;
                studyingStatus.Course = model.Course;
                studyingStatus.StudentId = model.StudentId;
                element.StudyingStatus = studyingStatus;
                context.Students.Update(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
            return studyingStatus;
        }
    }
}
