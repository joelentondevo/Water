using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.DatabaseObjects.Interfaces;
using Backend.Core.EntityObjects;

namespace Backend.Core.DatabaseObjects
{
    internal class SecurityDO : BaseDO, ISecurityDO
    {
        public AuthenticationDetailsEO FetchAuthenticationDetails(string username)
        {
            DataSet dataSet = RunSP_DS("p_FetchAuthenticationDetails_f", 
                ("@username", username));

            if (dataSet.Tables.Count == 1 && dataSet.Tables[0].Rows.Count ==1)
            {
                // Assuming the first row contains the user details
                AuthenticationDetailsEO authenticationDetails = new AuthenticationDetailsEO((int)dataSet.Tables[0].Rows[0]["ID"], dataSet.Tables[0].Rows[0]["Username"].ToString(), dataSet.Tables[0].Rows[0]["Password"].ToString());
                return authenticationDetails;
            }
            else if (dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
            {
                // No user found with the provided credentials
                return null;
            }
            else
            {
                // Unexpected data format, handle accordingly
                throw new Exception("Unexpected data format received from the database.");
            }
        }

        public bool AddAuthenticationDetails(string username, string password)
        {
            return RUNSP_Bool("p_AddAuthenticationDetails_f",
                ("@Username", username),
                ("@Password", password));
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            // Implement password change logic here
            return false;
        }

        public int GetUserIDFromAuthenticationDetails(string username, string password)
        {
            DataSet dataSet = RunSP_DS("p_FetchUserIDFromAuthenticationDetails",
                ("@Username", username),
                ("@Password", password));

            if (dataSet.Tables.Count == 1 && dataSet.Tables[0].Rows.Count == 1)
            {
                return (int)dataSet.Tables[0].Rows[0]["ID"];
            }
            else
            {
                return 0;
            }
        }
    }
}
