using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorManager : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private UnityEvent OnDeathInput;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnDamage()
    {
        _animator.SetBool("isHurt", true);
    }

    public void OnDeathEvent()
    {
        _animator.SetBool("isDead", true);
        OnDeathInput?.Invoke();
    }

    public void OnAttack()
    {
        _animator.SetBool("isAttack", true);
    }

    public void ResetHurt()
    {
        _animator.SetBool("isHurt", false);
    }

    public void ResetAttack()
    {
        _animator.SetBool("isAttack", false);
    }
}
