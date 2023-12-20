using AllDeductedBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AllDeductedBusinessLogic.ViewModels
{
    public class StudyingStatusViewModel
    {
        public int Id { get; set; }
        [DisplayName("Номер зачётной книги студента")]
        public int StudentId { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Форма обучения")]
        public StudyingForm StudyingForm { get; set; }
        [DisplayName("Основа обучения")]
        public StudyingBase StudyingBase { get; set; }
        [DisplayName("Курс")]
        public int Course { get; set; }
        public string GroupName { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is StudyingStatusViewModel studyingStatusViewModel))
                return false;

            if (StudentId != studyingStatusViewModel.StudentId)
                return false;
            if (StudyingForm != studyingStatusViewModel.StudyingForm)
                return false;
            if (StudyingBase != studyingStatusViewModel.StudyingBase)
                return false;
            if (Course != studyingStatusViewModel.Course)
                return false;
            if (GroupName != studyingStatusViewModel.GroupName)
                return false;
            if (DateCreate.Date != studyingStatusViewModel.DateCreate.Date)
                return false;

            return true;
        }
    }
}
