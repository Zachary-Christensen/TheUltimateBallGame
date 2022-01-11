using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneNames;


public class GameUI : MonoBehaviour
{

    [field: SerializeField]
    public RectTransform PortaitUI { get; set; }
    [field: SerializeField]
    public RectTransform LandscapeUI { get; set; }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SCENE_MAINMENU);
    }

    public void TurnPortaitUIOn()
    {
        LandscapeUI.gameObject.SetActive(false);
        PortaitUI.gameObject.SetActive(true);
    }

    public void TurnLandscapeUIOn()
    {
        PortaitUI.gameObject.SetActive(false);
        LandscapeUI.gameObject.SetActive(true);
    }
}
