using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private LayerMask TileLayer;

    private float rayDistance = 0.55f;

    DirectionEnum State = DirectionEnum.Right;

    Vector2 Direction = Vector2.zero;

    private void Start()
    {
        TileLayer = LayerMask.GetMask("Tile");
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, rayDistance, TileLayer);
    }

    private void GetRandomDirection()
    {
        Direction = Vector2.zero;
        State = (DirectionEnum)Random.Range(0, (int)DirectionEnum.Count);

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
