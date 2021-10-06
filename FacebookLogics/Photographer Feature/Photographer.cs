using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookLogics.Photographer_Feature;
using FacebookWrapper.ObjectModel;

namespace FacebookLogics
{
    public class Photographer
    {
        private PictureBox m_PictureBoxPickedPicture;
        private Point m_NewPictureLocation;
        private readonly Random r_RandomNumber;
        private readonly FacebookObjectCollection<Photo> r_UserPhotoList;
        private readonly int r_Size;
        private int m_DistanceBetweenShelfPhotos;
        private readonly ePhotoType r_PhotoType;
        private int m_PhotoIndex;
        private List<PictureBox> m_PictureBoxList;
        private readonly PhotographerIterator r_Iterator;
        private readonly int r_SizeToChange;

        public enum ePhotoType
        {
            Collage = 1,
            Shelf
        }

        public Photographer(FacebookObjectCollection<Photo> io_UserPhotoList, ePhotoType i_PhotoType)
        {
            m_PictureBoxList = new List<PictureBox>();
            m_PhotoIndex = 0;
            Point newPictureLocation = Point.Empty;
            r_RandomNumber = new Random(0);
            r_UserPhotoList = io_UserPhotoList;
            r_Size = 200;
            m_DistanceBetweenShelfPhotos = r_Size;
            r_PhotoType = i_PhotoType;
            r_Iterator = new PhotographerIterator(ref m_PictureBoxList);
            r_SizeToChange = 10;
        }

        public PictureBox CreateSquarePictureBox(int i_Width, int i_Height)
        {
            unmarkPicture();
            m_PictureBoxPickedPicture = SquarePictureBoxFactory.CreateSquarePicture(r_Size);
            markPickedPicture();
            m_DistanceBetweenShelfPhotos = r_Size;
            loadPicture(i_Width, i_Height);
            return m_PictureBoxPickedPicture;
        }

        public PictureBox CreateDoubleSizePictureBox(int i_Width, int i_Height)
        {
            unmarkPicture();
            m_PictureBoxPickedPicture = SquarePictureBoxFactory.CreateSquareDoubleSizePicture(r_Size);
            markPickedPicture();
            m_DistanceBetweenShelfPhotos = r_Size * 2;
            loadPicture(i_Width, i_Height);
            return m_PictureBoxPickedPicture;
        }

        public PictureBox CreateHalfSizePictureBox(int i_Width, int i_Height)
        {
            unmarkPicture();
            m_PictureBoxPickedPicture = SquarePictureBoxFactory.CreateHalfSizePicture(r_Size);
            markPickedPicture();
            m_DistanceBetweenShelfPhotos = r_Size / 2;
            loadPicture(i_Width, i_Height);
            return m_PictureBoxPickedPicture;
        }

        public PictureBox CreateBlinkingPictureBox(int i_Width, int i_Height)
        {
            unmarkPicture();
            m_PictureBoxPickedPicture = SquarePictureBoxFactory.CreateBlinkingPicture(r_Size);
            markPickedPicture();
            m_DistanceBetweenShelfPhotos = r_Size;
            loadPicture(i_Width, i_Height);
            return m_PictureBoxPickedPicture;
        }

        public PictureBox CreateDisappearingPictureBox(int i_Width, int i_Height)
        {
            unmarkPicture();
            m_PictureBoxPickedPicture = SquarePictureBoxFactory.CreateDisappearingPicture(r_Size);
            markPickedPicture();
            m_DistanceBetweenShelfPhotos = r_Size;
            loadPicture(i_Width, i_Height);
            return m_PictureBoxPickedPicture;
        }

        public Photo CurrentImage()
        {
            if(m_PhotoIndex == r_UserPhotoList.Count)
            {
                m_PhotoIndex = 0;
            }

            return r_UserPhotoList[m_PhotoIndex];
        }

        private void loadPicture(int i_Width, int i_Height)
        {
            if (r_UserPhotoList.Count > 0)
            {
                if (m_PhotoIndex == r_UserPhotoList.Count)
                {
                    m_PhotoIndex = 0;
                }

                m_PictureBoxPickedPicture.Image = r_UserPhotoList[m_PhotoIndex].ImageNormal;

                m_PictureBoxList.Add(m_PictureBoxPickedPicture);

                m_PhotoIndex++;

                changePictureStateByType(i_Width, i_Height);
            }
            else
            {
                m_PictureBoxPickedPicture.Image = Resource1.karpada;
                MessageBox.Show("No pictures to fetch");
            }
        }

        private void changePictureStateByType(int i_Width, int i_Height)
        {
            if(r_PhotoType == ePhotoType.Collage)
            {
                changeStateByCollage(i_Width, i_Height);
            }
            else if(r_PhotoType == ePhotoType.Shelf)
            {
                changeStateByShelf(i_Width, i_Height);
            }
        }

        private void changeStateByCollage(int i_Width, int i_Height)
        {
            m_NewPictureLocation.X = r_RandomNumber.Next(0, i_Width - r_Size);
            m_NewPictureLocation.Y = r_RandomNumber.Next(0, i_Height - r_Size);
            if (r_PhotoType == ePhotoType.Collage)
            {
                m_PictureBoxPickedPicture.Location = m_NewPictureLocation;
            }
        }

        private void changeStateByShelf(int i_Width, int i_Height)
        {
            m_PictureBoxPickedPicture.Location = m_NewPictureLocation;
            m_NewPictureLocation.X += m_DistanceBetweenShelfPhotos;
            if (m_NewPictureLocation.X >= i_Width)
            {
                m_NewPictureLocation.X = 0;
                m_NewPictureLocation.Y += m_DistanceBetweenShelfPhotos ;
            }
        }

        public PhotographerIterator GetEnumerator()
        {
            return new PhotographerIterator(ref m_PictureBoxList);
        }

        public void PickNextPicture()
        {
            unmarkPicture();
            r_Iterator.Next();
            m_PictureBoxPickedPicture = r_Iterator.GetPictureBox();
            markPickedPicture();
        }

        public void PickPreviousPicture()
        {
            unmarkPicture();
            r_Iterator.Previous();
            m_PictureBoxPickedPicture = r_Iterator.GetPictureBox();
            markPickedPicture();
        }

        public void ResetPickedPicture()
        {
            unmarkPicture();
            r_Iterator.Reset();
            m_PictureBoxPickedPicture = r_Iterator.GetPictureBox();
            markPickedPicture();
        }

        private void markPickedPicture()
        {
            if(m_PictureBoxPickedPicture != null)
            {
                m_PictureBoxPickedPicture.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void unmarkPicture()
        {
            if(m_PictureBoxPickedPicture != null)
            {
                m_PictureBoxPickedPicture.BorderStyle = BorderStyle.None;
            }
        }

        public void EnlargePicture()
        {
            if (m_PictureBoxPickedPicture != null)
            {
                m_PictureBoxPickedPicture.Width += r_SizeToChange;
                m_PictureBoxPickedPicture.Height += r_SizeToChange;
            }
        }

        public void ShrinkPicture()
        {
            if (m_PictureBoxPickedPicture != null)
            {
                m_PictureBoxPickedPicture.Width -= r_SizeToChange;
                m_PictureBoxPickedPicture.Height -= r_SizeToChange;
            }
        }

    }
}
