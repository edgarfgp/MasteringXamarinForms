using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Speech.Tts;
using Android.Views;
using Android.Widget;
using Paperboy.Droid.DependencyServices;
using Paperboy.IServices;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(TextSpeecher))]
namespace Paperboy.Droid.DependencyServices
{
    public class TextSpeecher : Java.Lang.Object, ITextSpeecher, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;

        public TextSpeecher() { }

        public void Speak(string text)
        {
            var ctx = Forms.Context;
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(ctx, this);
            }
            else
            {
                if (Android.OS.Build.VERSION.Release.StartsWith("4"))
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null);
                }
                else
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null, null);
                }
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                if (Android.OS.Build.VERSION.Release.StartsWith("4"))
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null);
                }
                else
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null, null);
                }
            }
        }
        #endregion
    }
}