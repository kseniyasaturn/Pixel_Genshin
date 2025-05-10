using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour 
{
    [SerializeField] private float fireSpeed;
    private Rigidbody2D currentBullet;

    private void Awake()
    {
        currentBullet = GetComponent<Rigidbody2D>();       
    }

    public void SetDirection(bool isRight)
    {
        float direction = isRight ? 1 : -1;
        currentBullet.velocity = new Vector2(fireSpeed * direction, 0);
    }
}


