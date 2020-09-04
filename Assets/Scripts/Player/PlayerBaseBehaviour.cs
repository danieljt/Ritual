/*
Property of Daniel James Tarplett.
Do not redistribute without consent.
StupidGirlGames 
*/
using UnityEngine;

///<summary>
/// This is the base state from which all player states derive from. This state incorporates all
/// the important all purpose use functions and getcomponents that are common in all the
/// players states. Remember to call the base.OnStateEnter and base.OnStateExit in each derived class to get the
/// initial getcomponents and event subscribe/unsubscribe methods.
///</summary>
public class PlayerBaseBehaviour : StateMachineBehaviour
{
    #region Components 
    protected Rigidbody2D body;
    protected PlayerController2D playerController;
    protected GroundController groundController;
    protected CeilingController ceilingController;
    protected ClimbableController climbableController;
    protected Animator animator;
    #endregion

    protected bool facingRight;

    #region Hash values for anim parameters
    protected int horizontalInput;
    protected int verticalInput;
    protected int isPressingRun;
    protected int isPressingJump;
    protected int isPressingAction;
    protected int isPressingAttack;
    protected int isTouchingGround;
    protected int isTouchingCeiling;
    protected int isTouchingClimbable;
    protected int isTouchingLedge;
    protected int attackID;
    protected int horizontalSpeed;
    protected int verticalSpeed;
    #endregion

    ///<summary>
    /// This behaviour is called at the start of the statemachine behaviour. In this script, we set up all 
    /// references to the rest of the statemachine hierarchy. By doing this, we avoid using getcomponents in
    /// every statemachine enter functions. as a bonus, by deriving from this script, any scripts in a 
    /// substatemachine will call this function giving us full reuseability.
    ///</summary>
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        //GetComponents(animator);
        //SetAnimatorParameters();
    }

    ///<summary>
    /// initialize all pre state methods here. That would be getcomponents and methods for
    /// setting the players state dependent behaviour.
    ///</summary>
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // In case the statemachinebehaviour already has a reference to the components
        // we first check if it already has these before reimporting.
        if(!this.animator)
        {
            GetComponents(animator);
            SetAnimatorParameters();
        }
        
        ReadInputs();
        CheckFacing();
    }

    ///<summary>
    /// Every frame, we read the values from the player, ground, ceiling, ledge and climbable
    /// controllers. Remember to call base.OnStateUpdate on all extending classes if you
    /// want to get this functionality. 
    ///</summary>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ReadInputs();
        UpdateFacing();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ReadInputs();
    }

    ///<summary>
    /// Flip the character 180 degrees with the y axis. Remember all base rotation
    /// starts at 0 degrees when the player faces right.
    ///<summary>
    protected void Flip()
    {
        animator.gameObject.transform.Rotate(0,180f,0);
        facingRight = !facingRight;
    }

    ///<summary>
    /// Check the players facing. Should check this each time the player 
    /// transitions to a new state in case something wierd happens. Simply 
    /// takes a look at the rotation of the player gameObject and 
    /// sets the facing according to the orientation.
    ///</summary>
    protected void CheckFacing()
    {
        if(Mathf.Pow(animator.gameObject.transform.eulerAngles.y,2) > 0.1f*0.1f)
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }
    }

    ///<summary>
    /// Flip the character based on input and current facing.
    ///</summary>
    protected void UpdateFacing()
    {
        if(animator.GetFloat(horizontalInput) < 0 && facingRight || animator.GetFloat(horizontalInput) > 0 && !facingRight)
        {
            Flip();
        }
    }

    ///<summary>
    /// Get all components 
    ///</summary>
    protected void GetComponents(Animator animator)
    {
        this.animator = animator;
        body = animator.gameObject.GetComponent<Rigidbody2D>();
        playerController = animator.gameObject.GetComponent<PlayerController2D>();
        groundController = animator.gameObject.GetComponent<GroundController>();
        ceilingController = animator.gameObject.GetComponent<CeilingController>();
        climbableController = animator.gameObject.GetComponent<ClimbableController>();
    }

    ///<summary>
    /// Set all animationparameters
    ///</summary>
    protected void SetAnimatorParameters()
    {
        horizontalInput = Animator.StringToHash("horizontalInput");
        verticalInput = Animator.StringToHash("verticalInput");
        isPressingRun = Animator.StringToHash("isPressingRun");
        isPressingJump = Animator.StringToHash("isPressingJump");
        isPressingAction = Animator.StringToHash("isPressingAction");
        isPressingAttack = Animator.StringToHash("isPressingAttack");
        isTouchingGround = Animator.StringToHash("isTouchingGround");
        isTouchingCeiling = Animator.StringToHash("isTouchingCeiling");
        isTouchingClimbable = Animator.StringToHash("isTouchingClimbable");
        isTouchingLedge = Animator.StringToHash("isTouchingLedge");
        attackID = Animator.StringToHash("attackID");
        horizontalSpeed = Animator.StringToHash("horizontalSpeed");
        verticalSpeed = Animator.StringToHash("verticalSpeed");
    }

    ///<summary>
    /// Read all parameters values and set animator values
    ///</summary>
    protected void ReadInputs()
    {
        animator.SetFloat(horizontalInput, playerController.movement.x);
        animator.SetFloat(verticalInput, playerController.movement.y);
        animator.SetBool(isPressingRun, playerController.running);
        animator.SetBool(isPressingJump, playerController.jumping);
        animator.SetBool(isPressingAction, playerController.acting);
        animator.SetBool(isPressingAttack, playerController.attacking);
        animator.SetBool(isTouchingGround, groundController.isTouching);
        animator.SetBool(isTouchingCeiling, ceilingController.isTouching);
        animator.SetBool(isTouchingClimbable, climbableController.isTouching);

        animator.SetFloat(horizontalSpeed, body.velocity.x);
        animator.SetFloat(verticalSpeed, body.velocity.y);

    }
}
