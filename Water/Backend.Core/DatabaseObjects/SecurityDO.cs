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
        public AuthenticationDetailsEO FetchUser(string username, string password)
        {
            DataSet dataSet = RunSP_DS("p_FetchAuthenticationDetails_f", 
                ("@username", username), 
                ("@password", password));

            if (dataSet.Tables.Count == 1 && dataSet.Tables[0].Rows.Count ==1)
            {
                // Assuming the first row contains the user details
                AuthenticationDetailsEO authenticationDetails = new AuthenticationDetailsEO(dataSet.Tables[0].Rows[0]["Username"].ToString(), dataSet.Tables[0].Rows[0]["Password"].ToString());
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

        public bool RegisterUser(string username, string password, string email)
        {
            return RUNSP_Bool("p_RegisterUser_f",
                ("@username", username),
                ("@password", password));
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            // Implement password change logic here
            return false;
        }


    }
}
