using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private LayerMask TileLayer;

    private float rayDistance = 0.55f;
    private float MoveSpeed = 3.0f;

    DirectionEnum State = DirectionEnum.Right;

    Vector2 Direction = Vector2.zero;

    private void Start()
    {
        TileLayer = LayerMask.GetMask("Tile");
        GetRandomDirection();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, rayDistance, TileLayer);

        if (hit.transform == null)
        {
            transform.Translate(Direction * MoveSpeed * Time.deltaTime);
        }
        else
            GetRandomDirection();

        Debug.Log(Direction.x + ", " + Direction.y);
    }

    private void GetRandomDirection()
    {
        Direction = Vector2.zero;
        if (State == DirectionEnum.Down || State == DirectionEnum.Up)
            State = (DirectionEnum)Random.Range(2, 4);
        else if (State == DirectionEnum.Up || State == DirectionEnum.Down)
            State = (DirectionEnum)Random.Range(3, 5);
        Debug.Log(State);
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
}
