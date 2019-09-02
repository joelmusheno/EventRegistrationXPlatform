﻿using System;
using Xamarin.Forms;

namespace SoS.Controls
{
    public class RoundedButton : Button
    {

        private bool _measured;
        private bool _self;

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (!_self) _measured = true;
            return base.OnMeasure(widthConstraint, heightConstraint);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (_measured)
            {
                _measured = false;
                _self = true;

                WidthRequest = width + Padding.Left + Padding.Right;
                HeightRequest = height + Padding.Top + Padding.Bottom;
            }
            else
            {
                _self = false;
            }
        }
    }
}
