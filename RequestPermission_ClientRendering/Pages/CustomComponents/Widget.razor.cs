using Microsoft.AspNetCore.Components;

namespace RequestPermission_ClientRendering.Pages.CustomComponents
{
    public partial class Widget : ComponentBase
    {
        [Parameter] public string Title { get; set; } = "Widget Title";
        [Parameter] public string Description { get; set; } = "Widget Description";
    }
}
