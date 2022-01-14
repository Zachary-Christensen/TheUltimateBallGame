using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class MyTools
{
    public static float GetScreenWidth()
    {
        return Camera.main.orthographicSize * 2f * Screen.width / Screen.height; ;
    }

    public static float GetScreenHeight()
    {
        return Camera.main.orthographicSize * 2f;
    }

    public static void SetScreenToOrientation(Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.Portrait:
                Screen.orientation = ScreenOrientation.Portrait;
                break;
            case Orientation.Landscape:
                Screen.orientation = ScreenOrientation.Landscape;
                break;
        }
    }
}

