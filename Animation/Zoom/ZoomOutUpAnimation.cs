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
    public class ZoomOutUpAnimation : AnimationBase
    {
        public ZoomOutUpAnimation()
        {
            Duration = TimeSpan.FromMilliseconds(1000);
        }

        public override IAnimation PlayOn(UIElement target, Action continueWith)
        {
            var transform = (CompositeTransform)AnimationUtils.PrepareTransform(target, typeof(CompositeTransform));
            transform.CenterX = AnimationUtils.GetCenterX(target);
            transform.CenterY = AnimationUtils.GetCenterY(target);
            var storyboard = PrepareStoryboard(continueWith);

            var opacityAnim = AnimationUtils.CreateAnimationWithValues(Duration.TotalMilliseconds, 0);
            var scaleXAnim = AnimationUtils.CreateAnimationWithValues(Duration.TotalMilliseconds, 0);
            var scaleYAnim = AnimationUtils.CreateAnimationWithValues(Duration.TotalMilliseconds, 0);
            var transformYAnim = AnimationUtils.CreateAnimationWithValues(Duration.TotalMilliseconds, 30, -target.RenderSize.Height - AnimationUtils.GetPointInParent(target).Y);
            AddAnimationToStoryboard(storyboard, target, opacityAnim, "Opacity");
            AddAnimationToStoryboard(storyboard, transform, scaleXAnim, "ScaleX");
            AddAnimationToStoryboard(storyboard, transform, scaleYAnim, "ScaleY");
            AddAnimationToStoryboard(storyboard, transform, transformYAnim, "TranslateY");

            storyboard.Begin();

            return this;
        }
    }
}