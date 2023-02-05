using System;
using System.Collections.Generic;

namespace Model
{
    public class EmpresaModel : BaseModel
    {
        public string id { get; set; }
        public string status { get; set; }
        public DateTime last_update { get; set; }
        public List<CustoModel> custos { get; set; }
    }
}
