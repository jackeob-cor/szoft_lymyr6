namespace VIllogoGOmb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         //    Button b = new Button();
         //   Controls.Add(b);
         //   b.Left = ClientRectangle.Width / 2 - b.Width/2;
         //   b.Top = ClientRectangle.Height / 2 - b.Height/2;

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Button b = new VIllogoGomb();
                    Controls.Add(b);
                    b.Width = 20;
                    b.Height = 20;
                    b.Left = 20 * i;
                    b.Top = 20*j;

                }
                

            }


        }
    }
}