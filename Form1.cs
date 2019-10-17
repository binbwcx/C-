using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            this.listView1.View = View.Details;
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                DirectoryInfo dinfo = new DirectoryInfo(textBox1.Text);
                FileSystemInfo[] fsinfos = dinfo.GetFileSystemInfos();
                foreach (FileSystemInfo fsinfo in fsinfos)
                {
                    if (fsinfo is DirectoryInfo)
                    {
                        DirectoryInfo dirinfo = new DirectoryInfo(fsinfo.FullName);
                        listView1.Items.Add(dirinfo.Name);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(dirinfo.FullName);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(dirinfo.CreationTime.ToShortDateString());


                    }
                    else
                    {
                        FileInfo finfo = new FileInfo(fsinfo.FullName);
                        listView1.Items.Add(finfo.Name);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(finfo.FullName);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(finfo.Length.ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(finfo.CreationTime.ToLongDateString());

                    }
                 
                }
            }
        }
    }
}
