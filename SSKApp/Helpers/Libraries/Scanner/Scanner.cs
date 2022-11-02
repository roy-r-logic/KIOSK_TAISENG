using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SSKApp.Helpers.Libraries.Scanner
{
    public class Scanner : IDisposable
    {
        private CancellationTokenSource _cancelTask;

        private SerialPort _serial = null;
        private string Message { get; set; }


        public Scanner()
        {
            _cancelTask = new CancellationTokenSource();
           
            Task.Run(() => this.Initial()).Wait();
        }

        private async Task<bool> Initial()
        {
            //close before connecting
            await Disconnect();

            _serial = new SerialPort("COM3");
            _serial.BaudRate = 9600;
            _serial.Parity = Parity.None;
            _serial.StopBits = StopBits.One;
            _serial.DataBits = 8;
            _serial.Handshake = Handshake.None;


            await Task.CompletedTask;
            return _serial.IsOpen;
        }

        public async Task<string> ReadAsync()
        {
            if (_serial == null)
            {
                throw new Exception("Scaning method was called without Connection");
            }

            await Task.CompletedTask;
            _serial.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            _serial.Open();

         
            await Task.Delay(1000 * 60 * 60, _cancelTask.Token).ContinueWith(x => x.Exception == default); //5 minutes
            
            await Task.CompletedTask;

            return Message;
        }

        private async Task<bool> Disconnect()
        {

            if (_serial != null)
            {
                if (_serial.IsOpen) _serial.Close();
                _serial.DataReceived -= DataReceivedHandler;
                _serial.Dispose();
                _serial = null;
                Message = null;
                return true;

            }

            await Task.CompletedTask;
            return _serial == null;
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            Message = sp.ReadExisting();

            if (!string.IsNullOrEmpty(Message))
            {
                _cancelTask.Cancel();
                if (_cancelTask.IsCancellationRequested)
                {
                    Task.FromCanceled(_cancelTask.Token);
                }
            }
        }

        public void Dispose()
        {
            Task.Run(() => this.Disconnect()).Wait();
        }

        
    }
}
