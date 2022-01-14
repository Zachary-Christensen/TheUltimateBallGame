using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    private GameObject Background { get; set; }
    [field: SerializeField]
    private GameUI GameUI { get; set; } // reference from editor

    private void Awake()
    {
        OmniFac omniFac = ScriptableObject.CreateInstance<OmniFac>();
        omniFac.Inject(transform, GameUI);

        // change orientation of screen on mobile phones to setting set from main menu
        MyTools.SetScreenToOrientation(UserPreferences.GetOrientation());

        StateMachineGame stateMachineGame = GetComponent<StateMachineGame>();
        stateMachineGame.Inject(GameUI, omniFac);
        stateMachineGame.Play();
    }

}
