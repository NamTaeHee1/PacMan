using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Transform PlayerTransform = null;

    private float MoveSpeed = 3.0f;

    private void Start()
    {
        PlayerTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        PlayerTransform.Translate(new Vector2(h, v) * Time.deltaTime * MoveSpeed);
    }
}
