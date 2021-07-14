using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private LayerMask TileLayer;

    private float rayDistance = 0.55f;
    private float MoveSpeed = 3.0f;

    DirectionEnum State = DirectionEnum.Down;

    private Animator EnemyAnimator;

    Vector2 Direction = Vector2.zero;

    private void Awake()
    {
        EnemyAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        TileLayer = LayerMask.GetMask("Tile");
        GetRandomDirection();
    }

    private void FixedUpdate()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, rayDistance, TileLayer);

        if (hit.transform == null)
        {
            transform.Translate(Direction * MoveSpeed * Time.deltaTime);
            EnemyChangeAnimation();
        }
        else
            GetRandomDirection();
    }

    private void EnemyChangeAnimation()
    {
        EnemyAnimator.SetInteger("DirectionEnumValue", (int)State);
    }

    private void GetRandomDirection()
    {
        Direction = Vector2.zero;
        if (State == DirectionEnum.Up || State == DirectionEnum.Down)
            State = (DirectionEnum)Random.Range(0, 2);
        else if (State == DirectionEnum.Left || State == DirectionEnum.Right)
            State = (DirectionEnum)Random.Range(2, 4);
        switch (State)
        {
            case DirectionEnum.Left:
                Direction = Vector2.left;
                break;
            case DirectionEnum.Right:
                Direction = Vector2.right;
                break;
            case DirectionEnum.Down:
                Direction = Vector2.down;
                break;
            case DirectionEnum.Up:
                Direction = Vector2.up;
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("MapPassage"))
        {
            transform.position = collision.transform.GetChild(0).transform.position;
            Debug.Log("fweuf");
        }
    }
}
