using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bringer_Controller : MonoBehaviour
{
    [SerializeField] private float speed, timeToRevert;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

    private Rigidbody2D rb;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private float currentState, currentTimeToRevert;

    [SerializeField] private UnityEvent OnAttack;
    [SerializeField] private UnityEvent OnIdle;


    private void Start()
    {
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
    }

     private void Update()
    {
        if (currentTimeToRevert >= timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT_STATE;
        }
        switch(currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
                rb.velocity = Vector2.right * speed;
                break;
            case REVERT_STATE:
                sprite.flipX = !sprite.flipX;
                
                speed *= -1;
                currentState = WALK_STATE;
                break;
        }
        animator.SetFloat("Velocity", rb.velocity.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyStopper"))
            currentState = IDLE_STATE;
        if ( collision.TryGetComponent<Health>(out var health))
        {
            OnAttack?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health))
        {
            OnIdle?.Invoke();
        }
    }
}
