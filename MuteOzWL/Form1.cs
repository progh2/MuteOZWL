using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;


namespace RegistryKeyTest
{
    public partial class Form1 : Form
    {
        const string REG_ADDRESS = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers";
        const string KEY_32 = @"C:\Program Files\FORCS\OZWebLauncher\OZWLBridge.exe";
        const string KEY_64 = @"C:\Program Files (x86)\Forcs\OZWebLauncher\OZWLBridge.exe";
        string KEY;
        const string KEY_VALUE = @"~ RUNASADMIN";
        RegistryKey reg;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(Environment.Is64BitProcess == true)
            {
                KEY = KEY_64;
            }
            else
            {
                KEY = KEY_32;
            }
            getStatus();
        }

        private void getStatus()
        {
            reg = Registry.LocalMachine.CreateSubKey(REG_ADDRESS);
            string key_value = Convert.ToString(reg.GetValue(KEY, ""));
            
            if (reg.ValueCount > 0 && key_value == KEY_VALUE)
            {
                toolStripStatusLabel2.Text = "알림 끄기가 적용되어 있습니다";
                btnMuteOn.Enabled = false;
                btnMuteOff.Enabled = true;
            }
            else
            {
                toolStripStatusLabel2.Text = "알림 끄기가 적용되어있지 않습니다";
                btnMuteOn.Enabled = true;
                btnMuteOff.Enabled = false;
            }

            reg.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reg = Registry.LocalMachine.CreateSubKey(REG_ADDRESS);
            reg.SetValue(KEY, KEY_VALUE);
            reg.Close();
            MessageBox.Show("알림 끄기가 적용되었습니다.");
            getStatus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reg = Registry.LocalMachine.CreateSubKey(REG_ADDRESS);
            if (reg.GetValue(KEY) != null)
            {
                reg.DeleteValue(KEY);
            }
            reg.Close();
            MessageBox.Show("알림 끄기가 취소되었습니다.");
            getStatus();
        }

        private void 이프로그램은ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 프로젝트깃허브ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://progh2.github.io/MuteOZWL/");
        }
}
}