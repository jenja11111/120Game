using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _120Game
{
    public class StarsController
    {
        List<Control> stars = new List<Control>();
        Size[] sizes;
        int starIndex;

        public StarsController() { }

        public StarsController(ref PictureBox star1, ref PictureBox star2, ref PictureBox star3, ref PictureBox star4, ref PictureBox star5, ref PictureBox star6)
        {
            stars.Add(star1);
            stars.Add(star2);
            stars.Add(star3);
            stars.Add(star4);
            stars.Add(star5);
            stars.Add(star6);

            sizes = new Size[stars.Count];
        }

        public async void ZoomStars()
        {
            int T = 0;

            while (T < 2)
            {
                for (int i = 0; i < stars.Count; i++)
                {
                    sizes[i] = stars[i].Size;

                    stars[i].Size = new Size(stars[i].Size.Width + stars[i].Size.Width/10, stars[i].Size.Height + stars[i].Size.Height/10);

                    await Task.Delay(300);

                    stars[i].Size = sizes[i];
                }

                await Task.Delay(100);
                T++;
            }

            T = 0;

            while (T < 1)
            {
                for (int i = 0; i < stars.Count; i++)
                {
                    sizes[i] = stars[i].Size;

                    stars[i].Size = new Size(stars[i].Size.Width + stars[i].Size.Width / 10, stars[i].Size.Height + stars[i].Size.Height / 10);

                    await Task.Delay(500);

                    stars[i].Size = sizes[i];
                }

                await Task.Delay(100);
                T++;
            }

            for (int i = 0; i < stars.Count; i++)
            {              
                sizes[i] = stars[i].Size;

                stars[i].Size = new Size(stars[i].Size.Width + stars[i].Size.Width / 10, stars[i].Size.Height + stars[i].Size.Height / 10);

                await Task.Delay(500);
                if (i == SearchStar(stars.Count-1))
                {
                    starIndex = i;
                    await Task.Delay(300);
                    stars[i].Size = sizes[i];
                    break;
                }

                stars[i].Size = sizes[i];
            }

            FormQuestion frm = new FormQuestion();
            frm.ShowDialog();
        }

        public int SearchStar(int starsCount)
        {
            Random rnd = new Random();
            int star = rnd.Next(0, starsCount);

            return star;
        }
    }
}
