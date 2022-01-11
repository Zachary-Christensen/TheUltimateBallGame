using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SettingsStrings;

public class UserPreferences : MonoBehaviour
{

    // 0 = portrait mode, >0 = landscape mode
    // true = portrait, false = lanscape
    public bool GetPortraitMode()
    {
        if (PlayerPrefs.GetInt(KEY_ORIENTATION, 0) == 0)
            return true;
        else
            return false;
    }


    public void SetPortraitModeOn()
    {
        PlayerPrefs.SetInt(KEY_ORIENTATION, 0);
    }

    public void SetLandscapeModeOn()
    {
        PlayerPrefs.SetInt(KEY_ORIENTATION, 1);
    }
}
