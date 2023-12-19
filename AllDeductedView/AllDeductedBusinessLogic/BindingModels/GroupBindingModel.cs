using System;
using System.Collections.Generic;
using System.Text;

namespace AllDeductedBusinessLogic.BindingModels
{
    public class GroupBindingModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string CuratorName { get; set; }

        public List<int> Order { get; set; }

        public Dictionary<int, string> Discipline { get; set; }

        public int ProviderId { get; set; }
    }
}
