using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FamilyExpenseTracker.Models
{
    public class FamilyExpenseModelManager
    {
        //Read connection string from web.config
        private string cs = ConfigurationManager.ConnectionStrings["familyexpensetracker_cs"].ConnectionString;

        // call sp GetFamilyExpense
        public List<FamilyExpenseViewModel> GetFamilyExpenses()
        {
            //ado code
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("GetFamilyExpenses", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        if (connection.State == System.Data.ConnectionState.Closed)
                        {
                            connection.Open();
                            SqlDataReader dr = command.ExecuteReader();
                            List<FamilyExpenseViewModel> familyExpenses = new List<FamilyExpenseViewModel>();
                            while (dr.Read())
                            {
                                FamilyExpenseViewModel familyExpense = new FamilyExpenseViewModel();
                                familyExpense.Id = Convert.ToInt32(dr["ExpenseId"]);
                                familyExpense.FamilyMemberName = dr["Name"].ToString();
                                familyExpense.Purpose = dr["Purpose"].ToString();
                                familyExpense.Amount = Convert.ToInt32(dr["Amount"].ToString());
                                familyExpense.Date = Convert.ToDateTime(dr["DateTime"]);
                                familyExpenses.Add(familyExpense);
                            }
                            return familyExpenses;
                        }
                    }

                    catch (SqlException ex)
                    {
                        throw ex;
                    }

                    finally
                    {
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            return null;
        }

        public bool AddFamilyExpense(FamilyExpense familyExpense)
        {
            return true;
        }

        public bool EditFamilyExpense(FamilyExpense familyExpense)
        {
            return true;
        }

        public bool DeleteFamilyExpense(FamilyExpense familyExpense)
        {
            return true;
        }
    }
}