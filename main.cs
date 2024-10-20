using System.Runtime.InteropServices;
using System.Diagnostics;


 // critical(1); enable anti termanite,critical(0) disable anti terminate.
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern int NtSetInformationProcess(IntPtr hProcess, int processInformationClass
            , ref int processInformation, int processInformationLength);
 
        //https://undocumented.ntinternals.net/index.html?page=UserMode%2FUndocumented%20Functions%2FNT%20Objects%2FProcess%2FPROCESS_INFORMATION_CLASS.html
 
       
 
        public void critical(int status)
        {
            int BreakOnTermi =0x1D;  //breakoftermination value
            //https://undocumented.ntinternals.net/index.html?page=UserMode%2FUndocumented%20Functions%2FNT%20Objects%2FProcess%2FPROCESS_INFORMATION_CLASS.html
            Process.EnterDebugMode();
            NtSetInformationProcess(Process.GetCurrentProcess().Handle, BreakOnTermi, 
            ref status, sizeof(int));
 
        }


// Example Add Button Enable\Disable

        private void button1_Click(object sender, EventArgs e)
        {
            critical(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            critical(0);
        }
