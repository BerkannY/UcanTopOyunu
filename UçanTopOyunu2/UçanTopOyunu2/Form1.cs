namespace UçanTopOyunu2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int yerX = 10, yerY = 10, can = 3;
        private void CarpmaOlayı()
        {
            //label2
            if (ball.Top <= label2.Bottom)
                yerY = yerY * -1;

            //Kontrole Çarpma Olayı

            if (ball.Bottom >= kontrol.Top && ball.Left >= kontrol.Left && ball.Right <= kontrol.Right)
                yerY = yerY * -1;

            //sağ tarafa çarpma olayı
            else if (ball.Right >= label4.Left)
                yerX = yerX * -1;
            //sol tarafa çarpma olayı
            else if (ball.Left >= label1.Right)
                yerX = yerX * -1;

        }
        private void YanmaOlayı(Object sender, EventArgs e)
        {
            if (ball.Top >= label4.Bottom)
            {
                if (can > 0)
                {
                    timer1.Stop();
                    can--;
                    MessageBox.Show("Yandınız kalan can >=" + can.ToString());
                    Form1_Load(sender, e);

                }
                if (can == 0)
                {
                    timer1.Stop();
                    MessageBox.Show("Oyun Bitti", "", MessageBoxButtons.OK);
                }

            }
            label3.Text = can.ToString();

        }

        private void Topbasa()
        {
            ball.Location = new Point(394, 294);
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            kontrol.Left = e.X;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Topbasa();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CarpmaOlayı();
            YanmaOlayı(sender, e);
            ball.Location = new Point(ball.Location.X + yerX, ball.Location.Y + yerY);
        }
    }
}