using Syncfusion.ListView.XForms;
using Syncfusion.XForms.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace ChatXamarin
{
    public class SfchatBehaviors : Behavior<SfChat>
    {
        #region Fields

        private SfChat sfChat = null;
        private SfListView ChatListView = null;

        #endregion

        #region Overrides

        protected override void OnAttachedTo(SfChat bindable)
        {
            base.OnAttachedTo(bindable);
            sfChat = bindable;
            if (sfChat != null)
            {
               ChatListView = (sfChat.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name.Equals("ChatListView")).GetValue(sfChat) as SfListView);
                if (ChatListView != null)
                {
                    ChatListView.Loaded += ChatPage_Loaded;
                }
            }
        }

        protected override void OnDetachingFrom(SfChat bindable)
        {
            base.OnDetachingFrom(bindable);
            ChatListView.Loaded -= ChatPage_Loaded;
            ChatListView = null;
            sfChat = null;
        }

        #endregion

        #region Events

        private void ChatPage_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            var footerView = (sfChat.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name == "FooterView").GetValue(this.sfChat) as Grid);
            ((footerView.Children[1] as MessageInputView).Content as Syncfusion.XForms.Border.SfBorder).CornerRadius = new Thickness(10, 10, 10, 10);
        }

        #endregion
    }
}
