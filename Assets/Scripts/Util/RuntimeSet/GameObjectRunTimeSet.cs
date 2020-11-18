using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// A runtime set for the players in the game. From this runtimeset
/// other gamobjects and scripts can fetch the players and
/// use them. Great for decoupling the player from the HUD, gamemanager,
/// scenemanager and enemies.
///</summary>
public class GameObjectRunTimeSet : RuntimeSet<GameObject>
{

}
