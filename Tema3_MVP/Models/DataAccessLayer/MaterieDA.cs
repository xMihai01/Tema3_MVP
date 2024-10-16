﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tema3_MVP.Models.EntityLayer;
using Tema3_MVP.Utils;

namespace Tema3_MVP.Models.DataAccessLayer
{
    public class MaterieDA
    {
        public void AddMaterie(Materie Materie)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddMaterie", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@Nume", Materie.Nume);

                cmd.Parameters.Add(paramNume);
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteMaterie(int? idMaterie)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DeleteMaterie", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@id", idMaterie);
                cmd.Parameters.Add(paramIdMaterie);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public ObservableCollection<Materie> GetMaterii()
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetMaterii", connection);
                ObservableCollection<Materie> Materii = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie m = new Materie();
                    m.MaterieID = reader.GetInt32(0);
                    m.Nume = reader.GetString(1);
                    Materii.Add(m);
                }
                reader.Close();
                return Materii;
            }

        }
        public void UpdateMaterie(Materie Materie)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateMaterie", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@MaterieID", Materie.MaterieID);
                SqlParameter paramNume = new SqlParameter("@Nume", Materie.Nume);

                cmd.Parameters.Add(paramID);
                cmd.Parameters.Add(paramNume);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Couldn't update entry. unknown error occurred");
                }
            }
        }
        public ObservableCollection<Materie> GetMateriiForClasaAndProfesor(int? ClasaID, int? ProfesorID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetMateriiForClasaAndProfesor", connection);
                SqlParameter paramClasaID = new SqlParameter("@ClasaID", ClasaID);
                SqlParameter paramProfID = new SqlParameter("@ProfesorID", ProfesorID);
                cmd.Parameters.Add(paramClasaID);
                cmd.Parameters.Add(paramProfID);
                ObservableCollection<Materie> Materii = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie m = new Materie();
                    m.MaterieID = reader.GetInt32(0);
                    m.Nume = reader.GetString(1);
                    Materii.Add(m);
                }
                reader.Close();
                return Materii;
            }

        }
        public ObservableCollection<Materie> GetMateriiForClasa(int? ClasaID)
        {
            using (SqlConnection connection = DataAccessUtil.Connect())
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("GetMateriiForClasa", connection);
                SqlParameter paramClasaID = new SqlParameter("@ClasaID", ClasaID);
                cmd.Parameters.Add(paramClasaID);
                ObservableCollection<Materie> Materii = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie m = new Materie();
                    m.MaterieID = reader.GetInt32(0);
                    m.Nume = reader.GetString(1);
                    Materii.Add(m);
                }
                reader.Close();
                return Materii;
            }

        }
    }
}
