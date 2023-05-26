﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using ExternalAPI;
using VMT_RMG;

namespace VMT_RMG_800by600
{
    /// <summary>
    /// Interaction logic for BreakTimeView.xaml
    /// </summary>
    public partial class BreakTimeView : UserControl
    {
        public enum WaitingType
        {
            NONE = 0,
            SET,
            UNSET,
        }

        private String _ReasonCd;
        public String ReasonCd
        {
            get { return _ReasonCd; }
            set { _ReasonCd = value; }
        }

        private String _ReasonNm;
        public String ReasonNm
        {
            get { return _ReasonNm; }
            set 
            { 
                _ReasonNm = value;
                this.TextBlock_Reason.Text = value;
            }
        }
        public WaitingType Waiting = WaitingType.NONE;

        public BreakTimeView()
        {
            this.InitializeComponent();

            // Register this UI Component to PresentationMgr
            PresentationMgr.Singleton.AddUIComponent(this.ToString(), this);

            PresentationMgr.Singleton.PropertyChanged_UITheme += new System.ComponentModel.PropertyChangedEventHandler(Singleton_PropertyChanged_UITheme);
        }

        ~BreakTimeView()
        {
            PresentationMgr.Singleton.PropertyChanged_UITheme -= new System.ComponentModel.PropertyChangedEventHandler(Singleton_PropertyChanged_UITheme);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Init UI Skin
            InitSkinImage();

            this.Btn_Cancel.Content = "Cancel";
            this.Btn_Complete.Content = "Request";

            this.TextBlock_Break_Start_Date.Text = "";
            //this.TextBlock_Break_Start_Time.Text = "";

            this.TextBlock_Break_End_Date.Text = "";
            //this.TextBlock_Break_End_Time.Text = "";
        }

        private void Singleton_PropertyChanged_UITheme(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (PresentationMgr.Singleton.CurrentUITheme == PresentationMgr.UITheme.UITheme_Day)
            {
                this.Image_Title_BreakTiem.Source = UIThemeMgr.Day.AvailableView_TitleBreakTimeImage;  //new BitmapImage(new Uri(@"/VMT_RMG;component/Images/MainView/AvailableView/Title_BreakTime.png", UriKind.Relative));

                PresentationMgr.SetSkinButton(this.Btn_Cancel,
                    UIThemeMgr.Day.AvailableView_ButtonDefaultImage, UIThemeMgr.Day.AvailableView_ButtonPressImage, UIThemeMgr.Day.AvailableView_ButtonDefaultImage);
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images/MainView/AvailableView/Button_Default.png", UriKind.Relative)),
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images/MainView/AvailableView/Button_Press.png", UriKind.Relative)),
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images/MainView/AvailableView/Button_Default.png", UriKind.Relative))
                    //);

                PresentationMgr.SetSkinButton(this.Btn_Complete,
                    UIThemeMgr.Day.AvailableView_ButtonDefaultImage, UIThemeMgr.Day.AvailableView_ButtonPressImage, UIThemeMgr.Day.AvailableView_ButtonDefaultImage);
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images/MainView/AvailableView/Button_Default.png", UriKind.Relative)),
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images/MainView/AvailableView/Button_Press.png", UriKind.Relative)),
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images/MainView/AvailableView/Button_Default.png", UriKind.Relative))
                    //);
            }
            else if (PresentationMgr.Singleton.CurrentUITheme == PresentationMgr.UITheme.UITheme_Night)
            {
                this.Image_Title_BreakTiem.Source = UIThemeMgr.Night.AvailableView_TitleBreakTimeImage;   //new BitmapImage(new Uri(@"/VMT_RMG;component/Images(Night)/MainView/AvailableView/Title_BreakTime.png", UriKind.Relative));

                PresentationMgr.SetSkinButton(this.Btn_Cancel,
                    UIThemeMgr.Night.AvailableView_ButtonDefaultImage, UIThemeMgr.Night.AvailableView_ButtonPressImage, UIThemeMgr.Night.AvailableView_ButtonDefaultImage);
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images(Night)/MainView/AvailableView/Button_Default.png", UriKind.Relative)),
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images(Night)/MainView/AvailableView/Button_Press.png", UriKind.Relative)),
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images(Night)/MainView/AvailableView/Button_Default.png", UriKind.Relative))
                    //);

                PresentationMgr.SetSkinButton(this.Btn_Complete,
                    UIThemeMgr.Night.AvailableView_ButtonDefaultImage, UIThemeMgr.Night.AvailableView_ButtonPressImage, UIThemeMgr.Night.AvailableView_ButtonDefaultImage);
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images(Night)/MainView/AvailableView/Button_Default.png", UriKind.Relative)),
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images(Night)/MainView/AvailableView/Button_Press.png", UriKind.Relative)),
                    //new BitmapImage(new Uri(@"/VMT_RMG;component/Images(Night)/MainView/AvailableView/Button_Default.png", UriKind.Relative))
                    //);
            }
        }

        private void InitSkinImage()
        {
            this.Singleton_PropertyChanged_UITheme(null, null);

            
        }

        public void SetStartDateTime()
        {
            String currentDate = DateTime.Now.ToString("yyyy/MM/dd");
            String currentTime = DateTime.Now.ToString("HH:mm");

            this.TextBlock_Break_Start_Date.Text = currentDate + "     " + currentTime;
            //this.TextBlock_Break_Start_Time.Text = currentTime;
        }

        public void SetEndDateTime()
        {
            String currentDate = DateTime.Now.ToString("yyyy/MM/dd");
            String currentTime = DateTime.Now.ToString("HH:mm");

            this.TextBlock_Break_End_Date.Text = currentDate + "     " + currentTime;
            //this.TextBlock_Break_End_Time.Text = currentTime;
        }

        private void Btn_Cancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PresentationMgr.Singleton.UI_SwichUI(PresentationMgr.UIMode.MainView);
        }

        private void Btn_Complete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (PresentationMgr.MainView.UC_JobList.Btn_Available.Content.Equals("Available"))
                this.Waiting = WaitingType.SET;
            else
                this.Waiting = WaitingType.UNSET;
            VMT_Data_JAT2.VMT_DataMgr_Common.GetMachineStop_Ask();
                        
            //VMT_Data_JAT2.Objects.Common.VD_Common_SetMachineStop_Send value = new VMT_Data_JAT2.Objects.Common.VD_Common_SetMachineStop_Send();

            //if (PresentationMgr.MainView.UC_JobList.Btn_Available.Content.Equals("Available"))            
            //    value.m_iBreakStatus = 1;                            
            //else            
            //    value.m_iBreakStatus = 0;                            

            //value.Data.ReasonCd = this.ReasonCd;
            //value.Data.ReasonNm = this.ReasonNm;

            //InterfaceMessageLoader.instance().WriteInterfaceMessage<VMT_Data_JAT2.Objects.Common.VD_Common_SetMachineStop_Send>(String.Format("[{0}] {1}", System.Reflection.MethodBase.GetCurrentMethod().Name
            //    , "SetMachineStop_Ask"), value);

            //VMT_Data_JAT2.VMT_DataMgr_Common.SetMachineStop_Ask(ref value);

            //PresentationMgr.Singleton.UI_SwichUI(PresentationMgr.UIMode.MainView);
        }
    }
}