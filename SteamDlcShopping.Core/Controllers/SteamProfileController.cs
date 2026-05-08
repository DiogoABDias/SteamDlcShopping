using SteamDlcShopping.Core.Models;
using SteamDlcShopping.Core.ViewModels;

namespace SteamDlcShopping.Core.Controllers;

public static class SteamProfileController
{
    //Fields
    private static SteamProfile? _steamProfile;

    //Methods
    public static bool IsSessionActive()
    {
        bool result = false;

        try
        {
            if (_steamProfile is null)
            {
                return result;
            }

            result = LibraryController.DynamicStoreIsFilled() && LibraryController.GamesIsFilled();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }

        return result;
    }

    public static async Task LoginAsync(string steamApiKey, string sessionId, string steamLoginSecure)
    {
        try
        {
            _steamProfile ??= new();

            await _steamProfile.LoadAsync(steamLoginSecure);

            if (_steamProfile.Id == 0)
            {
                return;
            }

            await LibraryController.LoginAsync(steamApiKey, sessionId, steamLoginSecure);
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }
    }

    public static void Logout()
    {
        try
        {
            _steamProfile = null;
            LibraryController.Logout();
            BlacklistController.Reset();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }
    }

    public static SteamProfileView GetSteamProfile()
    {
        SteamProfileView result = new();

        if (_steamProfile is null)
        {
            return result;
        }

        try
        {
            result.Username = _steamProfile.Username;
            result.AvatarUrl = _steamProfile.AvatarUrl;
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }

        return result;
    }

    internal static long GetSteamId()
    {
        long result = 0;

        if (_steamProfile is null)
        {
            return result;
        }

        try
        {
            result = _steamProfile.Id;
        }
        catch (Exception exception)
        {
            Log.Fatal(exception);
        }

        return result;
    }
}