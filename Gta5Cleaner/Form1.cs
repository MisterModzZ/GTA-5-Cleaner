using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gta5Cleaner
{
    public partial class Form1 : Form
    {

        public string Toolname = "Mister//ModzZ Gta5 Cleaner";
        public string Version = "1.0";
        public Form1()
        {
            InitializeComponent();
        }

        void LogInfo(string msg)
        {
            string current;
            current = richTextBox1.Text;
            current = current + "\n" + " [INFO] " + msg;
            richTextBox1.Text = current;
        }
        void LogWarning(string msg)
        {
            string current;
            current = richTextBox1.Text;
            current = current + "\n" + " [WARNING] " + msg;
            richTextBox1.Text = current;
        }
        void LogError(string msg)
        {
            string current;
            current = richTextBox1.Text;
            current = current + "\n" + " [ERROR] " + msg;
            richTextBox1.Text = current;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://mistermodzz.com");
        }
                

        private bool IsFileLit(string filename)
        {
            List<string> EpicFiles = new List<string> { "bink2w64.dll", "commandline.txt", "common.rpf", "d3dcompiler_46.dll", "d3dcsx_46.dll", "EOSSDK-Win64-Shipping.dll", "GFSDK_ShadowLib.win64.dll", "GFSDK_TXAA.win64.dll", "GFSDK_TXAA_AlphaResolve.win64.dll", "GPUPerfAPIDX11-x64.dll", "GTA5.exe", "NvPmApi.Core.win64.dll", "PlayGTAV.exe", "version.txt", "x64a.rpf", "x64b.rpf", "x64c.rpf", "x64d.rpf", "x64e.rpf", "x64f.rpf", "x64g.rpf", "x64h.rpf", "x64i.rpf", "x64j.rpf", "x64k.rpf", "x64l.rpf", "x64m.rpf", "x64n.rpf", "x64o.rpf", "x64p.rpf", "x64q.rpf", "x64r.rpf", "x64s.rpf", "x64t.rpf", "x64u.rpf", "x64v.rpf", "x64w.rpf" };
            List<string> SCFiles = new List<string> { "zlib1.dll", "toxmod.dll",  "opusenc.dll", "opus.dll", "libcurl.dll", "fvad.dll", "bink2w64.dll", "common.rpf", "d3dcompiler_46.dll", "d3dcsx_46.dll" , "GFSDK_ShadowLib.win64.dll", "GFSDK_TXAA.win64.dll", "GFSDK_TXAA_AlphaResolve.win64.dll", "GPUPerfAPIDX11-x64.dll", "GTA5.exe", "GTAVLanguageSelect.exe", "GTAVLauncher.exe", "index.bin", "NvPmApi.Core.win64.dll", "PlayGTAV.exe", "uninstall.exe", "version.txt", "x64a.rpf", "x64b.rpf", "x64c.rpf", "x64d.rpf", "x64e.rpf", "x64f.rpf", "x64g.rpf", "x64h.rpf", "x64i.rpf", "x64j.rpf", "x64k.rpf", "x64l.rpf", "x64m.rpf", "x64n.rpf", "x64o.rpf", "x64p.rpf", "x64q.rpf", "x64r.rpf", "x64s.rpf", "x64t.rpf", "x64u.rpf", "x64v.rpf", "x64w.rpf"};
            List<string> SteamFiles = new List<string> { "bink2w64.dll", "common.rpf", "d3dcompiler_46.dll", "d3dcsx_46.dll", "GFSDK_ShadowLib.win64.dll", "GFSDK_TXAA.win64.dll", "GFSDK_TXAA_AlphaResolve.win64.dll", "GPUPerfAPIDX11-x64.dll", "GTA5.exe", "GTAVLanguageSelect.exe", "GTAVLauncher.exe", "installscript.vdf", "NvPmApi.Core.win64.dll", "PlayGTAV.exe", "steam_api64.dll", "version.txt", "x64a.rpf", "x64b.rpf", "x64c.rpf", "x64d.rpf", "x64e.rpf", "x64f.rpf", "x64g.rpf", "x64h.rpf", "x64i.rpf", "x64j.rpf", "x64k.rpf", "x64l.rpf", "x64m.rpf", "x64n.rpf", "x64o.rpf", "x64p.rpf", "x64q.rpf", "x64r.rpf", "x64s.rpf", "x64t.rpf", "x64u.rpf", "x64v.rpf", "x64w.rpf"};
            if (Epicversion)
            {
                if (EpicFiles.Contains(filename))
                {
                    return true;
                }
            }
            if (Scversion)
            {
                if (SCFiles.Contains(filename))
                {
                    return true;
                }
            }
            if (Steamversion)
            {
                if (SteamFiles.Contains(filename))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsFolderLit(string Foldername)
        {
            List<string> SCFolders = new List<string> { "ReadMe", "Redistributables", "update", "x64" };
            List<string> EpicFolders = new List<string> { ".egstore", "ReadMe", "Redistributables", "update", "x64" };
            List<string> SteamFolders = new List<string> { "Installers", "update", "x64" };

            if (Epicversion)
            {
                if (EpicFolders.Contains(Foldername))
                {
                    return true;
                }
            }
            if (Scversion)
            {
                if (SCFolders.Contains(Foldername))
                {
                    return true;
                }
            }
            if (Steamversion)
            {
                if (SteamFolders.Contains(Foldername))
                {
                    return true;
                }
            }
            return false; 
        }

        public int Filesremoved = 0;
        public int Foldersremoved = 0;
        public bool Epicversion = false;
        public bool Scversion = false;
        public bool Steamversion = false;
        private void UninstallMods(string gta5path)
        {
            if (Directory.Exists(gta5path)) 
            {
                if (File.Exists(gta5path + "/" + "EOSSDK-Win64-Shipping.dll"))
                {
                    Epicversion = true;
                    LogInfo("Using EpicGames Version of Gta5");
                }
                else if (File.Exists(gta5path + "/" + "steam_api64.dll"))
                {
                    Steamversion = true;
                    LogInfo("Using Steam Version of Gta5");
                }
                else {
                    Scversion = true;
                    LogInfo("Using SocialClub Version of Gta5");
                }

                System.IO.DirectoryInfo di = new DirectoryInfo(gta5path);
                foreach (FileInfo file in di.GetFiles())
                {
                    var name = file.Name;
                    if(!IsFileLit(name))
                    { 
                        file.Delete();
                        Filesremoved++;
                        LogInfo("Removed file: " + name);
                    }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    var name = dir.Name;
                    if (!IsFolderLit(name))
                    {
                        dir.Delete(true);
                        Foldersremoved++;
                        LogInfo("Removed folder: " + name);
                    }
                    
                }              
                LogInfo("Removed: " + Filesremoved+ " files");
                LogInfo("Removed: " + Foldersremoved + " folders");
                LogInfo("DONE");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool gta_folder_found = false;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string path;
            string Gta5Path = "";
            string Appdata = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string textfilepath = Appdata + "/Terror/GTAV_PATH.txt";
            if (File.Exists(Appdata + "/Terror/GTAV_PATH.txt"))
            {
                try
                {
                    List<string> Lines = new List<string>();
                    Lines = File.ReadAllLines(textfilepath).ToList();
                    foreach (String Line in Lines)
                    {
                        Gta5Path = Line;  // um das Gta5 verzeichnis aus der datei zu lesen 
                    }
                    if (File.Exists(Gta5Path + "/" + "GTA5.exe"))
                    {
                        gta_folder_found = true;
                        fbd.SelectedPath = Gta5Path;
                        var pathfile = File.OpenRead(textfilepath);
                        pathfile.Close();
                        LogInfo("Gtav Path loaded successfully");
                    }
                    if (!File.Exists(Gta5Path + "/" + "GTA5.exe"))
                    {
                        MessageBox.Show("[ERROR] Your Game Directory changed!", Toolname);
                        LogError("Your Game Directory seems to have changed!");
                        File.Delete(textfilepath);
                        LogInfo("removed old GTAV_PATH.txt");
                        LogInfo("Please select your gta5 path again!");
                    }
                }
                catch
                {
                    LogError("Something went wrong while trying to load the gta5 path!");
                    LogInfo("Please select the gta5 path manually!");
                    File.Delete(textfilepath);
                }
            }
            while (!gta_folder_found)
            {
                MessageBox.Show("Select your GTA V Folder please!", Toolname);
                DialogResult res = fbd.ShowDialog();
                if (res == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    if (File.Exists(fbd.SelectedPath + "/" + "GTA5.exe"))
                    {
                        if (!File.Exists(textfilepath))
                        {
                            var myFile = File.Create(textfilepath);
                            myFile.Close();
                        }
                        if (File.Exists(textfilepath))
                        {
                            List<string> Lines = new List<string>();
                            Lines = File.ReadAllLines(textfilepath).ToList();
                            foreach (String Line in Lines)
                            {
                                //Console.WriteLine(Line);
                            }
                            Lines.Clear();
                            Lines.Add(fbd.SelectedPath);
                            File.WriteAllLines(textfilepath, Lines);
                            MessageBox.Show("[INFO]Gta5 Path Saved", Toolname);
                        }
                        gta_folder_found = true;
                        path = fbd.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("[ERROR] that`s not the GTA Folder. Please try again!", Toolname);
                        gta_folder_found = false;
                    }
                }
                else
                {
                    gta_folder_found = false;
                }
            }
            if (gta_folder_found)  // tamam wir habe gtav pfad
            {
                //UNINSTALL ALL THE MODS FROM THE PATH: fbd.SelectedPath
                UninstallMods(fbd.SelectedPath);

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private Point MouseDownLocation; bool move = false;
        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
                //this.SetDesktopLocation(MousePosition.X - mox, MousePosition.Y - moy);
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
                //this.SetDesktopLocation(MousePosition.X - mox, MousePosition.Y - moy);
            }
        }
        private bool Forum_State = false;
        private bool Ping_Forum()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://mistermodzzforum.space/");
                request.Timeout = 3000;
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    Forum_State = true;
                    return true;
                }
            }
            catch
            {
                LogError("Forum Site is currently offline / no connection possible");
                Forum_State = false;
                return false;
            }
        }
        private bool mistermodzzsitestate = false;
        private bool Ping_MisterModzZ()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://mistermodzz.com/");
                request.Timeout = 3000;
                request.AllowAutoRedirect = false;
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    mistermodzzsitestate = true;
                }
            }
            catch
            {
                mistermodzzsitestate = false;
                LogError("MisterModzZ.com is offline /no connection possible");
            }
            return mistermodzzsitestate;
        }
        private void Tool_Versionchecker()
        {
            // INSTALLER VERSION CHECK
            string url = "";
            WebClient client = new WebClient();
            if (Forum_State)
            {
                url = "https://mistermodzzforum.space/authserver/Gta5cleaner.php/";
                byte[] html = client.DownloadData(url);
                UTF8Encoding utf = new UTF8Encoding();
                string mystring = utf.GetString(html);
                if (mystring != Version)
                {
                    var msg = MessageBox.Show("There is a Update for this Tool Avalible! Do you want to Download it now? ", Toolname, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    LogInfo("There is a Update for this Tool Avalible");
                    LogInfo("The latest version of this Tool is: " + mystring);
                    if (msg == DialogResult.Yes)
                    {
                        Process.Start("https://mistermodzz.com/gta5-mods-uninstaller/", "Mister//ModzZ Multi Installer");
                    }
                }
            }
            else
            {
                LogInfo("Version check skipped (Server connection lost)");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Ping_Forum();
            if (Forum_State) { Tool_Versionchecker(); }
            string Appdata = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string terrorpath = Appdata + "/Terror";
            if (!Directory.Exists(terrorpath))
            {
                Directory.CreateDirectory(terrorpath);
            }
            //MessageBox.Show("Warning this is only tested after 1.60 every newer version could include new files that this tool doesnt know so it will delete them", Toolname);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            string path;
            string Gta5Path = "";
            bool gta_folder_found = false;
            string Appdata = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string textfilepath = Appdata + "/Terror/GTAV_PATH.txt"; string terrorpath = Appdata + "/Terror";
            if (File.Exists(Appdata + "/Terror/GTAV_PATH.txt"))
            {
                File.Delete(textfilepath);
                LogInfo("removed old safed Gta5 Folder");
            }
            while (!gta_folder_found)
            {
                MessageBox.Show("Select your GTA V Folder please!", Toolname);
                DialogResult res = fbd.ShowDialog();
                if (res == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                {
                    if (File.Exists(fbd.SelectedPath + "/" + "GTA5.exe"))
                    {
                        if (!Directory.Exists(terrorpath))
                        {
                            Directory.CreateDirectory(terrorpath);
                        }
                        if (!File.Exists(textfilepath))
                        {
                            var myFile = File.Create(textfilepath);
                            myFile.Close();
                        }
                        if (File.Exists(textfilepath))
                        {
                            List<string> Lines = new List<string>();
                            Lines = File.ReadAllLines(textfilepath).ToList();
                            foreach (String Line in Lines)
                            {
                                //Console.WriteLine(Line);
                            }
                            Lines.Clear();
                            Lines.Add(fbd.SelectedPath);
                            File.WriteAllLines(textfilepath, Lines);
                            MessageBox.Show("[INFO]Gta5 Path Saved", Toolname);
                        }
                        gta_folder_found = true;
                        path = fbd.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("[ERROR] that`s not the GTA Folder. Please try again!", Toolname);
                        gta_folder_found = false;
                    }
                }
                else
                {
                    gta_folder_found = false;
                }
            }

        }
    }
}
