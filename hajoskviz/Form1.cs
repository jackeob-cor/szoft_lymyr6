namespace hajoskviz
{
    public partial class Form1 : Form
    {
        List<Kérdés> ÖsszesKérdés;
        List<Kérdés> AktuálisKérdések = new List<Kérdés>();
        int MegjelenítettKérdésSzáma = 5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ÖsszesKérdés = KérdésekBeolvasása();

            for (int i = 0; i < 7; i++)
            {
                AktuálisKérdések.Add(ÖsszesKérdés[0]);
                ÖsszesKérdés.RemoveAt(0);
            }

            dataGridView1.DataSource = AktuálisKérdések;

            KérdésMegjelenítése(AktuálisKérdések[MegjelenítettKérdésSzáma]);
        }

        void KérdésMegjelenítése(Kérdés kérdés)
        {
            label1.Text = kérdés.KérdésSzöveg;
            textBox1.Text = kérdés.Válasz1;
            textBox2.Text = kérdés.Válasz2;
            textBox3.Text = kérdés.Válasz3;

            if (string.IsNullOrEmpty(kérdés.URL))
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox1.Load("https://storage.altinum.hu/hajo/" + kérdés.URL);
            }

            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
        }





        List<Kérdés> KérdésekBeolvasása()
        {
            List<Kérdés> kérdések = new();
            StreamReader sr = new StreamReader("hajozasi_szabalyzat_kerdessor_BOM.txt", true);
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine() ?? "n/a";
                string[] tömb = sor.Split("\t");

                if (tömb.Length != 7) continue;

                Kérdés k = new();
                k.KérdésSzöveg = tömb[1].Trim('"');
                k.Válasz1 = tömb[2].Trim('"');
                k.Válasz2 = tömb[3].Trim('"');
                k.Válasz3 = tömb[4].Trim('"');
                k.URL = tömb[5];

                int x = 0;
                int.TryParse(tömb[6], out x);
                k.HelyesVálasz = x;

                kérdések.Add(k);
            }
            sr.Close();
            return kérdések;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MegjelenítettKérdésSzáma++;
            if (MegjelenítettKérdésSzáma == 7)
            {
                MegjelenítettKérdésSzáma = 0;
            }

            KérdésMegjelenítése(AktuálisKérdések[MegjelenítettKérdésSzáma]);
        }



        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Red;
            if (AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálasz == 1)
            { 
                textBox1.BackColor = Color.LightGreen;
                AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálaszokSzáma++;
            }
            else
            {
                AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálaszokSzáma = 0;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Red;
            if (AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálasz == 2)
            {
                textBox2.BackColor = Color.LightGreen;
                AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálaszokSzáma++;
            }
            else
            {
                AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálaszokSzáma = 0;
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.Red;
            if (AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálasz == 3)
            {
                textBox3.BackColor = Color.LightGreen;
                AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálaszokSzáma++;
            }
            else
            {
                AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálaszokSzáma = 0;
            }
        }
    }
}