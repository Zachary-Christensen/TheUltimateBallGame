using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SceneNames;
using static SettingsStrings;

public class MainMenuUI : MonoBehaviour
{

    [field: SerializeField]
    public Toggle TglOrientation { get; set; }
    [field: SerializeField]
    public Text TxtTglOrientation { get; set; }


    private void Start()
    {
        /* 
         * If screen is not reset to portrait mode, then odd behaviour occurs when switching between orientations and scenes
         */
        MyTools.SetScreenToOrientation(Orientation.Portrait);

        switch (UserPreferences.GetOrientation())
        {
            case Orientation.Portrait:
                TglOrientation.isOn = true;
                TurnOnPortraitMode();
                break;
            case Orientation.Landscape:
                TglOrientation.isOn = false;
                TurnOnLandscapeMode();
                break;
            default:
                break;
        }

    }

    public void CenterPlayButton()
    {
        SceneManager.LoadScene(SCENE_GAME);
    }

    public void ToggleOrientation()
    {
        if (TglOrientation.isOn)
        {
            TurnOnPortraitMode();
        }
        else
        {
            TurnOnLandscapeMode();
        }
    }

    private void TurnOnLandscapeMode()
    {
        UserPreferences.SetLandscapeModeOn();
        TxtTglOrientation.text = TXT_LANDSCAPE_MODE;
    }

    private void TurnOnPortraitMode()
    {
        UserPreferences.SetPortraitModeOn();
        TxtTglOrientation.text = TXT_PORTRAIT_MODE;
    }
}
