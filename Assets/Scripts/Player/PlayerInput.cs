using UnityEngine;
 
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooter))]
public class PlayerInput : MonoBehaviour
{
    private Shooter shooter;
    private PlayerMovement playerMovement;  
    public class GlobalStringVars
    {
        #region Movement
        public const string HorizonalAxis = "Horizontal";
        public const string JumpAxis = "Jump";
        public const string Fire1 = "Fire1";
        public const string Reload = "Reload";
        #endregion
    }
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
    }
    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HorizonalAxis);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JumpAxis);
        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        if (Input.GetButtonDown(GlobalStringVars.Fire1))
           shooter.Shoot();
        if (Input.GetButtonDown(GlobalStringVars.Reload)) { shooter.Reload(); }
    }
}




   


