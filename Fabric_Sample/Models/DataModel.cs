using Fabric.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabric_Sample.Models
{
    [FeatureDefinition(Name = "TT_DataModel", Description = "Table of DataModel")]
    public class DataModel : FeatureEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
