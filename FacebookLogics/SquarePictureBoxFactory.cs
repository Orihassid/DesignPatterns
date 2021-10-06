using System;
using System.Windows.Forms;

namespace FacebookLogics
{
    public static class SquarePictureBoxFactory
    {
        public static PictureBox CreateSquarePicture(int i_Size)
        {
            PictureBox newPictureBox = new PictureBox();
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Height = i_Size;
            newPictureBox.Width = i_Size;
            newPictureBox.Visible = true;
            return newPictureBox;
        }

        public static PictureBox CreateSquareDoubleSizePicture(int i_Size)
        {
            PictureBox newPictureBox = new PictureBox();
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Height = i_Size * 2;
            newPictureBox.Width = i_Size * 2;
            newPictureBox.Visible = true;
            return newPictureBox;
        }

        public static PictureBox CreateHalfSizePicture(int i_Size)
        {
            PictureBox newPictureBox = new PictureBox();
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Height = i_Size / 2;
            newPictureBox.Width = i_Size / 2;
            newPictureBox.Visible = true;
            return newPictureBox;
        }

        public static PictureBox CreateBlinkingPicture(int i_Size)
        {
            PictureBox newPictureBox = new PictureBox();
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Height = i_Size;
            newPictureBox.Width = i_Size;
            newPictureBox.MouseEnter += PictureBox_InVisible;
            newPictureBox.MouseLeave += PictureBox_Visible;
            newPictureBox.Visible = true;
            return newPictureBox;
        }

        public static PictureBox CreateDisappearingPicture(int i_Size)
        {
            PictureBox newPictureBox = new PictureBox();
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Height = i_Size;
            newPictureBox.Width = i_Size;
            newPictureBox.MouseEnter += PictureBox_InVisible;
            newPictureBox.Visible = true;
            return newPictureBox;
        }

        private static void PictureBox_InVisible(object sender, EventArgs e)
        {
            if(sender is PictureBox)
            {
                (sender as PictureBox).Visible = false;
            }
        }

        private static void PictureBox_Visible(object sender, EventArgs e)
        {
            if(sender is PictureBox)
            {
                (sender as PictureBox).Visible = true;
            }

        }
    }
}
