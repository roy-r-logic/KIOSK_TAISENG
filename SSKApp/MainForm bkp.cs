using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using SSKApp.Extensions.ControlExtensions;
using SSKApp.Helpers;
using SSKApp.Helpers.ChromiumObjects;
using SSKApp.Libraries.Chromium.Handlers;
using System;

using System.Windows.Forms;

namespace SSKApp
{
    // Self-Service Kiosk App Project Template
    // Created by: Daniel Choo
    // Creation date: 01/08/2022

    // If you experience the references not found, uninstall and install the Cefsharp
    // If you experience the Cefsharp asked to run in x64 or setup AnyCPU, make sure you set x64 in Configuration Manager
    public partial class MainForm : Form
    {
      
        private readonly ChromiumWebBrowser _chromeBrowser;


        public MainForm()
        {
            InitializeComponent();

           // this.Location = Screen.AllScreens[1].WorkingArea.Location;

            #region Chromium Setup
            try
            {
                CefSettings settings = new CefSettings();

                settings.CefCommandLineArgs.Add("disable-pinch", "1");
                settings.CefCommandLineArgs.Add("overscroll-history-navigation", "0");

                Cef.EnableHighDPISupport();
                Cef.Initialize(settings);

                CefSharpSettings.ConcurrentTaskExecution = true;
                CefSharpSettings.LegacyJavascriptBindingEnabled = true;
                CefSharpSettings.SubprocessExitIfParentProcessClosed = true;

                _chromeBrowser = new ChromiumWebBrowser(AppConstants.WebUrl)
                {
                    MenuHandler = new CustomMenuHandler(),
                    BrowserSettings = new BrowserSettings
                    {
                        FileAccessFromFileUrls = CefState.Enabled,
                        UniversalAccessFromFileUrls = CefState.Enabled
                    }
                };

                _chromeBrowser.Dock = DockStyle.Fill;

                Controls.Add(_chromeBrowser);

                _chromeBrowser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;

                #endregion

                //Add chromium objects here

                _chromeBrowser.JavascriptObjectRepository.Register("qrScanningChromiumObject", new QrScanningChromiumObject(), true);
           
           
           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Initialize Chrome Browser: " + ex.Message);
            }
        }

        public void ErrorThrown(string error)
        {
          
        }

        private void OnIsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var b = ((ChromiumWebBrowser)sender);

            this.InvokeOnUiThreadIfRequired(() => b.Focus());

#if DEBUG
            _chromeBrowser.ShowDevTools();
#endif
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
