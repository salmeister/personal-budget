using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class Properties
    {
        public int PropertyPk { get; set; }
        public string PropertyName { get; set; }
        public string PropertyAddress1 { get; set; }
        public string PropertyAddress2 { get; set; }
        public string PropertyCity { get; set; }
        public string PropertyState { get; set; }
        public string PropertyZip { get; set; }
        public bool Active { get; set; }
    }
}
