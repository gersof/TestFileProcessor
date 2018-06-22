using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestFileProcessor
{
    public partial class FileProcessorService : ServiceBase
    {
        private System.Timers.Timer timerCounter=null;
        private int counter = 0; 

        public FileProcessorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timerCounter = new System.Timers.Timer();
            timerCounter.Interval = 10000;
            timerCounter.Elapsed += new System.Timers.ElapsedEventHandler(timerCounter_Elapset);
            timerCounter.Enabled = true;
            timerCounter.Start();
        }

        void timerCounter_Elapset(object sender, ElapsedEventArgs e)
        {
            ExecuteProccess();
        }

        private void ExecuteProccess()
        {
            FilesProcessor fileProcessor = new FilesProcessor();
            fileProcessor.ProcessFiles();

            timerCounter.Enabled = true;
        }

        protected override void OnStop()
        {
        }
    }
}
