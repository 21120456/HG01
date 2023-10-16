using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    private static ChangeScene instance;
    public static ChangeScene Instance { get { return instance; } }


    protected void Awake()
    {
        ChangeScene.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScene()
    {
        Score.Instance.Save();
        SceneManager.LoadScene(0);
    }


    public void doExitGame()
    {
        Application.Quit();
    }
}
