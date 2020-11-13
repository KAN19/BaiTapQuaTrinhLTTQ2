using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThemLaBai
{
   
    public partial class AddCard : Form
    {
        CreateCard createCard;

        int randomCacChat;
        int randomCacSo;
        bool isCreatedCard = false; 
        public AddCard()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear(); 
            randomCacChat = this.RandomCacChat();
            randomCacSo = this.RandomCacConSo();
            createCard = new CreateCard(this.Width, this.Height, randomCacChat, randomCacSo);
            this.Controls.Add(createCard);
            this.Controls.Add(button1);
            isCreatedCard = true; 
        }

        private void AddCard_Resize(object sender, EventArgs e)
        {
            if (isCreatedCard == true)
            {
                this.Controls.Clear();

                CreateCard newcreateCard = new CreateCard(this.Width, this.Height);
                this.Controls.Add(newcreateCard);
                this.Controls.Add(button1);
            }
        }

        public int RandomCacChat()
        {
            Random randomCacChat = new Random();
            return randomCacChat.Next(1, 4);
        }
        public int RandomCacConSo()
        {
            Random random = new Random();
            return random.Next(1, 13);
        }
    }



    public partial class CreateCard : UserControl
    {
        int g_widthForm; 
        int g_heightForm;

        int g_widthCard, g_heightCard, g_xPosCard, g_yPosCard;
       
        int g_widthChat, g_heightChat, g_xPosChat, g_yPosChat;

        static int g_randomChat;
        static int g_randomCacSo; 

        //string pathClubs = @"D:\Visual Studio Projects\LTTQQuaTrinh2\BaiTapQuaTrinhLTTQ2\ThemLaBai\clubs.png";
        string pathClubs = @"D:\Visual Studio Projects\LTTQQuaTrinh2\BaiTapQuaTrinhLTTQ2\ThemLaBai\clubs.png";
        string pathHeart = @"D:\Visual Studio Projects\LTTQQuaTrinh2\BaiTapQuaTrinhLTTQ2\ThemLaBai\hearts.png";
        string pathShades = @"D:\Visual Studio Projects\LTTQQuaTrinh2\BaiTapQuaTrinhLTTQ2\ThemLaBai\spades.png";
        string pathDiamonds = @"D:\Visual Studio Projects\LTTQQuaTrinh2\BaiTapQuaTrinhLTTQ2\ThemLaBai\diamonds.png";

        public CreateCard(int width, int height, int randomChat, int randomSo)
        {
            g_widthForm = width;
            g_heightForm = height;

            //He so width height cua form so voi la bai
            double hesoHeight = 4.5 / 7;

            //Lay ti le size card so voi form
            g_heightCard = (int)((double)height * hesoHeight);
            g_widthCard = (int)(0.67 * g_heightCard);

            // Lay toa do card so voi form
            g_xPosCard = g_widthForm / 2 - g_widthCard / 2;
            g_yPosCard = g_heightForm / 2 - g_heightCard / 2;
           
            //Lay ti le chất bài so voi card
            g_widthChat = (int)(0.2 * (double)g_widthCard);
            g_heightChat = (int)(0.2 * (double)g_heightCard);

            g_xPosChat = g_widthCard / 2 - g_widthChat / 2;
            g_yPosChat = g_heightCard / 2 - g_heightChat / 2;

            g_randomChat = randomChat;
            g_randomCacSo = randomSo; 

            this.Location = new System.Drawing.Point(g_xPosCard, g_yPosCard );
            this.Size = new System.Drawing.Size(g_widthCard, g_heightCard);
        }

        public CreateCard(int width, int height)
        {
            g_widthForm = width;
            g_heightForm = height;

            //He so width height cua form so voi la bai
            double hesoHeight = 4.5 / 7;

            //Lay ti le form so voi la bai
            g_heightCard = (int)((double)height * hesoHeight);
            g_widthCard = (int)(0.67 * g_heightCard);

            g_xPosCard = g_widthForm / 2 - g_widthCard / 2;
            g_yPosCard = g_heightForm / 2 - g_heightCard / 2;

            g_widthChat = (int)(0.2 * (double)g_widthCard);
            g_heightChat = (int)(0.2 * (double)g_heightCard);

            g_xPosChat = g_widthCard / 2 - g_widthChat / 2;
            g_yPosChat = g_heightCard / 2 - g_heightChat / 2;

            this.Location = new System.Drawing.Point(g_xPosCard, g_yPosCard);
            this.Size = new System.Drawing.Size(g_widthCard, g_heightCard);
        }

       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.White);

            Color colorConSo = Color.Black; 
   
            DrawRoundedRectangle(g, pen, 0, 0, g_widthCard, g_heightCard, 15, 15);

            switch (g_randomChat)
            {
                //Chat co
                case 1:
                    DrawImagePointF(e, pathHeart, g_xPosChat, g_yPosChat, g_widthChat, g_heightChat);
                    colorConSo = Color.Red;
                    break;
                case 2:
                    DrawImagePointF(e, pathDiamonds, g_xPosChat, g_yPosChat, g_widthChat, g_heightChat);
                    colorConSo = Color.Red;
                    break; 
                case 3:
                    DrawImagePointF(e, pathClubs, g_xPosChat, g_yPosChat, g_widthChat, g_heightChat);
                    colorConSo = Color.Black;
                    break; 
                case 4:
                    DrawImagePointF(e, pathShades, g_xPosChat, g_yPosChat, g_widthChat, g_heightChat);
                    colorConSo = Color.Black;
                    break;
                default:
                    break;
            }

            switch (g_randomCacSo)
            {
                case 1:
                    DrawString(e, "A", g_widthChat, g_widthCard, g_heightCard, colorConSo);
                    break;
                case 11:
                    DrawString(e, "J", g_widthChat, g_widthCard, g_heightCard, colorConSo);
                    break;
                case 12:
                    DrawString(e, "Q", g_widthChat, g_widthCard, g_heightCard, colorConSo);
                    break;
                case 13:
                    DrawString(e, "K", g_widthChat, g_widthCard, g_heightCard, colorConSo);
                    break;
                default:
                    DrawString(e, g_randomCacSo.ToString(), g_widthChat, g_widthCard, g_heightCard, colorConSo);
                    break;
            }

           

        }

        private void DrawRoundedRectangle(Graphics g, Pen p, int x, int y, int w, int h, int rx, int ry)
        {
            System.Drawing.Drawing2D.GraphicsPath path
              = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x, y, rx + rx, ry + ry, 180, 90);
            path.AddLine(x + rx, y, x + w - rx, y);
            path.AddArc(x + w - 2 * rx, y, 2 * rx, 2 * ry, 270, 90);
            path.AddLine(x + w, y + ry, x + w, y + h - ry);
            path.AddArc(x + w - 2 * rx, y + h - 2 * ry, rx + rx, ry + ry, 0, 91);
            path.AddLine(x + rx, y + h, x + w - rx, y + h);
            path.AddArc(x, y + h - 2 * ry, 2 * rx, 2 * ry, 90, 91);
            path.CloseFigure();
            g.DrawPath(p, path);
            g.FillPath(Brushes.White, path);
        }

        private void DrawImagePointF(PaintEventArgs e, string pathSuit, int posX, int posY, int width, int height)
        {
            Graphics g = e.Graphics;
            // Create image.
            Bitmap bitmap = new Bitmap(pathSuit);
            //g.DrawImage(bitmap, 10, 10, posX, posY);
            g.DrawImage(bitmap, posX, posY, width, height);
        }

        public void DrawString(PaintEventArgs e, string tenQuanBai, int size, int posX, int posY, Color MauChu)
        {
            System.Drawing.Graphics formGraphics = e.Graphics;
            string drawString = tenQuanBai;

            int fontResize = (int)(size * 0.5); 
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", fontResize);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(MauChu);
          
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();

            //Quan bai goc trai
            int rePosX1 = (int)(posX * 0.05);
            int rePosY1 = (int)(posY * 0.05);
            formGraphics.DrawString(drawString, drawFont, drawBrush, rePosX1, rePosY1, drawFormat);

            //Quan bai goc phai (1.33 la pt to pixel
            int rePosX2 = (int)(g_widthCard - rePosX1 - fontResize*1.33);
            int rePosY2 = (int)(g_heightCard - rePosY1 - fontResize*1.33); 

            //Do so 10 2 kytu nen tru them ti xiu :<
            if (tenQuanBai == "10")
            {
                rePosX2 = (int)(g_widthCard - rePosX1 - fontResize * 2.2);
            }

            formGraphics.DrawString(drawString, drawFont, drawBrush, rePosX2, rePosY2, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            formGraphics.Dispose();
        }

        
    }

}
