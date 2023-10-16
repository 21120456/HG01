using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    private static Score instance;
    public static Score Instance { get { return instance; } }

    [SerializeField] protected GameObject object1;
    [SerializeField] protected GameObject object2;
    [SerializeField] protected TextMeshProUGUI text1;
    [SerializeField] protected TextMeshProUGUI text2;
    [SerializeField] protected int highScore;
    [SerializeField] protected int score;

    protected void Awake()
    {
        Score.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = SaveSystem.LoadPoint();
        Bird.Instance.updatePoint(highScore);
        text1 = object1.GetComponent<TextMeshProUGUI>();
        text2 = object2.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        showScore();
    }

    protected virtual void showScore()
    {
        text1.text = "";
        text2.text = "";
        highScore = Bird.Instance.HighPoint;
        score = Bird.Instance.Point;
        for (int i = 0; i < highScore.ToString().Length; i++)
        {
            text1.text += "<sprite name=\"" + highScore.ToString()[i] + "Up\"> ";
        }
        for (int i = 0; i < score.ToString().Length; i++)
        {
            text2.text += "<sprite name=\"" + score.ToString()[i] + "Up\"> ";
        }
    }

    public void Save()
    {
        SaveSystem.SavePoint(Bird.Instance.HighPoint);
        return;
    }
}
