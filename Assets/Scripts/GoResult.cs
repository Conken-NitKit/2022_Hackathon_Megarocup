using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoResult : MonoBehaviour
{
    //ピースの個数を取得する変数
    public static int PieceMax = 30;

    [SerializeField]
    private Text timerText;

    //経過時間 
    public float totalTime;

    //秒
    public static int seconds;
    
    //分
    public static int min; 

    void Start()
    {
        totalTime = 0f;
        seconds = 0;
        min = 0;
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        totalTime += Time.deltaTime;
        seconds = (int)totalTime;
        if(seconds>=60)
        {
            seconds = 0;
            min++; 
        }
		timerText.text = $"{min}:{seconds}";

        if(Drag.ClearPiece >= PieceMax)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("Result");

        }
    }
}
