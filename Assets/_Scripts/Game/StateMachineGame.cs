using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Start = 1000,
    LoadLevel = 0,
    PreTurn = 1,
    PlayerTurn = 2,
    UsePlayerButton = 3,
    Aiming = 5,
    Firing = 6,
    ReturnWeapon = 7,
    PostTurn = 8,
    Win = 9,
    Lose = 10
}

public enum GameInputAlphabet
{
    NoInput = 1000,
    MainStart = 0,
    LevelLoaded = 1,
    PreTurnComplete = 2,
    PlayerButtonPress = 3,
    PlayerButtonComplete = 4,
    AimInputInitiated = 5,
    ValidInputRelease = 6,
    InvalidInputRelease = 7,
    WeaponReturned = 8,
    EndTurnButtonPress = 9,
    Win = 10,
    Lose = 11,
    Continue = 12
}

public class StateMachineGame : MonoBehaviour
{
    public GameState GameState { get; private set; } = GameState.Start;
    private GameInputAlphabet GameInput { get; set; } = GameInputAlphabet.MainStart;
    private bool _readyForTransition = true;
    private bool _play = true;
    private GameUI GameUI { get; set; }
    private OmniFac OmniFac { get; set; }

    private void Update()
    {
        if (_readyForTransition && _play)
        {
            // correlate state with alphabet
            switch (GameState)
            {
                case GameState.Start:
                    if (GameInput == GameInputAlphabet.MainStart)
                    {
                        LoadLevel();
                    }
                    break;
                case GameState.LoadLevel:
                    if (GameInput == GameInputAlphabet.LevelLoaded)
                    {
                        StartCoroutine(PreTurn());
                    }
                    break;
                case GameState.PreTurn:
                    if (GameInput == GameInputAlphabet.PreTurnComplete)
                    {
                        PlayerTurn();
                    }
                    break;
                case GameState.PlayerTurn:
                    if (GameInput == GameInputAlphabet.PlayerButtonPress)
                    {
                        UsePlayerButton();
                    }
                    else if (GameInput == GameInputAlphabet.AimInputInitiated)
                    {
                        Aim();
                    }
                    break;
                case GameState.UsePlayerButton:
                    if (GameInput == GameInputAlphabet.PlayerButtonComplete)
                    {
                        UsePlayerButton();
                    }
                    break;
                case GameState.Aiming:
                    if (GameInput == GameInputAlphabet.ValidInputRelease)
                    {
                        Fire();
                    }
                    else if (GameInput == GameInputAlphabet.InvalidInputRelease)
                    {
                        PlayerTurn();
                    }
                    break;
                case GameState.Firing:
                    if (GameInput == GameInputAlphabet.WeaponReturned)
                    {
                        PostTurn();
                    }
                    else if (GameInput == GameInputAlphabet.EndTurnButtonPress)
                    {
                        ReturnWeapon();
                    }
                    break;
                case GameState.ReturnWeapon:
                    if (GameInput == GameInputAlphabet.WeaponReturned)
                    {
                        PostTurn();
                    }
                    break;
                case GameState.PostTurn:
                    if (GameInput == GameInputAlphabet.Win)
                    {
                        Won();
                    }
                    else if (GameInput == GameInputAlphabet.Lose)
                    {
                        Lost();
                    }
                    else if (GameInput == GameInputAlphabet.Continue)
                    {
                        PreTurn();
                    }
                    break;
                case GameState.Win:
                    break;
                case GameState.Lose:
                    break;
                default:
                    break;
            }
        }
    }


    public void Play()
    {
        _play = true;
    }

    private void LoadLevel()
    {
        BeginStateMethod(GameState.LoadLevel);
        print($"{System.Reflection.MethodBase.GetCurrentMethod().Name} ()");


        // load level, player, and ui
        GameObject background = OmniFac.CreateBackground();
        GameUI.ChangeOrientation(UserPreferences.GetOrientation());

        GameInput = GameInputAlphabet.LevelLoaded;
        EndStateMethod();
    }

    private void EndStateMethod()
    {
        _readyForTransition = true;
    }

    private void BeginStateMethod(GameState stateEntered)
    {
        _readyForTransition = false;
        GameState = stateEntered;
        GameInput = GameInputAlphabet.NoInput;
    }

    private IEnumerator PreTurn()
    {
        BeginStateMethod(GameState.PreTurn);
        print($"{System.Reflection.MethodBase.GetCurrentMethod().Name} ()");


        // call preturn observer
        Func<bool> preTurnEventsComplete = () => { return true; };
        yield return new WaitUntil(preTurnEventsComplete);
        

        GameInput = GameInputAlphabet.PreTurnComplete;
        EndStateMethod();
    }
    private void PlayerTurn()
    {
        BeginStateMethod(GameState.PlayerTurn);
        print($"{System.Reflection.MethodBase.GetCurrentMethod().Name} ()");


        EndStateMethod();
    }


    private void UsePlayerButton()
    {
        BeginStateMethod(GameState.UsePlayerButton);



        EndStateMethod();
    }
    private void Aim()
    {
        BeginStateMethod(GameState.Aiming);



        EndStateMethod();
    }
    private void Fire()
    {
        BeginStateMethod(GameState.Firing);



        EndStateMethod();
    }
    private void ReturnWeapon()
    {
        BeginStateMethod(GameState.ReturnWeapon);



        EndStateMethod();
    }
    private void PostTurn()
    {
        BeginStateMethod(GameState.PostTurn);



        EndStateMethod();
    }
    private void Won()
    {
        BeginStateMethod(GameState.Win);



        EndStateMethod();
    }
    private void Lost()
    {
        BeginStateMethod(GameState.Lose);



        EndStateMethod();
    }



    public void Inject(GameUI gameUI, OmniFac omniFac)
    {
        GameUI = gameUI;
        OmniFac = omniFac;
    }

}
