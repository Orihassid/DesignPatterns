using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookLogics.Photographer_Feature
{
    public class PhotographerIterator
    {
        private readonly List<PictureBox> m_PictureBoxList;
        private int m_index;

        public PhotographerIterator(ref List<PictureBox> r_PictureBoxReference)
        {
           m_index = 0;
           m_PictureBoxList = r_PictureBoxReference;
        }


        public void Next()
        {
            if(m_index == m_PictureBoxList.Count - 1)
            {
                m_index = 0;
            }
            else
            {
                m_index++;
            }
        }

        public void Reset()
        {
            m_index = 0;
        }

        public void Previous()
        {
            if(m_index == 0)
            {
                m_index = m_PictureBoxList.Count - 1;
            }
            else
            {
                m_index--;
            }
        }

        public PictureBox GetPictureBox()
        {
            return m_PictureBoxList[m_index];
        }

    }
}
