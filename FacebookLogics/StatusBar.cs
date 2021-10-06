using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookLogics
{
    public class StatusBar
    {
        private TextBox m_StatusControl;
        private string m_CurrentStatus;

        public string SetNewStatus
        {
            set
            {
                m_CurrentStatus = value;
            }
        }

        public string GetCurrentStatus
        {
            get
            {
                return m_CurrentStatus;
            }
        }

        public StatusBar(TextBox io_StatusControl)
        {
            m_StatusControl = io_StatusControl;
            m_CurrentStatus = "Application is running!";
            ChangeStatus();
        }
        public void ChangeStatus()
        {
            m_StatusControl.Text = m_CurrentStatus;
        }

        public void NotifyOpacityUp()
        {
            m_CurrentStatus = "Opacity Has been raised";
            ChangeStatus();
        }

        public void NotifyOpacityDown()
        {
            m_CurrentStatus = "Opacity Has been lowered";
            ChangeStatus();
        }

        public void NotifyBrightnessRaised()
        {
            m_CurrentStatus = "Brightness has been raised";
            ChangeStatus();
        }

        public void NotifyBrightnessLowered()
        {
            m_CurrentStatus = "Brightness has been lowered";
            ChangeStatus();
        }

        public void NotifyProfilePictureEnlarged()
        {
            m_CurrentStatus = "Profile picture size has been raised";
            ChangeStatus();
        }

        public void NotifyProfilePictureShrink()
        {
            m_CurrentStatus = "Profile picture size has been lowered";
            ChangeStatus();
        }

        public void NotifyBackgroundImageChanged()
        {
            m_CurrentStatus = "Background image has been changed";
            ChangeStatus();
        }

        public void NotifyOpeningPhotographer()
        {
            m_CurrentStatus = "Photographer is preparing, Please wait for the new window to open";
            ChangeStatus();
        }

        public void NotifyVeryBest()
        {
            m_CurrentStatus = "Looking for your very best, please hold";
            ChangeStatus();
        }

        public void NotifyFortuneTeller()
        {
            m_CurrentStatus = "Your future waits...";
            ChangeStatus();
        }

        public void NotifyFetching()
        {
            m_CurrentStatus = "Fetching, please hold";
            ChangeStatus();
        }

    }
}
