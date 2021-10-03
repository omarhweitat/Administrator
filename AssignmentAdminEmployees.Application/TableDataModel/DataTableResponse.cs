using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Application.TableDataModel
{
    [Serializable]
    public class DataTableResponse
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public object[] Data { get; set; }
        public string Error { get; set; }
    }
}
