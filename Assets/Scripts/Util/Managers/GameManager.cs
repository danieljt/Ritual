using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// The Gamemanager lives for the whole duration of the game session and keeps track of 
/// important features that need to persist between scenes. Because this class is Deriving 
/// from the singleton baseclass it is important to know the issues and drawbacks of the singleton pattern.
///</summary>
[RequireComponent(typeof(Animator))]
public class GameManager : Singleton<GameManager>
{   
    // We use an animator state machine as a logic state machine for the game manager
    // game states. This avoids the use of meaningless switch statements and 
    // cumbersome enums. Does take a bit of resources though, but we can manage.
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }
}
