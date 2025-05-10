using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 2f; 
    [SerializeField] private float moveDistance; 
    private Vector3 startPosition; 
    private Vector3 targetPosition; 
    private float journeyLength;
    private float startTime; 
    private bool movingToTarget = true; 

    void Start()
    {
        startPosition = transform.position; 
        targetPosition = startPosition + new Vector3(0, moveDistance, 0); 
        journeyLength = Vector3.Distance(startPosition, targetPosition); 
        startTime = Time.time; 
    }

    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        float elapsedTime = (Time.time - startTime) * speed; 
        float fraction = elapsedTime / journeyLength; 

        if (movingToTarget) 
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, fraction);
        }
        else 
        {
            transform.position = Vector3.Lerp(targetPosition, startPosition, fraction);
        }

        if (fraction >= 1f)
        {
            movingToTarget = !movingToTarget; 
            startTime = Time.time;
        }
    }
}

