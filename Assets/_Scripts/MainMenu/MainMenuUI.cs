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
    private UserPreferences UserPreferences { get; set; }


    private void Start()
    {
        UserPreferences = GetComponent<UserPreferences>();

        if (UserPreferences.GetPortraitMode())
        {
            TglOrientation.isOn = true;
            TurnOnPortraitMode();
        }
        else
        {
            TglOrientation.isOn = false;
            TurnOnLandscapeMode();
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
