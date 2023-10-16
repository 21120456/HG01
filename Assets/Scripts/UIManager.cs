using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] protected List<GameObject> ListObj;

    void Start()
    {
        getObj();
    }

    // Update is called once per frame
    void Update()
    {
        setUI();
    }

    protected void FixedUpdate()
    {

    }

    protected virtual void getObj()
    {
        foreach (Transform child in gameObject.transform)
        {
            ListObj.Add(child.gameObject);
        }
    }

    protected virtual void setUI()
    {
        bool isStart = InputManager.Instance.IsStart;
        bool isDead=Bird.Instance.IsDead;
        if (isDead)
        {
            foreach (GameObject child in ListObj)
            {
                switch (child.name)
                {
                    case "Button":
                        child.SetActive(false);
                        break;
                    case "Main Menu":
                        child.SetActive(false);
                        break;
                    case "Game Over":
                        child.SetActive(true);
                        break;
                }
            }
            return;
        }
        if (!isStart) return;
        foreach (GameObject child in ListObj)
        {
            switch (child.name)
            {
                case "Button":
                    child.SetActive(true);
                    break;
                case "Main Menu":
                    child.SetActive(false);
                    break;
                case "Game Over":
                    child.SetActive(false);
                    break;
            }
        }
    }
}
