# change-corner-radius-chat-editor-xamarin-forms

## About the sample
  This example shows how to change the corner radius of the Chat Editor in Xamarin.Forms (SfChat)

 [SfChat](https://www.syncfusion.com/xamarin-ui-controls/xamarin-chat) does not have any direct support for changing the corner radius of the editor. However, it can be changed by getting the editor from the FooterView of the SfChat and setting a corner radius for the same.

#### XAML
Define the behavior for the SfChat.

```XAML

<ContentPage.Content>
        <sfChat:SfChat x:Name="sfChat"
                       Messages="{Binding Messages}"
                       CurrentUser="{Binding CurrentUser}"     
                       ShowOutgoingMessageAvatar="True">
            <sfChat:SfChat.Behaviors>
                <local:SfchatBehaviors/>
            </sfChat:SfChat.Behaviors>
        </sfChat:SfChat>
    </ContentPage.Content>

```
#### C#
Define the CornerRadius thickness in ChatListview Loaded event.

```C#

public class SfchatBehaviors : Behavior<ContentPage>
{
private SfChat sfChat = null;
private SfListView ChatListView = null;
protected override void OnAttachedTo(ContentPage bindable)
        {
            sfChat = bindable.FindByName<SfChat>("sfChat");
            if (sfChat != null)
            {
               ChatListView = (sfChat.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name.Equals("ChatListView")).GetValue(sfChat) as SfListView);
                if (ChatListView != null)
                {
                    ChatListView.Loaded += ChatPage_Loaded;
                }
            }
            base.OnAttachedTo(bindable);
        }
  private void ChatPage_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            var footerView = (sfChat.GetType().GetRuntimeProperties().FirstOrDefault(x => x.Name == "FooterView").GetValue(this.sfChat) as Grid);
            ((footerView.Children[1] as MessageInputView).Content as Syncfusion.XForms.Border.SfBorder).CornerRadius = new Thickness(10, 10, 10, 10);
        }
}

```

 ![EditorCornerRadius](EditorCornerradius.jpg)

# <a name="requirements-to-run-the-demo"></a>Requirements to run the demo ##

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

