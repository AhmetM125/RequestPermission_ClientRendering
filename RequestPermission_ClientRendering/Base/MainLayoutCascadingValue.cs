using Blazored.LocalStorage;
using Blazored.Toast.Services;
using FluentValidation.Results;
using Microsoft.JSInterop;

namespace RequestPermission_ClientRendering.Base;

public class MainLayoutCascadingValue 
{
    private readonly IJSRuntime _jsRuntime;
    private readonly IToastService _toast;
    private readonly ILocalStorageService _localStorage;
    //private readonly ISyncLocalStorageService _syncLocalStorageService;
    //public string LocalStorageKey { get; } = "ahmet";

    public MainLayoutCascadingValue(IJSRuntime jsRuntime, IToastService toast, ILocalStorageService localStorage)
    {
        _jsRuntime = jsRuntime;
        _toast = toast;
        _localStorage = localStorage;
    }

    public void ShowMessage(string message, MessageType messageType = MessageType.Success)
    {
        switch (messageType)
        {
            case MessageType.Error:
                _toast.ShowError(message);
                break;
            case MessageType.Warning:
                _toast.ShowWarning(message);
                break;
            case MessageType.Success:
                _toast.ShowSuccess(message);
                break;
            case MessageType.Info:
                _toast.ShowInfo(message);
                break;
            default:
                break;
        }
    }
    public void ShowMessage(List<ValidationFailure> errors)
    {
        var message = string.Join("\n", errors.Select(x => $"* {x.ErrorMessage}"));
        _toast.ShowError(message);
    }
    //public async Task<string> GetCompany()
    //{
    //    return await _localStorage.GetItemAsync<string>(LocalStorageKey) ?? "";
    //}

    //public async Task SetCompany(string company)
    //{
    //    await _localStorage.SetItemAsync(LocalStorageKey, company);
    //}

}
