using System;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace SerialToKeyboard.Control
{
    class ComToKey : IDisposable
    {
        private readonly SerialPort _port;
        private string _EndChar;
        private string _StartChar;

        public ComToKey(SerialPort port, string StartChar, string EndChar)
        {
            _StartChar = StartChar;
            _EndChar = EndChar;
            _port = port;
            _port.DataReceived += PortOnDataReceived;
        }

        /// <summary>
        /// Event thrown whenever the serial port received data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortOnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (_port.BytesToRead > 0)
            {
                // PostKeys
                var original = _port.ReadExisting();
                // Reformat string to fit SendKeys()
                var reformattedString = DefaultFormatter.Reformat(original);
                try
                {
                    if (reformattedString != null)
                    {
                        if (_StartChar != null)
                        {
                            SendKeys.SendWait(_StartChar);
                        }

                        System.Diagnostics.Debug.WriteLine(reformattedString);
                        SendKeys.SendWait(reformattedString);

                        if (_EndChar == "tab")
                        {
                            SendKeys.SendWait("{tab}");
                        }
                        else if (_EndChar == "enter")
                        {
                            SendKeys.SendWait("{enter}");
                        }

                    }
                }
                // Handle exception caused if keys are sent to an application
                // not handling keys
                // catch(InvalidOperationException)    
                catch (Exception ex)
                {
                    MessageBox.Show("com Error " + ex.Message);
                }
            }
        }

        public void Start()
        {
            if (!_port.IsOpen)
                _port.Open();
        }
        public void Stop()
        {
            if (_port.IsOpen)
                _port.Close();
        }
        public void Dispose()
        {
            if (_port.IsOpen)
                _port.Close();
            _port.DataReceived -= PortOnDataReceived;
            _port.Dispose();
            
        }
    }
}
