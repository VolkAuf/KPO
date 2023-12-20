using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AllDeductedBusinessLogic.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Имя куратора")]
        public string CuratorName { get; set; }

        public List<int> Orders { get; set; }

        public Dictionary<int, string> Discipline { get; set; }
        
        public override bool Equals(object obj)
        {
            if (!(obj is GroupViewModel groupViewModel))
                return false;

            if (Name != groupViewModel.Name)
                return false;
            if (CuratorName != groupViewModel.CuratorName)
                return false;

            return true;
        }
    }
}
