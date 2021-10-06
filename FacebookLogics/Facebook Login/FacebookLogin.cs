using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;

namespace FacebookLogics
{
    public class FacebookLogin : ILoginable
    {
        private string m_AppId = "577096943281764";
        private LoginResult m_LoginResult;
        private readonly string[] r_Permissions;

        public FacebookLogin()
        {
            r_Permissions = new[]
                                {
                                    "email", "public_profile",
                                    "user_age_range",
                                    "user_birthday",
                                    "user_events",
                                    "user_friends", 
                                    "user_gender",
                                    "user_hometown", 
                                    "user_likes",
                                    "user_link",
                                    "user_location",
                                    "user_photos", 
                                    "user_posts",
                                    "user_videos",
                                    "groups_access_member_info"
                                };


        }

        public void Login()
        {
           m_LoginResult = FacebookService.Login(m_AppId, r_Permissions);

        }

        public LoginResult GetLoginResult
        {
            get
            {
                return m_LoginResult;
            }
        }


    }
}
