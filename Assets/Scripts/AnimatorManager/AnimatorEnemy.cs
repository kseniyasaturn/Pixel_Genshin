using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorEnemy : MonoBehaviour
{
    private Animator _animator;
 
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

   
    public void OnAttack()
    {
        _animator.SetBool("isAttack", true);
    }

   

    public void ResetAttack()
    {
        _animator.SetBool("isAttack", false);
    }
}
