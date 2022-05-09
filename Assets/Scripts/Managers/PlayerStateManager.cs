using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public enum PlayerStates { Idle, Run, Chop, Mine }
    public PlayerStates playerState;
    public bool isGameEnded;
    private Rigidbody playerRB;

    #region Singleton

    private static PlayerStateManager _instance;

    public static PlayerStateManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<PlayerStateManager>();
            return _instance;
        }
    }
    #endregion

    private void OnEnable()
    {
        EventManager.onGameStart += GameStarted;
        EventManager.onEndGameEvent += onEndGame;

    }
    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void OnDisable()
    {
        EventManager.onGameStart -= GameStarted;
        EventManager.onEndGameEvent -= onEndGame;
    }

    void GameStarted()
    {
        if (!isGameEnded)
        {
            playerState = PlayerStates.Idle;
        }
    }

    void onEndGame()
    {
        if (!isGameEnded)
        {
            playerState = PlayerStates.Idle;
        }
    }



}


