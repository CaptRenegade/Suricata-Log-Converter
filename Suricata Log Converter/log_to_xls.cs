using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data;
using ClosedXML.Excel;

namespace Suricata_Log_Converter
{
    class log_to_xls
    {

        public void Convert_Log()
        {
            var logfile = string.Empty;

            using (OpenFileDialog OFD = new OpenFileDialog())
            {
                OFD.InitialDirectory = Environment.CurrentDirectory;
                OFD.Filter = "Suricata Log File (*.log)|*.log|All files (*.*)|*.*";
                OFD.FilterIndex = 1;
                OFD.RestoreDirectory = true;


                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    logfile = OFD.FileName;

                    using (SaveFileDialog SFD = new SaveFileDialog())
                    {

                        SFD.InitialDirectory = Environment.CurrentDirectory;
                        SFD.Filter = "Suricata Export File (*.xlsx)|*.xlsx";
                        SFD.FilterIndex = 1;
                        SFD.RestoreDirectory = true;

                        if (SFD.ShowDialog() == DialogResult.OK)
                        {
                            XLWorkbook wb = new XLWorkbook();
                            wb.Worksheets.Add(LogFileRead(logfile), "Suricata Log");
                            wb.SaveAs(SFD.FileName);
                        }
                        else
                        {
                            Application.Exit();
                        }

                    }

                    Application.Exit();
                }
                else
                {
                    Application.Exit();
                }

            }


        }

        //*********REFERENCED FUNCTIONS DEFINITIONS****************
        private DataTable LogFileRead(string file)
        {
            DataTable importTable = new DataTable();
            DataRow row = importTable.NewRow();


            importTable.Columns.Add("DateTime", typeof(string));
            importTable.Columns.Add("GID:SID", typeof(string));
            importTable.Columns.Add("Description", typeof(string));
            importTable.Columns.Add("Classification", typeof(string));
            importTable.Columns.Add("Priority_Code", typeof(string));
            importTable.Columns.Add("Vector", typeof(string));


                    
                        foreach (string line in LogArray(file))
                        {
                            string[] formatteddata = line.Split('[', ']');
 
                            row = importTable.NewRow();

                            row[0] = formatteddata[0];
                            row[1] = formatteddata[3];
                            row[2] = formatteddata[4];
                            row[3] = formatteddata[7];
                            row[4] = formatteddata[9];
                            row[5] = formatteddata[10];

                            importTable.Rows.Add(row);

                          
                        }

            return importTable;
        }

        public Array LogArray(string file)
        {
            List<string> Lines = new List<string>();
            StreamReader sr = File.OpenText(file);
            {
                string line;
                line = sr.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    Lines.Add(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }

            return Lines.ToArray();
        }

    }
}
