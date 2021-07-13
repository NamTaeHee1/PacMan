using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Transform PlayerParent = null;

    private SpriteRenderer PlayerSpriteRender = null;
    [SerializeField] private SpriteRenderer[] SelectButtonImages = null;
    
    private Animator PlayerAnimator = null;

    private float MoveSpeed = 3.0f;
    float h, v = 0;

    private void Awake()
    {
        PlayerSpriteRender = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayerSpriteRender.color = DanielLochner.Assets.SimpleScrollSnap.StoreManager.CharacterColor.SpriteColor;
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerRotate();
    }

    private void PlayerMove()
    {
        PlayerAnimator.SetBool("isMove", (h != 0 || v != 0));
        PlayerParent.Translate(new Vector2(h, v) * Time.deltaTime * MoveSpeed);
    }

    private void PlayerRotate()
    {
        
    }

    public void InputButtonDown()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name.Replace("Button", "");

        if (ButtonName.Equals("Right") || ButtonName.Equals("Left"))
        {
            h = ButtonName.Equals("Right") ? 1f : -1f;
        }
        else if (ButtonName.Equals("Up") || ButtonName.Equals("Down"))
        {
            v = ButtonName.Equals("Up") ? 1f : -1f;
        }

        for(int i = 0; i < SelectButtonImages.Length; i++)
        {
            if(SelectButtonImages[i].transform.parent.transform.parent.gameObject.ToString().Contains(ButtonName))
                SelectButtonImages[i].color = new Color32(32, 32, 255, 255);
        }
    }

    public void InputButtonUp()
    {
        for (int i = 0; i < SelectButtonImages.Length; i++)
            SelectButtonImages[i].color = Color.white;
        h = 0;
        v = 0;
    }


}
