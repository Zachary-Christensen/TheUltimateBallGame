using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static PrefabPaths;



public enum Orientation
{
    Portrait = 0,
    Landscape = 1
}

public class OmniFac : ScriptableObject
{
    private GameUI GameUI { get; set; }
    private Transform Parent { get; set; }

    public GameObject CreateBackground()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>(BACKGROUND_PREFAB));
        obj.name = $"Background {Guid.NewGuid()}";
        obj.transform.SetParent(Parent);

        obj.GetComponent<IChangeOrientation>().ChangeOrientation(UserPreferences.GetOrientation());

        return obj;
    }


    public void Inject(Transform parent, GameUI gameUI)
    {
        Parent = parent;
        GameUI = gameUI;
    }


}

