using System;
using System.IO;
using System.Windows.Forms;

namespace CustomizedDriver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string InstallList1, InstallList2;
        private const string path = @".\AutoDriver.bat";
        private const string batTitle = "@echo off" + "\r\n" + "@mode con lines=40 cols=75" + "\r\n" + "color 02"+"\r\n"+ "title           Driver AutoInstall"+"\r\n"+ "echo."+"\r\n"+ "echo           Auto Install..." + "\r\n"+ "echo."+"\r\n";
        private string Finallist;
        //private const string password = "84746799";
       
        private void Form1_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("Check the Items which you need to install.");
            CenterToScreen();
        }

        private void DriveSoftwareListCheck()
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                string s = "";
                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    s = s + "Install Item " + (x + 1).ToString() + " = " + checkedListBox1.CheckedItems[x].ToString() + "\n";
                }
                InstallList1 = s;
            }
            else
            {
                InstallList1 = "Null";
            }
        }

        private void DeviceDriverListCheck()
        {
            if (checkedListBox2.CheckedItems.Count != 0)
            {
                string s = "";
                for (int x = 0; x < checkedListBox2.CheckedItems.Count; x++)
                {
                    s = s + "Install Item " + (x + 1).ToString() + " = " + checkedListBox2.CheckedItems[x].ToString() + "\n";
                }
                InstallList2 = s;
            }
            else
            {
                InstallList2 = "Null";
            }
        }

        private void DeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Drivers drivers = new Drivers();
            string N = comboBox1.SelectedItem.ToString();
            switch (N)
            {
                case "A Series":
                    drivers.ASeries();
                    break;
                case "B Series":
                    drivers.BSeries();
                    break;
                case "E Series":
                    drivers.ESeries();
                    break;
                case "XL600":
                    drivers.XL600();
                    break;
                case "XL600_DAM":
                    drivers.XL600Dam();
                    break;
                case "XL600_FILL":
                    drivers.XL600Fill();
                    break;
                default:
                    break;
            }
            FreshComboBox(drivers);
            MessageBox.Show("Choose "+N+" setting done!");
        }

        private void FreshComboBox(Drivers drivers)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
            for (int i = 0; i < checkedListBox2.Items.Count; i++)
            {
                checkedListBox2.SetItemCheckState(i, CheckState.Unchecked);
            }
            checkedListBox1.SetItemChecked(0,drivers.Mitsubishi);
            checkedListBox1.SetItemChecked(1, drivers.ElmoComposer);
            checkedListBox1.SetItemChecked(2, drivers.ElmoApplicationStudioII);
            checkedListBox1.SetItemChecked(3, drivers.MoonsSTConfigurator);
            checkedListBox1.SetItemChecked(4, drivers.Panaterm);
            checkedListBox1.SetItemChecked(5, drivers.Copley);
            checkedListBox2.SetItemChecked(0, drivers.Keyence3000Series);
            checkedListBox2.SetItemChecked(1, drivers.Keyence5000Series);
            checkedListBox2.SetItemChecked(2, drivers.Satorius);
            checkedListBox2.SetItemChecked(3, drivers.MettlerToledo);
            checkedListBox2.SetItemChecked(4, drivers.CCD_T_GigeCam);
            checkedListBox2.SetItemChecked(5, drivers.CCD_T_USB);
        }

        private void FreshDriverClass()
        {
            Finallist = "";
            Drivers d = new Drivers
            {
                Mitsubishi = checkedListBox1.GetItemChecked(0),
                ElmoComposer = checkedListBox1.GetItemChecked(1),
                ElmoApplicationStudioII = checkedListBox1.GetItemChecked(2),
                MoonsSTConfigurator = checkedListBox1.GetItemChecked(3),
                Panaterm = checkedListBox1.GetItemChecked(4),
                Copley = checkedListBox1.GetItemChecked(5),
                Keyence3000Series = checkedListBox2.GetItemChecked(0),
                Keyence5000Series = checkedListBox2.GetItemChecked(1),
                Satorius = checkedListBox2.GetItemChecked(2),
                MettlerToledo = checkedListBox2.GetItemChecked(3),
                CCD_T_GigeCam = checkedListBox2.GetItemChecked(4),
                CCD_T_USB = checkedListBox2.GetItemChecked(5)
            };
            string[] final = new string[12];
            final = d.FinalList(d);
            for (int loop = 0; loop < 12; loop++)
            {
                if(final[loop]!="")
                Finallist += final[loop]+"\r\n"; 
            }
           // MessageBox.Show(Finallist);           
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            DriveSoftwareListCheck();
            DeviceDriverListCheck();
            FreshDriverClass();
            DialogResult DELresult = MessageBox.Show("Click" + "< " + "是" + " >" + "Install" + "\r" + "Click" + "< " + "否" + " >" + "Cancel", "Caution!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (DELresult == DialogResult.Yes)
            {
                MessageBox.Show("Drive Software--------"+"\r\n"+InstallList1 +"\r\n"+ "Device Driver----------"+"\r\n" + InstallList2);
                File.WriteAllText(path, batTitle + "\r\n" + Finallist);
                System.Diagnostics.Process.Start("AutoDriver.bat");
                this.Close();
            }                     
        }
    }  
}
