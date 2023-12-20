using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AllDeductedBusinessLogic.ViewModels
{
    public class DisciplineViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Количество часов")]
        public int HoursCount { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is DisciplineViewModel disciplineViewModel))
                return false;

            if (Name != disciplineViewModel.Name)
                return false;
            if (HoursCount != disciplineViewModel.HoursCount)
                return false;

            return true;
        }
    }
}
