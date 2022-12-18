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

    [SerializeField]
    private Text pieceText;

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
            totalTime = 0f;
            min++; 
        }
		timerText.text = $"{min}:{seconds/10}{seconds%10}";
        pieceText.text = $"{Drag.ClearPiece}/{PieceMax}";

        if(Drag.ClearPiece >= PieceMax)
        {
        
            SceneManager.LoadScene("Result");

        }
    }
}
