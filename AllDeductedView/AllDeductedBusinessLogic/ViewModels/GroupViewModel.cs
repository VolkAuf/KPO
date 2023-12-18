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

        public Dictionary<int,string> Orders { get; set; }

        public Dictionary<int, string> Discipline { get; set; }
    }
}
