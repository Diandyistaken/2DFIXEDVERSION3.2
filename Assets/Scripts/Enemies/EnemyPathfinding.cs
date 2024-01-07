using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private KnockBack knockback;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        knockback = GetComponent<KnockBack>();  
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        if (knockback.GettingKnockedBack) { return; }
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));

        if(moveDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDir.x>0)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;
    }


    public void StopMoving()
    {
        moveDir = Vector3.zero;
    }
}
