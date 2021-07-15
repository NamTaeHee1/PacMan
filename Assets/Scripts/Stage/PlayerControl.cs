using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Transform PlayerParent = null;
    private Transform PlayerTransform = null;

    private SpriteRenderer PlayerSpriteRender = null;
    [SerializeField] private SpriteRenderer[] SelectButtonImages = null;
    
    private Animator PlayerAnimator = null;

    [SerializeField] private PlayerControl pc;

    [SerializeField] private TextMeshProUGUI GameOverText;

    private float MoveSpeed = 3.0f;
    float h, v = 0;

    private void Awake()
    {
        PlayerTransform = GetComponent<Transform>();
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
    }

    private void PlayerMove()
    {
        PlayerAnimator.SetBool("isMove", (h != 0 || v != 0));
        PlayerParent.Translate(new Vector2(h, v) * Time.deltaTime * MoveSpeed);
    }

    public void InputButtonDown()
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.name.Replace("Button", "");
        PlayerTransform.eulerAngles = Vector3.zero;

        if (ButtonName.Equals("Right") || ButtonName.Equals("Left"))
        {
            h = ButtonName.Equals("Right") ? 1f : -1f;
            PlayerTransform.eulerAngles = new Vector3(0, 0, (h == 1) ? 0f : 180f);
        }
        else if (ButtonName.Equals("Up") || ButtonName.Equals("Down"))
        {
            v = ButtonName.Equals("Up") ? 1f : -1f;
            PlayerTransform.eulerAngles = new Vector3(0, 0, v * 90);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("MapPassage"))
            PlayerTransform.position = collision.gameObject.transform.GetChild(0).transform.position;
        if(collision.gameObject.name.Equals("SmallBallon") || collision.gameObject.name.Equals("BigBallon"))
        {
            collision.gameObject.SetActive(false);
            //Point ¿Ã¸®±â
        }

        if(collision.gameObject.name.Equals("Enemy"))
        {
            GameOverText.gameObject.SetActive(true);
            pc.enabled = false;
            Invoke("BackToMain", 3.0f);
        }
    }

    private void BackToMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}
