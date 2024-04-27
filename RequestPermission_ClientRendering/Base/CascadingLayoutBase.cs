using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace RequestPermission_ClientRendering.Base;

public class CascadingLayoutBase : LayoutComponentBase
{
    [Inject] IJSRuntime JSRuntime { get; set; }
    [CascadingParameter] public MainLayoutCascadingValue LayoutValue { get; set; }

}
