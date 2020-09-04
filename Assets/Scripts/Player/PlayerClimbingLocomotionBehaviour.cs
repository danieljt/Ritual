using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

///<summary>
/// Locomotion for climbing behaviour. A climbable gameobject is a tilemap with a tilemap collider
/// set to trigger WITHOUT a composite collider. This is important for easier CPU time
/// and shorter raycasts. See the climbablecontroller for more information.
///</summary>
public class PlayerClimbingLocomotionBehaviour : PlayerBaseBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        MoveToTilePosition();
        body.gravityScale = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        body.velocity = new Vector2(0, playerController.movement.y*4);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        body.gravityScale = 1;
    }

    ///<summary>
    /// This method is invoked when entering te state. It is responsible for aligning the player with the center
    /// of the ladder. The ladder is assumed to be a tilemap WITHOUT the composite collider component.
    ///
    ///</summary>
    public void MoveToTilePosition()
    {   
        Tilemap tilemap = climbableController.Collider.GetComponent<Tilemap>();
        if(tilemap != null)
        {
            Grid grid = tilemap.layoutGrid;
            Vector3Int gridPosition = grid.WorldToCell(climbableController.ContactPoint);
            body.MovePosition(tilemap.GetCellCenterWorld(gridPosition));
        }       
    }
}
