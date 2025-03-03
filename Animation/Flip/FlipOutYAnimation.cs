﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Animation
{
    public class FlipOutYAnimation : AnimationBase
    {
        public FlipOutYAnimation()
        {
            Duration = TimeSpan.FromMilliseconds(1200);
        }

        public override IAnimation PlayOn(UIElement target, Action continueWith)
        {
            var projection = (PlaneProjection)AnimationUtils.PrepareProjection(target, typeof(PlaneProjection));
            projection.CenterOfRotationX = 0.5;
            projection.RotationY = 0;
            target.Opacity = 1;

            var storyboard = PrepareStoryboard(continueWith);

            var opacityAnim = AnimationUtils.CreateAnimationWithValues(Duration.TotalMilliseconds, 0);
            AddAnimationToStoryboard(storyboard, target, opacityAnim, "Opacity");
            var rotateAnim = AnimationUtils.CreateAnimationWithValues(Duration.TotalMilliseconds, 90);
            AddAnimationToStoryboard(storyboard, projection, rotateAnim, "RotationY");

            storyboard.Begin();

            return this;
        }

    }
}
