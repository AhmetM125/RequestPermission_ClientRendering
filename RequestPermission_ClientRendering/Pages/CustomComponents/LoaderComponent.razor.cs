using Microsoft.AspNetCore.Components;
using RequestPermission_ClientRendering.Base;

namespace RequestPermission_ClientRendering.Pages.CustomComponents;

public partial class LoaderComponent : RazorBaseComponent
{

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
    }
}
