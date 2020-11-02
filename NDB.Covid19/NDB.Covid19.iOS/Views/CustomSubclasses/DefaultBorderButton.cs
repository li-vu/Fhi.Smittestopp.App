using NDB.Covid19.iOS.Utils;
using System;
using UIKit;
using static NDB.Covid19.iOS.Utils.StyleUtil;

namespace NDB.Covid19.iOS
{
    public partial class DefaultBorderButton : UIButton, IDisposable
    {
        public DefaultBorderButton (IntPtr handle) : base (handle)
        {
            Font = Font(FontType.FontSemiBold, 18f, 24f);
            SetTitleColor(UIColor.White, UIControlState.Normal);
            BackgroundColor = UIColor.Clear;
            TitleLabel.AdjustsFontSizeToFitWidth = true;
            SetTitleColor(UIColor.Clear, UIControlState.Selected);
            Layer.BorderWidth = 1;
            Layer.BorderColor = UIColor.White.CGColor;
            Layer.CornerRadius = Layer.Frame.Height / 2;
            TintColor = UIColor.Clear;
        }

        UIActivityIndicatorView _spinner;

        public override void SetTitle(string title, UIControlState forState)
        {
            base.SetTitle(title, forState);
            Superview.SetNeedsLayout();
            Layer.CornerRadius = Layer.Frame.Height / 2;
        }

        public void ShowSpinner(UIView parentView, UIActivityIndicatorViewStyle style)
        {
            _spinner = StyleUtil.AddSpinnerToView(parentView, style);
            StyleUtil.CenterView(_spinner, this);
            
            Selected = true;
            _spinner.StartAnimating();
        }

        public void HideSpinner()
        {
            _spinner?.RemoveFromSuperview();
            _spinner = null;
            Selected = false;
        }

        public new void Dispose()
        {
            HideSpinner();
            base.Dispose();
        }
    }
}