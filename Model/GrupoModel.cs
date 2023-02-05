using System;
using System.Collections.Generic;

namespace Model
{
    public class GrupoModel : BaseModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string category { get; set; }
        public List<string> companys { get; set; }
    }
}
