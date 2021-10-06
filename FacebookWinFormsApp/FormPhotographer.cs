using System;
using System.Windows.Forms;
using FacebookLogics;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class FormPhotographer : Form
    {
        private PictureBox m_LastAddedImage;
        private readonly Photographer r_Photographer;
        public FormPhotographer(FacebookObjectCollection<Photo> io_UserPhotoList, Photographer.ePhotoType i_PhotoType)
        {
            r_Photographer = new Photographer(io_UserPhotoList, i_PhotoType);
            Text = Text + i_PhotoType.ToString();
            InitializeComponent();
        }

        private void afterLoadingNewPicture(PictureBox i_NewPicture)
        {
            m_LastAddedImage = i_NewPicture;
            this.Controls.Add(i_NewPicture);
            i_NewPicture.BringToFront();
            bringButtonsToFront();
            photoBindingSource.DataSource = r_Photographer.CurrentImage();
            bringPhotoDataToFront();

        }

        private void bringPhotoDataToFront()
        {
            textBoxDataBindingBackground.BringToFront();
            createdTimeLabelValue.BringToFront();
            linkTextBox.BringToFront();
            labelPhotoDate.BringToFront();
            labelPhotoLink.BringToFront();
        }

        private void buttonAddPhoto_Click(object sender, EventArgs e)
        {
            PictureBox newPicture = r_Photographer.CreateSquarePictureBox(this.Width, this.Height);
            afterLoadingNewPicture(newPicture);

        }

        private void bringButtonsToFront()
        {
            buttonAddPhoto.BringToFront();
            buttonBigger.BringToFront();
            buttonSmaller.BringToFront();
            buttonBlinkingPicture.BringToFront();
            buttonDisappearingPicture.BringToFront();
            buttonDoubleSize.BringToFront();
            buttonHalfSize.BringToFront();
            buttonNext.BringToFront();
            buttonPrevious.BringToFront();
            buttonReset.BringToFront();
        }

        private void buttonBigger_Click(object sender, EventArgs e)
        {
            r_Photographer.EnlargePicture();
        }

        private void buttonSmaller_Click(object sender, EventArgs e)
        {
            r_Photographer.ShrinkPicture();
        }

        private void buttonDoubleSize_Click(object sender, EventArgs e)
        {
            PictureBox newPicture = r_Photographer.CreateDoubleSizePictureBox(this.Width, this.Height);
            afterLoadingNewPicture(newPicture);
        }

        private void buttonHalfSize_Click(object sender, EventArgs e)
        {
            PictureBox newPicture = r_Photographer.CreateHalfSizePictureBox(this.Width, this.Height);
            afterLoadingNewPicture(newPicture);
        }

        private void buttonDisappearingPicture_Click(object sender, EventArgs e)
        {
            PictureBox newPicture = r_Photographer.CreateDisappearingPictureBox(this.Width, this.Height);
            afterLoadingNewPicture(newPicture);
        }

        private void buttonBlinkingPicture_Click(object sender, EventArgs e)
        {
            PictureBox newPicture = r_Photographer.CreateBlinkingPictureBox(this.Width, this.Height);
            afterLoadingNewPicture(newPicture);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            r_Photographer.PickNextPicture();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            r_Photographer.PickPreviousPicture();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            r_Photographer.ResetPickedPicture();
        }
    }
}
