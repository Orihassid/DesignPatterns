using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Media;
using System.Threading;
using BasicFacebookFeatures.Properties;
using FacebookLogics;
using FacebookLogics.Birthday_Feature;
using StatusBar = FacebookLogics.StatusBar;

namespace BasicFacebookFeatures
{
    public sealed partial class FormMain : Form
    {
        private readonly FacebookLogin r_FacebookLogin;
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        private PreferencesFacade m_PreferencesFacade;
        private static readonly object sr_Lock = new object();
        private static FormMain s_Instance = null;
        private StatusBar m_StatusBar;
        public static FormMain Instance
        {
            get
            {
                lock (sr_Lock)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new FormMain();
                    }
                    return s_Instance;
                }
            }
        }

        private FormMain()
        {
          InitializeComponent();
          initializePreferencesFacade();
          initializeStatusBar();
          FacebookWrapper.FacebookService.s_CollectionLimit = 100;
          r_FacebookLogin = new FacebookLogin();
        }

        private void initializePreferencesFacade()
        {
            m_PreferencesFacade = new PreferencesFacade(numericUpDownBirthdayBackgroundImage, numericUpDownPhotographerBackgroundImage, tabPageBirthday, tabPhotographer, tabPagePreferences);
            m_PreferencesFacade.SetFirstBirthdayBackground();
            pictureBoxBirthdayBackground.Image = m_PreferencesFacade.GetBirthdayImage(1);
            m_PreferencesFacade.SetFirstPhotographerBackground();
            pictureBoxPhotographerBackground.BackgroundImage = m_PreferencesFacade.GetPhotographerImage(1);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
           new Thread(loginSequence).Start();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            buttonLogin.Text = "Login";
        }

        private void initializeStatusBar()
        {
            m_StatusBar = new StatusBar(textBoxStatus);
            initializeBirthdayFactoryStatusBar();
            initializeMainButtonsStatusBar();
            initializePhotographerStatusBar();
            initializePreferencesStatusBar();
            initializeVeryBestStatusBar();
        }

        private void initializePreferencesStatusBar()
        {
            buttonOpacityUp.Click += (buttonOpacityUp, i_OpacityChangeEvent) => m_StatusBar.NotifyOpacityUp();
            buttonOpacityDown.Click += (buttonOpacityDown, i_OpacityChangeEvent) => m_StatusBar.NotifyOpacityDown();
            buttonPreferenceBrightnessUp.Click += (buttonPreferenceBrightnessUp, i_BrightnessChange) => m_StatusBar.NotifyBrightnessRaised();
            buttonPreferenceBrightnessDown.Click += (buttonPreferenceBrightnessDown, i_BrightnessChange) => m_StatusBar.NotifyBrightnessLowered();
            buttonProfilePictureSizeUp.Click += (buttonProfilePictureSizeUp, i_ProfilePictureSizeChange) => m_StatusBar.NotifyProfilePictureEnlarged();
            buttonProfilePictureSizeDown.Click += (buttonProfilePictureSizeDown, i_OpacityUpi_ProfilePictureSizeChangeEvent) => m_StatusBar.NotifyProfilePictureShrink();
            numericUpDownBirthdayBackgroundImage.ValueChanged += (numericUpDownBirthdayBackgroundImage, i_ChangeBackground) => m_StatusBar.NotifyBackgroundImageChanged();
            numericUpDownPhotographerBackgroundImage.ValueChanged += (numericUpDownPhotographerBackgroundImage, i_ChangeBackground) => m_StatusBar.NotifyBackgroundImageChanged();
        }

        private void initializeMainButtonsStatusBar()
        {
            buttonAlbums.Click += (buttonAlbums, i_Fetching) => m_StatusBar.NotifyFetching();
            buttonFetchPosts.Click += (buttonFetchPosts, i_Fetching) => m_StatusBar.NotifyFetching();
            buttonFetchGroups.Click += (buttonFetchGroups, i_Fetching) => m_StatusBar.NotifyFetching();
            buttonFetchEvents.Click += (buttonFetchEvents, i_Fetching) => m_StatusBar.NotifyFetching();
        }

        private void initializeBirthdayFactoryStatusBar()
        {
            buttonHoroscope.Click += (buttonHoroscope, i_Horoscope) => m_StatusBar.NotifyFortuneTeller();
        }

        private void initializePhotographerStatusBar()
        {
            buttonCollage.Click += (buttonCollage, i_OpenPhotographerWindow) => m_StatusBar.NotifyOpeningPhotographer();
            buttonShelf.Click += (buttonShelf, i_OpenPhotographerWindow) => m_StatusBar.NotifyOpeningPhotographer();
        }

        private void initializeVeryBestStatusBar()
        {
            buttonFetchBestPhoto.Click += (buttonFetchBestPhoto, i_Fetching) => m_StatusBar.NotifyVeryBest();
            buttonFetchBestPost.Click += (buttonFetchBestPhoto, i_Fetching) => m_StatusBar.NotifyVeryBest();
        }
        private void loginSequence()
        {
            r_FacebookLogin.Login();
            m_LoginResult = r_FacebookLogin.GetLoginResult;
            m_LoggedInUser = m_LoginResult.LoggedInUser;
            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                Invoke(new Action(() => fetchProfilePicture()));
                buttonLogin.Invoke(new Action(() => buttonLogin.Text = $"Logged in as {m_LoggedInUser.Name}"));
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                Invoke(new Action(() => successfulLoginVisibilityChanger()));
            }
            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage, "Login Failed");
            }
        }
        private void successfulLoginVisibilityChanger()
        {
           birthdayFactoryVisibilityChange();
           bestPostVisibilityChange(); 
           welcomePageVisibilityChange();
           photographerVisibilityChanger();
       
        }

        private void photographerVisibilityChanger()
        {
            buttonCollage.Visible = true;
            buttonShelf.Visible = true;
            labelPhotographerLogin.Visible = false;
        }

        private void birthdayFactoryVisibilityChange()
        {
            pictureBoxCake.Visible = true;
            labelBirthday.Visible = true;
            buttonHoroscope.Visible = true;
            labelBirthdayBeforeLoginMsg.Visible = false;
            buttonFetchFriends.Visible = true;
            listBoxFriends.Visible = true;
            pictureBoxFriendGem.Visible = true;
        }

        private void bestPostVisibilityChange()
        {
            monthCalendarStartingDate.Visible = true;
            monthCalendarEndingDate.Visible = true;
            labelDateStart.Visible = true;
            labelEndDate.Visible = true;
            checkBoxComments.Visible = true;
            checkBoxLikes.Visible = true;
            buttonFetchBestPost.Visible = true;
            textBoxBestPost.Visible = true;
            pictureBoxBestPost.Visible = true;
            labelMustLoginBestPost.Visible = false;
            pictureBoxBestPhoto.Visible = true;
            labelBestPhoto.Visible = true;
            labelBestPost.Visible = true;
            labelBestPostPhoto.Visible = true;
            buttonFetchBestPhoto.Visible = true;
        }

        private void welcomePageVisibilityChange()
        {
            buttonAlbums.Visible = true;
            listBoxOfAlbums.Visible = true;
            buttonFetchPosts.Visible = true;
            listBoxPosts.Visible = true;
            buttonFetchEvents.Visible = true;
            listBoxOfEvents.Visible = true;
            buttonFetchGroups.Visible = true;
            listBoxGroups.Visible = true;
            labelLoginWelcome.Visible = false;
            textBoxPost.Visible = true;
            buttonPost.Visible = true;
        }

        private void buttonFetchPosts_Click(object sender, EventArgs e)
        {
            new Thread(fetchPosts).Start();
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            new Thread(fetchAlbums).Start();
        }

        private void buttonFetchEvents_Click(object sender, EventArgs e)
        {
            new Thread(fetchEvents).Start();
        }

        private void buttonFetchGroups_Click(object sender, EventArgs e)
        {
            new Thread(fetchGroups).Start();
        }

        private void fetchPosts()
        {
            listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Clear()));

            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(post.Message)));
                }
                else if (post.Caption != null)
                {
                    listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(post.Caption)));
                }
                else
                {
                    listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(string.Format("[{0}]", post.Type))));
                }
            }

            if (listBoxPosts.Items.Count == 0)
            {
                MessageBox.Show("No Posts to retrieve :(");
            }
        }

        private void fetchAlbums()
        {
            listBoxOfAlbums.Invoke(new Action(() => listBoxOfAlbums.Items.Clear()));
            listBoxOfAlbums.Invoke(new Action(() => listBoxOfAlbums.DisplayMember = "Name"));

            foreach (Album album in m_LoggedInUser.Albums)
            { 
                listBoxOfAlbums.Invoke(new Action(() => listBoxOfAlbums.Items.Add(album)));
            }

            if (listBoxOfAlbums.Items.Count == 0)
            {
                MessageBox.Show("No Albums to retrieve :(");
            }
        }


        private void fetchEvents()
        {
            listBoxOfEvents.Invoke(new Action(() => listBoxOfEvents.Items.Clear()));
            listBoxOfEvents.Invoke(new Action(() => listBoxOfEvents.DisplayMember = "Name"));
            foreach (Event fbEvent in m_LoggedInUser.Events)
            {
                listBoxOfEvents.Invoke(new Action(() => listBoxOfEvents.Items.Add(fbEvent)));
            }

            if (listBoxOfEvents.Items.Count == 0)
            {
                MessageBox.Show("No Events to retrieve :(");
            }
        }


        private void fetchGroups()
        {
            listBoxOfEvents.Invoke(new Action(() => listBoxGroups.Items.Clear()));
            listBoxOfEvents.Invoke(new Action(() => listBoxGroups.DisplayMember = "Name"));

            try
            {
                foreach (Group group in m_LoggedInUser.Groups)
                {
                    listBoxOfEvents.Invoke(new Action(() => listBoxGroups.Items.Add(group)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listBoxGroups.Items.Count == 0)
            {
                MessageBox.Show("No groups to retrieve :(");
            }
        }

        private void fetchBirthday()
        {
            textBoxBirthday.Enabled = true;
            textBoxBirthday.Visible = true;
            textBoxBirthday.Text = m_LoggedInUser.Birthday;
            pictureBoxCake.Enabled = true;
            pictureBoxCake.Visible = true;

        }

        private void fetchProfilePicture()
        {
            pictureBoxProfilePicture.Enabled = true;
            pictureBoxProfilePicture.Visible = true;
            pictureBoxProfilePicture.LoadAsync(m_LoggedInUser.PictureNormalURL);
        }

        private void editMonthsUntilBirthday()
        {
            textBoxBirthdayMonthCount.Invoke(new Action(() => textBoxBirthdayMonthCount.Text = BirthdayFeatureLogics.CreateBirthdayMsg(m_LoggedInUser.Birthday)));
        }

        private void pictureBoxCake_Click(object sender, EventArgs e)
        {
            fetchBirthday();
            new Thread(editMonthsUntilBirthday).Start();
            textBoxBirthdayMonthCount.Visible = true;
            SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.HappyBDayCut);
            player.Play();
            pictureBoxCake.Enabled = false;
            textBoxBirthday.Enabled = false;
        }

        private void buttonHoroscope_Click(object sender, EventArgs e)
        {
            string userBirthday = m_LoggedInUser.Birthday;
            if (userBirthday != null)
            {
                Charm charm = CharmArray.GetCharmFromBirthday(userBirthday);
                labelCharm.Text = "Your charm is " + charm.Gem.ToString();
                textBoxFortune.Text = charm.Fortune;
                textBoxFortune.Visible = true;
                pictureBoxFortune.Image = charm.FortuneGem;
                pictureBoxFortuneGif.Image = Resources.fortuneTellerGif;
                pictureBoxFortuneGif.Visible = true;
                SoundPlayer player = new System.Media.SoundPlayer(Resources.FortuneTellerCut);
                player.Play();
                labelCharm.Visible = true;
            }
        }

        private void fetchFriends()
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.DisplayMember = "Name";

            try
            {
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    listBoxFriends.Items.Add(friend);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (listBoxFriends.Items.Count == 0)
            {
                MessageBox.Show("No friends to retrieve :(");
            }
        }

        private void buttonFetchFriends_Click(object sender, EventArgs e)
        {
            fetchFriends();
        }

        private void displaySelectedFriendGem()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                User selectedUser = listBoxFriends.SelectedItem as User;
                if (selectedUser.Birthday != null)
                {
                    Charm friendCharm = CharmArray.GetCharmFromBirthday(selectedUser.Birthday);
                    pictureBoxFriendGem.Image = friendCharm.FortuneGem;
                }
                else
                {
                    pictureBoxFriendGem.Image = pictureBoxFriendGem.ErrorImage;
                }
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaySelectedFriendGem();
        }

        private void buttonFetchBestPost_Click(object sender, EventArgs e)
        {
            new Thread(fetchBestPost).Start();
        }

        private void fetchBestPost()
        {
            //get dates from monthly calender
            DateTime endingDateTime = new DateTime(
                monthCalendarEndingDate.SelectionRange.Start.Year,
                monthCalendarEndingDate.SelectionRange.Start.Month,
                monthCalendarEndingDate.SelectionRange.Start.Day);

            DateTime startingDateTime = new DateTime(
                monthCalendarStartingDate.SelectionRange.Start.Year,
                monthCalendarStartingDate.SelectionRange.Start.Month,
                monthCalendarStartingDate.SelectionRange.Start.Day);

            fetchBestPostByDate(startingDateTime, endingDateTime);
        }

        private void fetchBestPostByDate(DateTime i_StartingDate, DateTime i_EndingDate)
        {
            List<Post> userPostsByDate = fetchPostListByDate(i_StartingDate, i_EndingDate);
            if (userPostsByDate.Count > 0)
            {
                changeBestPostText(userPostsByDate);
            }
        }

        private List<Post> fetchPostListByDate(DateTime i_StartingDate, DateTime i_EndingDate)
        {
            List<Post> userPostsByDate = new List<Post>();
            try
            {
                if (i_StartingDate <= i_EndingDate)
                {
                    foreach (Post userPost in m_LoggedInUser.Posts)
                    {
                        if (userPost.UpdateTime <= i_EndingDate && userPost.UpdateTime >= i_StartingDate)
                        {
                            userPostsByDate.Add(userPost);
                        }
                    }
                }
                else
                {
                    throw new Exception("Select correct dates! (starting date before ending date)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return userPostsByDate;
        }

        private void changePictureAndDescriptionOfBestPost(Post i_MostPopulatedPost)
        {
            if (i_MostPopulatedPost != null)
            {
                if (i_MostPopulatedPost.Type == Post.eType.photo)
                {
                    pictureBoxBestPost.Invoke(new Action(() => pictureBoxBestPost.LoadAsync(i_MostPopulatedPost.PictureURL)));
                }

                if (i_MostPopulatedPost.Caption != null)
                {
                    textBoxBestPost.Invoke(new Action(() => textBoxBestPost.Text = i_MostPopulatedPost.Caption));
                }
                else if (i_MostPopulatedPost.Message != null)
                {
                    textBoxBestPost.Invoke(new Action(() => textBoxBestPost.Text = i_MostPopulatedPost.Message));
                }
                else if (i_MostPopulatedPost.Description != null)
                {
                    textBoxBestPost.Invoke(new Action(() => textBoxBestPost.Text = i_MostPopulatedPost.Description));
                }
            }
        }

        private void changeBestPostText(List<Post> i_UserPosts)
        {
            try
            {
                if (checkBoxComments.Checked || checkBoxLikes.Checked)
                {
                    Post mostPopulatedPost = BestPostFeatureLogics.GetMostPopulatedPost(
                        i_UserPosts,
                        checkBoxComments.Checked,
                        checkBoxLikes.Checked);

                    if (mostPopulatedPost != null)
                    {
                        changePictureAndDescriptionOfBestPost(mostPopulatedPost);
                    }
                    else
                    {
                        throw new Exception("Couldn't fetch your best post, we are sorry");
                    }

                }
                else
                {
                    throw new Exception("Please check likes, comments, or both!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int postIndex = listBoxPosts.SelectedIndex;
            if (postIndex < m_LoggedInUser.Posts.Count)
            {
                string pictureURL = m_LoggedInUser.Posts[postIndex].PictureURL;
                if (!string.IsNullOrEmpty(pictureURL))
                {
                    pictureBoxPost.Visible = true;
                    pictureBoxPost.LoadAsync(pictureURL);
                }
                else
                {
                    pictureBoxPost.Visible = false;
                }
            }
        }

        private void listBoxOfAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            int albumIndex = listBoxOfAlbums.SelectedIndex;
            if (albumIndex < m_LoggedInUser.Albums.Count)
            {
                string pictureURL = m_LoggedInUser.Albums[albumIndex].PictureAlbumURL;
                if (!string.IsNullOrEmpty(pictureURL))
                {
                    pictureBoxAlbum.Visible = true;
                    pictureBoxAlbum.LoadAsync(pictureURL);
                }
                else
                {
                    pictureBoxAlbum.Visible = false;
                }
            }

        }

        private void listBoxOfEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            int eventIndex = listBoxOfEvents.SelectedIndex;
            if (eventIndex < m_LoggedInUser.Events.Count)
            {
                string pictureURL = m_LoggedInUser.Events[eventIndex].PictureNormalURL;
                if (!string.IsNullOrEmpty(pictureURL))
                {
                    pictureBoxEvent.Visible = true;
                    pictureBoxEvent.LoadAsync(pictureURL);
                }
                else
                {
                    pictureBoxEvent.Visible = false;
                }
            }

        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            int groupIndex = listBoxGroups.SelectedIndex;
            if (groupIndex < m_LoggedInUser.Groups.Count)
            {
                string pictureURL = m_LoggedInUser.Groups[groupIndex].PictureSqaureURL;
                if (!string.IsNullOrEmpty(pictureURL))
                {
                    pictureBoxGroup.Visible = true;
                    pictureBoxGroup.LoadAsync(pictureURL);
                }
                else
                {
                    pictureBoxGroup.Visible = false;
                }
            }

        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPost.Text))
            {
                m_LoggedInUser.PostStatus(textBoxPost.Text);
            }
            else
            {
                MessageBox.Show("Enter text to post");
            }
        }

        private void buttonFetchBestPhoto_Click(object sender, EventArgs e)
        {
            new Thread(fetchBestPhoto).Start();
        }

        private void fetchBestPhoto()
        {
            if (checkBoxLikes.Checked || checkBoxComments.Checked)
            {
                DateTime endingDateTime = new DateTime(
                    monthCalendarEndingDate.SelectionRange.Start.Year,
                    monthCalendarEndingDate.SelectionRange.Start.Month,
                    monthCalendarEndingDate.SelectionRange.Start.Day);

                DateTime startingDateTime = new DateTime(
                    monthCalendarStartingDate.SelectionRange.Start.Year,
                    monthCalendarStartingDate.SelectionRange.Start.Month,
                    monthCalendarStartingDate.SelectionRange.Start.Day);

                if (startingDateTime <= endingDateTime)
                {
                    fetchBestPhotoByDate(startingDateTime, endingDateTime);
                }
                else
                {
                    MessageBox.Show("Please select correct time and date");
                }
            }
            else
            {
                MessageBox.Show("Please check: by likes or comments");
            }
        }

        private void fetchBestPhotoByDate(DateTime i_StartingDate, DateTime i_EndingDate)
        {
            Photo bestPhoto = null;
            List<Photo> userPhotoList = fetchPhotosByDate(i_StartingDate, i_EndingDate);
            if (userPhotoList.Count > 0)
            {
                bestPhoto = BestPostFeatureLogics.GetMostPopulatedPhoto(userPhotoList, checkBoxComments.Checked, checkBoxLikes.Checked);
            }
            else
            {
                MessageBox.Show("No photos to fetch by those dates, maybe try other dates");
            }

            if (bestPhoto != null)
            {
                pictureBoxBestPhoto.Invoke(new Action(() => pictureBoxBestPhoto.Image = bestPhoto.ImageNormal));
            }
        }

        private List<Photo> fetchPhotosByDate(DateTime i_StartingDate, DateTime i_EndingDate)
        {
            List<Photo> userPhotoList = new List<Photo>();
            if (m_LoggedInUser.PhotosTaggedIn.Count > 0)
            {
                foreach (Photo userPhoto in m_LoggedInUser.PhotosTaggedIn)
                {
                    if (userPhoto.CreatedTime >= i_StartingDate && userPhoto.CreatedTime <= i_EndingDate)
                    {
                        userPhotoList.Add(userPhoto);
                    }
                }
            }

            return userPhotoList;
        }

        private void buttonCollage_Click(object sender, EventArgs e)
        {
            FormPhotographer newPhotographer = new FormPhotographer(m_LoggedInUser.PhotosTaggedIn, Photographer.ePhotoType.Collage);
            newPhotographer.Show();
        }

        private void buttonShelf_Click(object sender, EventArgs e)
        {
            FormPhotographer newPhotographer = new FormPhotographer(m_LoggedInUser.PhotosTaggedIn, Photographer.ePhotoType.Shelf);
            newPhotographer.Show();
        }

        private void numericUpDownBirthdayBackgroundImage_ValueChanged(object sender, EventArgs e)
        {
            int imageIndex = (int)numericUpDownBirthdayBackgroundImage.Value;
            m_PreferencesFacade.SetNewBirthdayImage(imageIndex);
            pictureBoxBirthdayBackground.Image = m_PreferencesFacade.GetBirthdayImage(imageIndex);
        }

        private void numericUpDownPhotographerBackgroundImage_ValueChanged(object sender, EventArgs e)
        {
            int imageIndex = (int)numericUpDownPhotographerBackgroundImage.Value;
            m_PreferencesFacade.SetNewPhotographerImage(imageIndex);
            pictureBoxPhotographerBackground.Image = m_PreferencesFacade.GetPhotographerImage(imageIndex);
        }

        private void buttonOpacityUp_Click(object sender, EventArgs e)
        {
            Opacity = m_PreferencesFacade.OpacityUp();
        }


        private void buttonOpacityDown_Click(object sender, EventArgs e)
        {
            Opacity = m_PreferencesFacade.OpacityDown();
        }

        private void changeLabelColorToInvertedTextColorBlackAndWhite(int i_NewBrightness)
        {
            Color newColor = m_PreferencesFacade.InvertTextColorBlackAndWhite(i_NewBrightness);
            labelOpacity.ForeColor = newColor;
            labelBackgroundPhotographer.ForeColor = newColor;
            labelBrithdayFactoryBackground.ForeColor = newColor;
            labelPreferencesBrightness.ForeColor = newColor;
            labelProfilePictureSize.ForeColor = newColor;
        }

        private void buttonPreferencesBrightnessDown_Click(object sender, EventArgs e)
        {
            m_PreferencesFacade.PreferencesBrightnessDown();
            changeLabelColorToInvertedTextColorBlackAndWhite(m_PreferencesFacade.GetBrightness);
        }

        private void buttonPreferenceBrightnessUp_Click(object sender, EventArgs e)
        {
            m_PreferencesFacade.PreferencesBrightnessUp();
            changeLabelColorToInvertedTextColorBlackAndWhite(m_PreferencesFacade.GetBrightness);
        }

        private void buttonSupportEmailShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact moraf@mta.ac.il");
        }

        private void buttonProfilePictureSizeDown_Click(object sender, EventArgs e)
        {
            pictureBoxProfilePicture.Size = m_PreferencesFacade.ProfilePictureDownSize(pictureBoxProfilePicture.Size);
        }

        private void buttonProfilePictureSizeUp_Click(object sender, EventArgs e)
        {
            pictureBoxProfilePicture.Size = m_PreferencesFacade.ProfilePictureUpSize(pictureBoxProfilePicture.Size);
        }

    }
}