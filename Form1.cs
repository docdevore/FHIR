using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hl7.Fhir;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;

namespace FHIR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var endpoint = new Uri("https://api-v5-stu3.hspconsortium.org/MX1STU3/open");
            var client = new FhirClient(endpoint);

            var query = new string[] { "name=James" };
            var bundle = client.Search("Patient", query);

            button1.Text = "Got " + bundle.Entry.Count() + " records!";
            label1.Text = "";
            foreach (var entry in bundle.Entry)
            {
                Patient p = (Patient)entry.Resource;
                label1.Text = label1.Text + p.Id + " " + p.Name.First().Text + "\r\n";
            }
        }
    }
}
