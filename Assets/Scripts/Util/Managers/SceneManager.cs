using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Responsible for the scene spesific aspects of each scene like spawn locations. 
/// One of the core responsibilities of the scene manager is to make sure the game
/// manager exists. Each scene should have a scene manager gameobject with this component
/// or a child class of this component.
///</summary>
public class SceneManager : MonoBehaviour
{
    [Tooltip("The game manager prefab")]
    public GameObject gameManagerPrefab;
     
    private GameObject gameManagerGameObject;

    private void Awake()
    {
        // Instantiate the gameManager if it does not exist. Most useful in debugging from
        // the editor, but a nice security in case the gamemanager should be destroyed.
        if(!GameManager.Instance.IsInstantiated)
        {
            gameManagerGameObject = Instantiate(gameManagerPrefab);
        }
    }

    private void Start()
    {

    }
}
