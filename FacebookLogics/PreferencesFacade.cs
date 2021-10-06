using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookLogics;

namespace BasicFacebookFeatures
{
    public class PreferencesFacade
    {
        private readonly List<Image> r_BirthdayFactoryBackgroundImages;
        private readonly List<Image> r_PhotographerBackgroundImages;
        private int m_PreferencesBrightness;
        private double m_Opacity;
        private readonly TabPage r_BirthdayPage;
        private readonly TabPage r_PhotographerPage;
        private readonly TabPage r_PreferencesPage;

        public int GetBrightness
        {
            get
            {
                return m_PreferencesBrightness;
            }
        }


        public PreferencesFacade(NumericUpDown i_BirthdayBackground, NumericUpDown i_PhotographerBackground, TabPage i_BirthdayPage, TabPage i_PhotographerPage, TabPage i_PreferencesPage)
        {
            m_Opacity = 1.0;
            r_BirthdayFactoryBackgroundImages = new List<Image>();
            r_PhotographerBackgroundImages = new List<Image>();
            initializePreferences(i_BirthdayBackground, i_PhotographerBackground);
            r_BirthdayPage = i_BirthdayPage;
            r_PhotographerPage = i_PhotographerPage;
            r_PreferencesPage = i_PreferencesPage;
        }
        private void initializePreferences(NumericUpDown i_BirthdayBackground, NumericUpDown i_PhotographerBackground)
        {

            assembleBirthdayFactoryBackgroundList(i_BirthdayBackground);
            assemblePhotographerBackgroundList(i_PhotographerBackground);
            initializePreferencesBackgroundBrightness();
        }

        private void assembleBirthdayFactoryBackgroundList(NumericUpDown i_BirthdayBackground)
        {
            gatherBirthdayBackgroundImages();
            i_BirthdayBackground.Maximum = r_BirthdayFactoryBackgroundImages.Count;
            i_BirthdayBackground.Minimum = 1;
            i_BirthdayBackground.Value = i_BirthdayBackground.Minimum;
        }

        private void assemblePhotographerBackgroundList(NumericUpDown i_PhotographerBackground)
        {
            gatherPhotographerBackgroundImages();
            i_PhotographerBackground.Maximum = r_PhotographerBackgroundImages.Count;
            i_PhotographerBackground.Minimum = 1;
            i_PhotographerBackground.Value = i_PhotographerBackground.Minimum;
        }

        private void gatherBirthdayBackgroundImages()
        {
            r_BirthdayFactoryBackgroundImages.Add(Resource1.BirthdayFactoryBackgroundImage1);
            r_BirthdayFactoryBackgroundImages.Add(Resource1.BirthdayFactoryBackgroundImage2);
            r_BirthdayFactoryBackgroundImages.Add(Resource1.BirthdayFactoryBackgroundImage3);
            r_BirthdayFactoryBackgroundImages.Add(Resource1.BirthdayFactoryBackgroundImage4);
            r_BirthdayFactoryBackgroundImages.Add(Resource1.BirthdayFactoryBackgroundImage5);
            r_BirthdayFactoryBackgroundImages.Add(Resource1.BirthdayFactoryBackgroundImage6);
            r_BirthdayFactoryBackgroundImages.Add(Resource1.BirthdayFactoryBackgroundImage7);
        }

        private void gatherPhotographerBackgroundImages()
        {
            r_PhotographerBackgroundImages.Add(Resource1.PhotographerBackgroundImage1);
            r_PhotographerBackgroundImages.Add(Resource1.PhotographerBackgroundImage2);
            r_PhotographerBackgroundImages.Add(Resource1.PhotographerBackgroundImage3);
            r_PhotographerBackgroundImages.Add(Resource1.PhotographerBackgroundImage4);
            r_PhotographerBackgroundImages.Add(Resource1.PhotographerBackgroundImage5);
        }

        public void SetFirstBirthdayBackground()
        {
            r_BirthdayPage.BackgroundImage = r_BirthdayFactoryBackgroundImages[0];
        }

        public void SetFirstPhotographerBackground()
        {
            r_PhotographerPage.BackgroundImage = r_PhotographerBackgroundImages[0];
        }

        private void initializePreferencesBackgroundBrightness()
        {
            m_PreferencesBrightness = 255;
        }

        public Image GetBirthdayImage(int i_BackgroundIndex)
        {
            Image newBackground = r_BirthdayFactoryBackgroundImages[i_BackgroundIndex - 1];
            return newBackground;
        }

        public void SetNewBirthdayImage(int i_ImageIndex)
        {
            r_BirthdayPage.BackgroundImage = r_BirthdayFactoryBackgroundImages[i_ImageIndex - 1];
        }

        public void SetNewPhotographerImage(int i_ImageIndex)
        {
            r_PhotographerPage.BackgroundImage = r_PhotographerBackgroundImages[i_ImageIndex - 1];
        }

        public Image GetPhotographerImage(int i_BackgroundIndex)
        {
            Image newBackground = r_PhotographerBackgroundImages[i_BackgroundIndex - 1];
            return newBackground;
        }

        public double OpacityDown()
        {
            if (m_Opacity >= 0.5)
            {
                m_Opacity -= 0.1;
            }

            return m_Opacity;
        }

        public double OpacityUp()
        {
            if (m_Opacity <= 1.0)
            {
                m_Opacity += 0.1;
            }

            return m_Opacity;
        }

        public void PreferencesBrightnessDown()
        {
            Color newColor = Color.FromArgb(m_PreferencesBrightness, m_PreferencesBrightness, m_PreferencesBrightness);
            int newBrightness = m_PreferencesBrightness - 20;
            if (newBrightness >= 0)
            {
                m_PreferencesBrightness = newBrightness;
                newColor = Color.FromArgb(newBrightness, newBrightness, newBrightness);
            }

            r_PreferencesPage.BackColor = newColor;

        }

        public void PreferencesBrightnessUp()
        {
            Color newColor = Color.FromArgb(m_PreferencesBrightness, m_PreferencesBrightness, m_PreferencesBrightness);
            int newBrightness = m_PreferencesBrightness + 20;
            if (newBrightness <= 255)
            {
                m_PreferencesBrightness = newBrightness;
                newColor = Color.FromArgb(newBrightness, newBrightness, newBrightness);
            }

            r_PreferencesPage.BackColor = newColor;

        }

        public Color InvertTextColorBlackAndWhite(int i_NewBrightness)
        {
            int newColorNumber = 255 - i_NewBrightness;
            Color newColor = Color.FromArgb(newColorNumber, newColorNumber, newColorNumber);
            return newColor;
        }

        public Size ProfilePictureUpSize(Size i_OldSize)
        {
            Size returnedSize = i_OldSize;
            Size newSize = i_OldSize;
            newSize.Height -= 10;
            newSize.Width -= 10;
            if(newSize.Height > 0 && newSize.Width > 0)
            {
                returnedSize = newSize;
            }

            return returnedSize;
        }

        public Size ProfilePictureDownSize(Size i_OldSize)
        {
            Size newSize = i_OldSize;
            newSize.Height += 10;
            newSize.Width += 10;
            return newSize;
        }

    }
}
