using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Background : MonoBehaviour, IChangeOrientation
{
    public void ChangeOrientation(Orientation orientation)
    {
        switch (orientation)
        {
            case Orientation.Portrait:
                gameObject.transform.localScale = Vector3.one * MyTools.GetScreenWidth();
                break;
            case Orientation.Landscape:
                gameObject.transform.localScale = Vector3.one * MyTools.GetScreenHeight();
                break;
        }
    }
}
