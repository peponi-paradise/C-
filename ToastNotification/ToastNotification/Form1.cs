﻿using DevExpress.Data;
using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;

namespace ToastNotification
{
    public partial class Form1 : Form
    {
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager NotificationsManager;

        public Form1()
        {
            InitializeComponent();

            // 알림 기본 설정
            InitToastNotification();

            // Win10 스타일의 알림 기능을 이용하려면 시작 메뉴에 바로가기 등록이 되어 있어야 한다.
            CheckShortcut();
        }

        private void InitToastNotification()
        {
            NotificationsManager = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);

            NotificationsManager.ApplicationId = "12b48acf-0e0a-49ef-8041-dceb872ed14d";
            NotificationsManager.ApplicationName = "ToastNotificationTest";

            // 알림 추가
            NotificationsManager.Notifications.AddRange(new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[] {
            new DevExpress.XtraBars.ToastNotifications.ToastNotification("77b2bb7e-94e3-40b5-ac7a-eec2af0da5da",
            null,
            null,
            ((System.Drawing.Image)(ToastNotification.Properties.Resources.ResourceManager.GetObject("NotificationsManager.Notifications"))),
            null,
            null,
            null,
            "Header",
            "Body",
            "Body2",
            "ClockStrikes",
            DevExpress.XtraBars.ToastNotifications.ToastNotificationSound.NoSound,
            DevExpress.XtraBars.ToastNotifications.ToastNotificationDuration.Long,
            null,
            DevExpress.XtraBars.ToastNotifications.AppLogoCrop.Default,
            DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Generic)});

            NotificationsManager.UpdateToastContent += NotificationsManager_UpdateToastContent;
        }

        private void NotificationsManager_UpdateToastContent(object sender, DevExpress.XtraBars.ToastNotifications.UpdateToastContentEventArgs e)
        {
            // Footer 추가하는 방법
            XmlDocument doc = e.ToastContent;
            XmlNode bindingNode = doc.GetElementsByTagName("binding").Item(0);
            if (bindingNode != null)
            {
                XmlElement group = doc.CreateElement("group");
                bindingNode.AppendChild(group);

                XmlElement subGroup = doc.CreateElement("subgroup");
                group.AppendChild(subGroup);

                XmlElement text = doc.CreateElement("text");
                subGroup.AppendChild(text);
                text.SetAttribute("hint-style", "base");
                text.InnerText = "https://github.com/peponi-paradise";

                text = doc.CreateElement("text");
                subGroup.AppendChild(text);
                text.SetAttribute("hint-style", "captionSubtle");
                text.InnerText = "https://peponi-paradise.tistory.com/";
            }
        }

        private void CheckShortcut()
        {
            if (!ShellHelper.IsApplicationShortcutExist(Application.ProductName))
            {
                var rtn = XtraMessageBox.Show("Need to create shortcut on start menu\nif you want to get windows notification.\nProceed?", "Add application shortcut", MessageBoxButtons.OKCancel);
                if (rtn == DialogResult.OK) AddShortcut();
                else
                {
                    // 나중에 따로 추가하도록 유도
                    XtraMessageBox.Show("You can create shortcut manually or via application menu", "Add application shortcut");
                }
            }
        }

        private void AddShortcut()
        {
            // 바로가기 추가
            ShellHelper.TryCreateShortcut(
                            applicationId: NotificationsManager.ApplicationId,
                            name: Application.ProductName);

            // 바로가기 추가 후 다시 시작해야 정상 적용됨
            XtraMessageBox.Show("Application will restart automatically", "Work done");
            Process.Start(Application.ExecutablePath);
            Process.GetCurrentProcess().Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 알림 내용 설정
            NotificationsManager.Notifications[0].AttributionText = "ClockStrikes";
            NotificationsManager.Notifications[0].Header = "Hello world";
            NotificationsManager.Notifications[0].Body = "This is Big text";
            NotificationsManager.Notifications[0].Body2 = "This is Small text";

            // 알림 호출
            NotificationsManager.ShowNotification(NotificationsManager.Notifications[0]);
        }
    }
}