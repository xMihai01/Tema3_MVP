using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3_MVP.Models.DataAccessLayer;
using Tema3_MVP.Models.EntityLayer;

namespace Tema3_MVP.Models.BusinessLogicLayer
{
    public class NotaBL
    {
        private NotaDA NotaDA = new NotaDA();
        public void AddNota(int? ElevID, int? MaterieID, int? SemestruID, double nota, bool isTeza)
        {
            NotaDA.AddNota(ElevID, MaterieID, SemestruID, nota, isTeza);
        }
        public void DeleteNota(int? NotaID)
        {
            NotaDA.DeleteNota(NotaID);
        }
        public ObservableCollection<Nota> GetNote(int? ElevID, int? MaterieID, int? SemestruID)
        {
            return NotaDA.GetNote(ElevID, MaterieID, SemestruID);
        }
        public double? GetMedie(int? ElevID, int? MaterieID, int? SemestruID)
        {
            return NotaDA.GetMedie(ElevID, MaterieID, SemestruID);
        }
        public void CalculateMedie(int? ElevID, int? MaterieID, int? SemestruID, bool requiresTeza)
        {
            ObservableCollection<Nota> note = NotaDA.GetNote(ElevID, MaterieID, SemestruID);
            double? teza = null;
            double? suma = 0;
            double? count = 0;
            foreach(Nota nota in note)
            {
                if (nota.Tip == "TEZA" && teza != null)
                {
                    MessageBox.Show("Too many Teze. Only one is allowed.");
                    return;
                }
                if (nota.Tip == "TEZA" || nota.Tip == "NOTA")
                {
                    if (nota.Tip == "TEZA")
                    {
                        teza = nota.ValoareNota;
                    } else
                    {
                        suma += nota.ValoareNota;
                        count++;
                    }
                }
            }
            if (count < 3)
            {
                MessageBox.Show("Not enough note.");
                return;
            }
            if (teza == null && requiresTeza == true)
            {
                MessageBox.Show("No teza found");
                return;
            }
            if (requiresTeza)
                NotaDA.SetMedie(ElevID, MaterieID, SemestruID, ((suma / count) + teza) / 2);
            else NotaDA.SetMedie(ElevID, MaterieID, SemestruID, suma / count);
        }
        
    }
}
