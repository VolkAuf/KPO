using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AllDeductedBusinessLogic.ViewModels
{
    public class StudentViewModel
    {
        [DisplayName("Зачётная книга")]
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        public List<DisciplineViewModel> Disciplines { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is StudentViewModel studentViewModel))
                return false;

            if (LastName != studentViewModel.LastName)
                return false;
            if (FirstName != studentViewModel.FirstName)
                return false;
            if (Id != studentViewModel.Id)
                return false;
            if (Patronymic != studentViewModel.Patronymic)
                return false;

            return true;
        }
    }
}
