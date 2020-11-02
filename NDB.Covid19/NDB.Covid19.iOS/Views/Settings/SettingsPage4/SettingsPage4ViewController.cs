using NDB.Covid19.iOS.Views;
using NDB.Covid19.ViewModels;
using System;
using UIKit;

namespace NDB.Covid19.iOS
{
    public partial class SettingsPage4ViewController : BaseViewController
    {
        public SettingsPage4ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Line with email and phone number
            string mail = SettingsPage4ViewModel.EMAIL_TEXT + " " + SettingsPage4ViewModel.EMAIL;
            string phoneNum = SettingsPage4ViewModel.PHONE_NUM_Text + " " + SettingsPage4ViewModel.PHONE_NUM;

            //Opening hours
            string monThu = "•  " + SettingsPage4ViewModel.PHONE_OPEN_MON_THU;
            string fri = "•  " + SettingsPage4ViewModel.PHONE_OPEN_FRE;
            string sunHoly = SettingsPage4ViewModel.PHONE_OPEN_SAT_SUN_HOLY;
            string openingHours = SettingsPage4ViewModel.PHONE_OPEN_TEXT + "<br><br>" + monThu + "<br>" + fri + "<br><br>" + sunHoly;

            //Contract info section
            string contactsInfo = "<br><br>" + mail + "<br>" + phoneNum + ".<br><br>" + openingHours;

            //Support url and associated text
            string urlStringAndText = SettingsPage4ViewModel.CONTENT_TEXT_BEFORE_SUPPORT_LINK + " " + "<a href=https://" + SettingsPage4ViewModel.SUPPORT_LINK + ">" + SettingsPage4ViewModel.SUPPORT_LINK_SHOWN_TEXT + "</a>";

            //Concatenation the content
            string content = urlStringAndText + contactsInfo;

            ContentText.SetAttributedText(content);

            //Ensuring text is resiezed correctly when font size is increased
            HeaderLabel.SetAttributedText(SettingsPage4ViewModel.HEADER);
            ContentText.TranslatesAutoresizingMaskIntoConstraints = true;
            ContentText.SizeToFit();
            BackButton.AccessibilityLabel = SettingsViewModel.SETTINGS_CHILD_PAGE_ACCESSIBILITY_BACK_BUTTON;
        }

        partial void BackButton_TouchUpInside(UIButton sender)
        {
            LeaveController();
        }
    }
}