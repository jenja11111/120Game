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
        List<PictureBox> stars = new List<PictureBox>();
        Size[] sizes;

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
            if (!QuestionsComponent.enableValue[0])
                stars[0].Image = Properties.Resources._1b;
            if(!QuestionsComponent.enableValue[1])
                stars[1].Image = Properties.Resources._2b;
            if (!QuestionsComponent.enableValue[2])
                stars[2].Image = Properties.Resources._3b;
            if (!QuestionsComponent.enableValue[3])
                stars[3].Image = Properties.Resources._4b;
            if (!QuestionsComponent.enableValue[4])
                stars[4].Image = Properties.Resources._5b;
            if (!QuestionsComponent.enableValue[5])
                stars[5].Image = Properties.Resources._6b;

            if (QuestionsComponent.enableValue[0] || QuestionsComponent.enableValue[1] || QuestionsComponent.enableValue[2] || QuestionsComponent.enableValue[3]
                || QuestionsComponent.enableValue[4] || QuestionsComponent.enableValue[5])
            {
                while (T < 2)
                {
                    for (int i = 0; i < stars.Count; i++)
                    {
                        if (QuestionsComponent.enableValue[i])
                        {
                            sizes[i] = stars[i].Size;

                            stars[i].Size = new Size(stars[i].Size.Width + stars[i].Size.Width / 10, stars[i].Size.Height + stars[i].Size.Height / 10);

                            await Task.Delay(300);

                            stars[i].Size = sizes[i];
                        }
                    }

                    await Task.Delay(100);
                    T++;
                }

                T = 0;

                while (T < 1)
                {
                    for (int i = 0; i < stars.Count; i++)
                    {
                        if (QuestionsComponent.enableValue[i])
                        {
                            sizes[i] = stars[i].Size;

                            stars[i].Size = new Size(stars[i].Size.Width + stars[i].Size.Width / 10, stars[i].Size.Height + stars[i].Size.Height / 10);

                            await Task.Delay(500);

                            stars[i].Size = sizes[i];
                        }
                    }

                    await Task.Delay(100);
                    T++;
                }

                int star = SearchStar(stars.Count);

                for (int i = 0; i < stars.Count; i++)
                {
                    if (QuestionsComponent.enableValue[i])
                    {
                        sizes[i] = stars[i].Size;

                        stars[i].Size = new Size(stars[i].Size.Width + stars[i].Size.Width / 10, stars[i].Size.Height + stars[i].Size.Height / 10);

                        await Task.Delay(500);
                        if (i == star)
                        {
                            star++;
                            await Task.Delay(600);
                            stars[i].Size = sizes[i];
                            break;
                        }
                        stars[i].Size = sizes[i];
                    }
                }

                FormQuestion frm = new FormQuestion(star);
                frm.Show();
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("Вопросы закончились! Спасибо за игру!", "Поздравляем!", MessageBoxButtons.OK, MessageBoxIcon.Information))
                    Application.Exit();
            }
        }

        public int SearchStar(int starsCount)
        {
            Random rnd = new Random();
            int star = 0;
            while (true)
            {
                star = rnd.Next(0, starsCount);
                if (QuestionsComponent.enableValue[star])
                    break;
            }

            return star;
        }
    }
}
