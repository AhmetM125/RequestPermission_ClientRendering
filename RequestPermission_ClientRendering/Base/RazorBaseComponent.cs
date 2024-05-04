using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RequestPermission_ClientRendering.Base
{
    public class RazorBaseComponent : ComponentBase
    {
        [Inject] protected IJSRuntime JSRuntime { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }
        [CascadingParameter] protected MainLayoutCascadingValue MainLayoutCascadingValue { get; set; }
        [Inject] protected AuthorizationProvider AuthorizationProvider { get; set; }
        protected PageStatus PageStatus { get; set; } = PageStatus.List;
        protected async Task ShowModal(string modalId) => await JSRuntime.InvokeVoidAsync("OpenModal", modalId);
        protected async Task CloseModal(string modalId) => await JSRuntime.InvokeVoidAsync("CloseModal", modalId);

    }
    public enum PageStatus
    {
        Modify = 1,
        Insert = 2,
        List = 3,
        Delete = 4
    }
    public enum MessageType
    {
        Error,
        Warning,
        Success,
        Info
    }
}
