using System.Text.RegularExpressions;

namespace RequestPermission_ClientRendering.Utils.Password;

public static class PasswordUtility
{
    public static bool ValidatePassword(this string password)
    {
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMinimum8Chars = new Regex(@".{8,}");

        return hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
    }
}
