using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    [SerializeField] protected bool isJump;
    public bool IsJump { get { return isJump; } }

    [SerializeField] protected bool isStart;
    public bool IsStart { get { return isStart; } }

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Button":
                isJump = true;
                break;
            case "PlayButton":
                isStart = true;
                break;
            case "MainMenuButton":
                ChangeScene.Instance.setScene();
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Button":
                isJump = false;
                Bird.Instance.updateTime();
                break;
            case "PlayButton":
                break;
        }
    }

    protected void Awake()
    {
        InputManager.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
