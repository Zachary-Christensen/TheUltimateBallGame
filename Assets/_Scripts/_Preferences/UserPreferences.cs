using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SettingsStrings;

public static class UserPreferences
{

    public static Orientation GetOrientation()
    {
        return (Orientation) PlayerPrefs.GetInt(KEY_ORIENTATION, (int)Orientation.Portrait);
    }


    public static void SetPortraitModeOn()
    {
        PlayerPrefs.SetInt(KEY_ORIENTATION, (int)Orientation.Portrait);
    }

    public static void SetLandscapeModeOn()
    {
        PlayerPrefs.SetInt(KEY_ORIENTATION, (int)Orientation.Landscape);
    }
}
