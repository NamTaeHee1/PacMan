using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    private Transform PlayerTransform = null;

    private SpriteRenderer SelectButtonImage;

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

    public void InputButtonDown()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name.Replace("Button", "");
        SelectButtonImage = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>();

        if (ButtonName.Equals("Right") || ButtonName.Equals("Left"))
        {
            h = ButtonName.Equals("Right") ? 1f : -1f;
            if (Physics2D.Raycast(transform.position, new Vector2(h, 0) * 3.0f, 1.0f, LayerMask.GetMask("Map")))
                h = 0;
        }
        else if (ButtonName.Equals("Up") || ButtonName.Equals("Down"))
        {
            v = ButtonName.Equals("Up") ? 1f : -1f;
            if (Physics2D.Raycast(transform.position, new Vector2(0, v) * 3.0f, 1.0f, LayerMask.GetMask("Map")))
                v = 0;
        }

        SelectButtonImage.color = new Color32(32, 32, 255, 255);
    }

    public void InputButtonUp()
    {
        SelectButtonImage.color = Color.white;
        h = 0;
        v = 0;
    }
}
