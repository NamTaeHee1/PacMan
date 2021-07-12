using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtonControl : MonoBehaviour
{
    TextMeshProUGUI ClickButtonText;
    public void ClickGameStart()
    {
        SceneManager.LoadScene("StageScene");
    }

    public void ClickStore()
    {
        FindObjectOfType<DanielLochner.Assets.SimpleScrollSnap.StoreManager>().CharacterScrollSnapUpdate();
    }

    public void ClickQuit()
    {
        Application.Quit();
    }

    public void ChangeTextColor()
    {
        ClickButtonText = EventSystem.current.currentSelectedGameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        switch(ClickButtonText.name.ToString().Replace("Text", ""))
        {
            case "Start":
                ClickButtonText.color = Color.yellow;
                break;
            case "Store":
                ClickButtonText.color = Color.green;
                break;
            case "Setting":
                ClickButtonText.color = Color.blue;
                break;
            case "Quit":
                ClickButtonText.color = Color.red;
                break;
        }
    }

    public void ResetTextColor()
    {
        ClickButtonText.color = Color.white;
    }
}
