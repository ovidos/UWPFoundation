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
    public class SlideInUpAnimation : AnimationBase
    {
        public SlideInUpAnimation()
        {
            Duration = TimeSpan.FromMilliseconds(1000);
        }

        public override IAnimation PlayOn(UIElement target, Action continueWith)
        {
            var transform = (CompositeTransform)AnimationUtils.PrepareTransform(target, typeof(CompositeTransform));
            target.Opacity = 0;
            transform.TranslateY = AnimationUtils.GetPointInParent(target).Y + target.RenderSize.Height;
            var storyboard = PrepareStoryboard(continueWith);

            var opacityAnim = AnimationUtils.CreateAnimationWithValues(Duration.TotalMilliseconds, 1);
            var translateAnim = AnimationUtils.CreateAnimationWithValues(Duration.TotalMilliseconds, 0);
            AddAnimationToStoryboard(storyboard, target, opacityAnim, "Opacity");
            AddAnimationToStoryboard(storyboard, transform, translateAnim, "TranslateY");

            storyboard.Begin();

            return this;
        }
    }
}