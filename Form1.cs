﻿using PCSC;
using PCSC.Monitoring;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ThaiNationalIDCard.NET;
using ThaiNationalIDCard.NET.Models;
using PCSC.Exceptions;
using System.Configuration;

namespace ThaiSmartCardReader
{
    public partial class Form1 : Form
    {
        private static readonly IContextFactory _contextFactory = ContextFactory.Instance;
        private static string READER_NAME = "";
        private static bool SMART_CARD_CONNECTED = false;

        public Form1()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
            this.TopMost = true;

            READER_NAME = ConfigurationManager.AppSettings["READER_NAME"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SmartCardConneted();
        }

        private void SmartCardConneted()
        {            
            if (SMART_CARD_CONNECTED) return;            

            // lookup smart card is connected yet ?
            using (var Context = new SCardContext())
            {
                Context.Establish(SCardScope.System);
                string[] readernames = null;
                try
                {
                    readernames = Context.GetReaders();
                    var reader = readernames.Where(x => x.Equals(READER_NAME)).FirstOrDefault();
                    if (reader is null)
                    {
                        lblReaderConnect.Text = "Disconnected";
                        TimerSmartCard.Enabled = true;
                        SMART_CARD_CONNECTED = false;
                        TimerChecker.Enabled = false;
                        lblCardEvent.Text = "...";
                    }
                    else
                    {
                        lblReaderName.Text = reader;
                        System.Diagnostics.Debug.WriteLine(readernames);

                        CardEventMonitor();

                        lblReaderConnect.Text = "Connected";
                        TimerSmartCard.Enabled = false;
                        SMART_CARD_CONNECTED = true;
                        TimerChecker.Enabled = true;
                        lblCardEvent.Text = "...";
                    }
                }
                catch (PCSCException)
                {
                    lblReaderConnect.Text = "Disconnected";
                    TimerSmartCard.Enabled = true;
                    SMART_CARD_CONNECTED = false;
                    TimerChecker.Enabled = false;
                    lblCardEvent.Text = "...";
                }
                finally
                {
                    if (null == readernames || 0 == readernames.Length)
                    {
                        lblStatus.Text = "There are currently no readers installed.";
#if DEBUG
                        System.Diagnostics.Debug.WriteLine("There are currently no readers installed.");
#endif
                    }
                }
            }
        }
        private void CardEventMonitor()
        {
            // start monitoring card event ?
            SCardMonitor cardMonitor = new SCardMonitor(_contextFactory, SCardScope.System);
            cardMonitor.CardInserted += new CardInsertedEvent(CardInserted);
            cardMonitor.CardRemoved += new CardRemovedEvent(CardRemoved);

            cardMonitor.Start(READER_NAME);
        }

        protected void CardInserted(object sender, CardStatusEventArgs e)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Card inserted");
#endif
            lblStatus.Invoke(new Action(() => { lblStatus.Text = ""; }));
            lblCardEvent.Invoke(new Action(() => { lblCardEvent.Text = "Card inserted"; }));

            try
            {
                ThaiNationalIDCardReader cardReader = new ThaiNationalIDCardReader();
                lblCardEvent.Invoke(new Action(() => { lblCardEvent.Text = "Card reading..."; }));
                PersonalPhoto personalPhoto = cardReader.GetPersonalPhoto();
                SendKeys.SendWait(personalPhoto.CitizenID.Trim());
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.ThaiPersonalInfo.Prefix.Trim());
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.ThaiPersonalInfo.FirstName.Trim());
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.ThaiPersonalInfo.LastName.Trim());
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.AddressInfo.HouseNo.Trim() + " " + personalPhoto.AddressInfo.Lane.Trim() + " " + personalPhoto.AddressInfo.Road.Trim() + " " + personalPhoto.AddressInfo.VillageNo.Trim());
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.AddressInfo.SubDistrict.Trim());
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.AddressInfo.District.Trim());
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.AddressInfo.Province.Trim());
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.IssueDate.ToString("dd/MM/yyyy"));
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.ExpireDate.ToString("dd/MM/yyyy"));
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait(personalPhoto.Issuer.Trim());
                lblCardEvent.Invoke(new Action(() => { lblCardEvent.Text = "Card read end"; }));
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"CitizenID: {personalPhoto.CitizenID}");
                System.Diagnostics.Debug.WriteLine($"ThaiPersonalInfo: {personalPhoto.ThaiPersonalInfo}");
                System.Diagnostics.Debug.WriteLine($"EnglishPersonalInfo: {personalPhoto.EnglishPersonalInfo}");
                System.Diagnostics.Debug.WriteLine($"Sex: {personalPhoto.Sex}");
                System.Diagnostics.Debug.WriteLine($"AddressInfo: {personalPhoto.AddressInfo}");
                System.Diagnostics.Debug.WriteLine($"IssueDate: {personalPhoto.IssueDate}");
                System.Diagnostics.Debug.WriteLine($"ExpireDate: {personalPhoto.ExpireDate}");
                System.Diagnostics.Debug.WriteLine($"Issuer: {personalPhoto.Issuer}");
                System.Diagnostics.Debug.WriteLine($"Photo: {personalPhoto.Photo}");
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine(ex);
#endif
                lblStatus.Invoke(new Action(() => { lblStatus.Text = "Read data error!"; }));
            }

        }

        protected void CardRemoved(object sender, CardStatusEventArgs e)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Card removed");
# endif
            lblCardEvent.Invoke(new Action(() => { lblCardEvent.Text = "Card removed"; }));
        }

        private void TimerSmartCard_Tick(object sender, EventArgs e)
        {
            SmartCardConneted();
        }

        private void TimerChecker_Tick(object sender, EventArgs e)
        {
            using (var Context = new SCardContext())
            {
                Context.Establish(SCardScope.System);
                string[] readernames = null;
                try
                {
                    readernames = Context.GetReaders();
                    var reader = readernames.Where(x => x.Equals(READER_NAME)).FirstOrDefault();
                    if (reader is null)
                    {
                        lblReaderConnect.Text = "Disconnected";
                        TimerSmartCard.Enabled = true;
                        SMART_CARD_CONNECTED = false;
                        TimerChecker.Enabled = false;
                        lblCardEvent.Text = "...";
                    }
                    else
                    {
                        lblReaderName.Text = reader;

                        lblReaderConnect.Text = "Connected";
                        TimerSmartCard.Enabled = false;
                        SMART_CARD_CONNECTED = true;
                        TimerChecker.Enabled = true;                        
                    }                    
                }
                catch (PCSCException)
                {
                    lblReaderConnect.Text = "Disconnected";
                    TimerSmartCard.Enabled = true;
                    SMART_CARD_CONNECTED = false;
                    TimerChecker.Enabled = false;
                    lblCardEvent.Text = "...";
                }
                finally
                {
                    if (null == readernames || 0 == readernames.Length)
                    {
                        lblStatus.Text = "There are currently no readers installed.";
#if DEBUG
                        System.Diagnostics.Debug.WriteLine("There are currently no readers installed.");
#endif
                    }                
                }
            }
        }
    }
}
