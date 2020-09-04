using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Responsible for the players in the game.!-- Derives from the singleton 
/// base class so be careful.
///</summary>
public class PlayerManager : Singleton<PlayerManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

}
