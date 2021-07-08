using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Transform PlayerTransform = null;

    private float MoveSpeed = 3.0f;
    float h, v = 0;

    private void Start()
    {
        PlayerTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        PlayerTransform.Translate(new Vector2(h, v) * Time.deltaTime * MoveSpeed);
    }

    public void GetInputValue()
    {

    }
}
