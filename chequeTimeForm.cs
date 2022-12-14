using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мебель
{
    public partial class chequeTimeForm : Form
    {
        private FurnitureContext _db = null;
        private string _fileName = null;

        public chequeTimeForm(FurnitureContext db, string fileName)
        {
            this._db = db;
            this._fileName = fileName;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePicker1.Value.Date;
            DateTime end = dateTimePicker2.Value.Date;
            DateTime endOneDayPlus = end.AddDays(1);
            Report report = new Report(_fileName, saveFileDialog);
            report.PrintChequeTime(_db.Cheques.Where(c => c.Date > start && c.Date < endOneDayPlus).ToList(), start, end);
            this.Close();
        }
    }
}
