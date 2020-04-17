using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcSoftFace
{
    public partial class FormClass : Form
    {
        public FormClass()
        {
            InitializeComponent();
            show_classes();
        }

        

        private void FormClass_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void new_edit_Click(object sender, EventArgs e)
        {
            update(this.textClassNo.Text.ToString(), this.textClassName.Text.ToString(), this.textClassRecord.Text.ToString());
        }

        private void show_classes()
        {
            listClasses.Items.Clear();
            using (StreamReader sr = File.OpenText("..\\..\\..\\Database\\Class\\Class.csv"))
            {
                string strLine = sr.ReadLine();
                string[] strArray;
                while ((strLine = sr.ReadLine()) != null)
                {
                    strArray = strLine.Split(',');
                    listClasses.Items.Add(strArray[0] + " " + strArray[1]);
                }
            }
        }

        private void update(string newCno, string newCname, string newRecordNum)
        {
            string[] classes;
            string path_class = "..\\..\\..\\Database\\Class\\Class.csv";
            if (!File.Exists(path_class))
            {
                using (StreamWriter sw = File.CreateText(path_class))
                {
                    sw.WriteLine(newCno + ',' + newCname + ',' + newRecordNum);
                }
            }
            try
            {
                int flag = 0;
                classes = File.ReadAllLines(path_class);
                for (int i = 0; i < classes.Length; i++)
                {
                    string Cno = classes[i].Split(',')[0];
                    if (Cno == newCno)
                    {
                        classes[i] = newCno + ',' + newCname + ',' + newRecordNum;
                        flag = 1;
                        break;
                    }
                }
                if (flag == 1)
                {
                    File.WriteAllLines(path_class, classes);
                    show_classes();
                    MessageBox.Show($"Edit success!");
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path_class))
                    {
                        sw.WriteLine(newCno + ',' + newCname + ',' + newRecordNum);
                        MessageBox.Show($"Add success!");
                    }
                    show_classes();
                }
                
            }
            catch (Exception)
            {

            }
        }
    }
}
