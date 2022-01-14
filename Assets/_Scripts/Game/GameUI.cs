using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneNames;


public class GameUI : MonoBehaviour, IChangeOrientation
{

    [field: SerializeField]
    public RectTransform PortaitUI { get; set; }
    [field: SerializeField]
    public RectTransform LandscapeUI { get; set; }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SCENE_MAINMENU);
    }

    private void TurnPortaitUIOn()
    {
        LandscapeUI.gameObject.SetActive(false);
        PortaitUI.gameObject.SetActive(true);
    }

    private void TurnLandscapeUIOn()
    {
        PortaitUI.gameObject.SetActive(false);
        LandscapeUI.gameObject.SetActive(true);
    }

    public void ChangeOrientation(Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.Portrait:
                TurnPortaitUIOn();
                break;
            case Orientation.Landscape:
                TurnLandscapeUIOn();
                break;
        }
    }
}
