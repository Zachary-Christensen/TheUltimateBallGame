using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PrefabPaths;

public class GameMain : MonoBehaviour
{
    private Camera MainCamera { get; set; }
    private UserPreferences UserPreferences { get; set; }
    private GameObject Background { get; set; }
    private GameUI GameUI { get; set; }

    private void Awake()
    {

        MainCamera = Camera.main;
        UserPreferences = GetComponent<UserPreferences>();
        GameUI = GetComponent<GameUI>();
        Background = Instantiate(Resources.Load<GameObject>(BACKGROUND_PREFAB));

        if (UserPreferences.GetPortraitMode()) // portrait mode on
        {
            SetOrientationPortrait();
        }
        else // landscape mode on
        {
            SetOrientationLandscape();
        }


    }

    private void SetOrientationLandscape()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        Background.transform.localScale = Vector3.one * MainCamera.orthographicSize * 2f; // Vector3.one * height

        GameUI.TurnLandscapeUIOn();
    }

    public void SetOrientationPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Background.transform.localScale = Vector3.one * MainCamera.orthographicSize * 2f * Screen.width / Screen.height; // Vector3.one * width

        GameUI.TurnPortaitUIOn();
    }

    void Update()
    {
        



        if (Input.GetKeyDown(KeyCode.P))
        {
            SetOrientationPortrait();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetOrientationLandscape();
        }




    }
}
