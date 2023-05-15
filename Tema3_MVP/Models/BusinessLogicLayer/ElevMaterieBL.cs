using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.Models.BusinessLogicLayer
{
    public class ElevMaterieBL
    {
        private ElevMaterieDA elevMaterieDA = new ElevMaterieDA();
        public void AddElevMaterie(ElevMaterie elevMaterie)
        {
            elevMaterieDA.AddElevMaterie(elevMaterie);
        }
    }
}
