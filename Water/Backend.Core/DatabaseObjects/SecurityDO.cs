using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                AuthenticationDetailsEO authenticationDetails = new AuthenticationDetailsEO((int)dataSet.Tables[0].Rows[0]["ID"], dataSet.Tables[0].Rows[0]["Username"].ToString(), dataSet.Tables[0].Rows[0]["Password"].ToString());
                return authenticationDetails;
            }
            else if (dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            else
            {
                throw new Exception("Unexpected data format received from the database.");
            }
        }

        public int FetchUserRoles(string username)
        {
            DataSet dataSet = RunSP_DS("p_FetchUserRoles_f",
                ("@Username", username));
            if (dataSet.Tables.Count == 1 && dataSet.Tables[0].Rows.Count == 1)
            {
                int role = (int)dataSet.Tables[0].Rows[0]["Role"];
                return role;
            }
            else
            {
                throw new Exception("Unexpected data format received from the database.");
            }
        }

        public bool AddUserRoles(int userID, int role)
        {
            return RunSP_Bool("p_AddUserRoles_i", 
                ("@UserID", userID), 
                ("@Role", role));
        }

        public bool AddAuthenticationDetails(string username, string password)
        {
            return RunSP_Bool("p_AddAuthenticationDetails_f",
                ("@Username", username),
                ("@Password", password));
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            // Implement password change logic here
            return false;
        }
    }
}
