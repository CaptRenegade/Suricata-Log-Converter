using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Suricata_Log_Converter
{
    public partial class frmConvert : Form
    {
        public frmConvert()
        {
            InitializeComponent();
        }

        private void frmConvert_Load(object sender, EventArgs e)
        {
            log_to_xls convert_log_to_xls = new log_to_xls();

            convert_log_to_xls.Convert_Log();
        }
    }
}
