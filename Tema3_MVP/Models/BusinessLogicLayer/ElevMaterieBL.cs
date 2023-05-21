using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ElevMaterie GetElevMaterie(int? ElevID, int? MaterieID, int? SemestruID)
        {
            return elevMaterieDA.GetElevMaterie(ElevID, MaterieID, SemestruID);
        }
        public string GetAllMediiMessage(int? ElevID, int? SemestruID, ObservableCollection<Materie> materii)
        {
            string message = "";
            double? sum = 0;
            foreach (Materie mat in materii)
            {
                AddElevMaterie(new ElevMaterie(ElevID, mat.MaterieID, SemestruID));
                ElevMaterie elevMaterie = elevMaterieDA.GetElevMaterie(ElevID, mat.MaterieID, SemestruID);
                if (elevMaterie.Medie == null)
                {
                    return "Materie " + mat.Nume + " doesn't have it's average calculated yet.";
                }
                message += mat.Nume + ": " + elevMaterie.Medie + "\n";
                sum += elevMaterie.Medie;
            }
            message += "\nMedie generala: " + (sum / materii.Count);
            return message;
        }
        public string GetTopMediiMessage(int? SemestruID, ObservableCollection<Materie> materii, ObservableCollection<Elev> elevi)
        {
            Dictionary<Elev, double?> dict = new Dictionary<Elev, double?>();
            string message = "";
            foreach (Elev elev in elevi)
            {
                double? sum = 0;
                foreach (Materie mat in materii)
                {
                    AddElevMaterie(new ElevMaterie(elev.ElevID, mat.MaterieID, SemestruID));
                    ElevMaterie elevMaterie = elevMaterieDA.GetElevMaterie(elev.ElevID, mat.MaterieID, SemestruID);
                    if (elevMaterie.Medie == null)
                    {
                        return "Elev " + elev.Nume + " " + elev.Prenume + " at Materie " + mat.Nume + " doesn't have it's average calculated yet.";
                  
                    }
                    sum += elevMaterie.Medie;
                }
                dict[elev] = (sum / materii.Count);
            }
            //var top = dict.OrderByDescending(pair => pair.Value).Take(elevi.Count);
            int counter = 1;
            foreach (var item in dict.OrderByDescending(pair => pair.Value).Take(elevi.Count))
            {
                message += counter.ToString() + ". " + item.Key.Nume + " " + item.Key.Prenume + ": " + item.Value.ToString() + "\n";
                counter++;
            }
            return message;
        }
        public Tuple<string, string, string> GetStatsMessage(int? SemestruID, ObservableCollection<Materie> materii, ObservableCollection<Elev> elevi)
        {
            Dictionary<Elev, double?> dict = new Dictionary<Elev, double?>();
            string messagePremianti = "Premianti + mentiuni\n\n";
            string messageCorigenti = "Corigenti la fiecare materie\n\n";
            string messageRepetenti = "Repetenti \n\n";
            foreach (Elev elev in elevi)
            {
                double? sum = 0;
                int corigente = 0;
                ObservableCollection<Materie> corigenteMat = new ObservableCollection<Materie>();
                foreach (Materie mat in materii)
                {
                    AddElevMaterie(new ElevMaterie(elev.ElevID, mat.MaterieID, SemestruID));
                    ElevMaterie elevMaterie = elevMaterieDA.GetElevMaterie(elev.ElevID, mat.MaterieID, SemestruID);
                    if (elevMaterie.Medie == null)
                    {
                        return null;
                    }
                    if (elevMaterie.Medie < 5.00)
                    {
                        messageCorigenti += elev.Nume + " " + elev.Prenume + ", " + mat.Nume + "\n";
                        corigenteMat.Add(mat);
                        corigente++;
                    }
                    sum += elevMaterie.Medie;
                }
                if (corigente >= 3)
                {
                    messageRepetenti += elev.Nume + " " + elev.Prenume + ", ";
                    foreach (Materie m in corigenteMat) { messageRepetenti += m.Nume + ", "; } messageRepetenti += "\n"; 
                }
                dict[elev] = (sum / materii.Count);
            }
            //var top = dict.OrderByDescending(pair => pair.Value).Take(elevi.Count);
            int counter = 1;
            foreach (var item in dict.OrderByDescending(pair => pair.Value).Take(elevi.Count))
            {
                if (counter <= 3)
                {
                    messagePremianti += counter.ToString() + ". " + item.Key.Nume + " " + item.Key.Prenume + ": " + item.Value.ToString() + "\n";

                } else if (item.Value >=8.50)
                {
                    messagePremianti += "Mentiune: " + item.Key.Nume + " " + item.Key.Prenume + ": " + item.Value.ToString() + "\n";
                } 
                counter++;
            }
            return Tuple.Create(messagePremianti, messageCorigenti, messageRepetenti);
        }
    }
}
