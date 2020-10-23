using System.Collections.Generic;


namespace CustomizedDriver
{
    class Driverconf
    {
        public string RobotType { get; set; }
        public List<Drivers> Drivers { get; set; }
    }
    class Drivers
    {
        public bool Mitsubishi { get; set; }
        public bool ElmoComposer { get; set; }
        public bool ElmoApplicationStudioII { get; set; }
        public bool Copley { get; set; }
        public bool MoonsSTConfigurator { get; set; }
        public bool Keyence3000Series { get; set; }
        public bool Keyence5000Series { get; set; }
        public bool Satorius { get; set; }
        public bool MettlerToledo { get; set; }
        public bool Panaterm { get; set; }
        public bool CCD_T_GigeCam { get; set; }
        public bool CCD_T_USB { get; set; }
        public Drivers()
        {
            ElmoApplicationStudioII = false;
            ElmoComposer = false;
            Mitsubishi = false;
            Keyence3000Series = false;
            Keyence5000Series = false;
            Satorius = false;
            Panaterm = false;
            MettlerToledo = false;
            MoonsSTConfigurator = false;
            Copley = false;
            CCD_T_GigeCam = false;
            CCD_T_USB = false;
        }
        public void ASeries()
        {
            Mitsubishi = true;
            CCD_T_USB = true;
        }
        public void BSeries()
        {
            CCD_T_USB = true;
        }
        public void ESeries()
        {
            CCD_T_USB = true;
        }
        public void XL600()
        {
            ElmoApplicationStudioII =true;
            Mitsubishi = true;
            Copley = true;
            MoonsSTConfigurator = true;
            CCD_T_GigeCam = true;
            Keyence3000Series = true;
        }
        public void XL600Dam()
        {
            ElmoApplicationStudioII = true;
            Mitsubishi = true;            
            MoonsSTConfigurator = true;
            CCD_T_GigeCam = true;
            Keyence3000Series = true;
            MettlerToledo = true;
        }
        public void XL600Fill()
        {
            ElmoApplicationStudioII = true;
            Mitsubishi = true;
            MoonsSTConfigurator = true;
            CCD_T_GigeCam = true;
            Keyence3000Series = true;
            MettlerToledo = true;
        }
        public string []FinalList(Drivers dri)
        {
            string []result=new string [12];
            if (dri.Mitsubishi)
                result[0] = "start  Mitsubishi/SN.jpg"+"\r\n"+"start /wait Mitsubishi/MitsubishiEN/setup.exe"+"\r\n"+ "start /wait Mitsubishi/MRConfiguratorSC/setup.exe";
            else
                result[0] = "";
            if (dri.ElmoComposer)
                result[1] = "start /wait ElmoComposer/ElmoComposerSetup.exe";
            else
                result[1] = "";
            if (dri.ElmoApplicationStudioII)
                result[2] = "c:"+"\r\n"+ "cd /Program Files (x86)/SSI_CustomizedDirver_Package" + "\r\n"+"start /wait Elmo_Application_Studio_II/ElmoApplicationStudio.exe";
            else
                result[2] = "";
            if (dri.MoonsSTConfigurator)
                result[3] = "start /wait Moons/STConfigurator.exe";
            else
                result[3] = "";
            if (dri.Panaterm)
                result[4] = "start /wait Panaterm/PANATERM 6.0-64BIT.exe"+"\r\n"+ "start PanatermToChinese/readme.txt";
            else
                result[4] = "";
            if (dri.Copley)
                result[5] = "start /wait Copley/CME8Setup.exe";
            else
                result[5] = "";
            if (dri.Keyence3000Series)
                result[6] = "start /wait Keyence/3000/setup.exe";
            else
                result[6] = "";
            if (dri.Keyence5000Series)
                result[7] = "start /wait Keyence/5000/setup.exe";
            else
                result[7] = "";
            if (dri.Satorius)
                result[8] = "start /wait Sartorius/setup.exe";
            else
                result[8] = "";
            if (dri.MettlerToledo)
                result[9] = "start /wait MettlerToledo/APW-LinkSetup_V2.6.0.exe";
            else
                result[9] = "";
            if (dri.CCD_T_GigeCam)
                result[10] = "start /wait CCD/Gigecam/gigecam.exe";
            else
                result[10] = "";
            if (dri.CCD_T_USB)
                result[11] = "start /wait CCD/USBcam/drvInstaller.exe";
            else
                result[11] = "";

            return result;        
        }
    }
}
