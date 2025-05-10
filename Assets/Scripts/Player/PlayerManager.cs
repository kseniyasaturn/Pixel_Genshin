using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    public void MovingOff()
    {
        playerInput.enabled=false;
    }

    public void MovingOn()
    {
        playerInput.enabled = true;
    }
}
