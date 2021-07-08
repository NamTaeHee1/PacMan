using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        string ButtonName = EventSystem.current.currentSelectedGameObject.name.Replace("Button", "");

        if (ButtonName.Equals("Right") || ButtonName.Equals("Left"))
            h = ButtonName.Equals("Right") ? 1f : -1f;
        if (ButtonName.Equals("Up") || ButtonName.Equals("Down"))
            v = ButtonName.Equals("Up") ? 1f : -1f;
    }
}
