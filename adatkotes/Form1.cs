using CsvHelper;
using System.ComponentModel;
using System.Globalization;

namespace adatkotes
{


    public partial class Form1 : Form
    {
        BindingList<CountryData> countryList = new();



        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("countries.csv");
            var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
            var tömb = csv.GetRecords<CountryData>();

            foreach (var item in tömb)
            {
                countryList.Add(item);
            }
            // sr.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            countryDataBindingSource.DataSource = countryList;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            FormEditCountry fec = new FormEditCountry();
            fec.EditedCountryData = countryDataBindingSource.Current as CountryData;

            fec.Show();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog()== DialogResult.OK)
            {
                try
            {
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    var csv = new CsvWriter(sw, CultureInfo.InvariantCulture);
                    csv.WriteRecords(countryList);
                    sw.Close();
            }
            
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }
            
        }
    }
}