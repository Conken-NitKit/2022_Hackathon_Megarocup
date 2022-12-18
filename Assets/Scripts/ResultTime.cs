using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour
{
    //結果時間
    [SerializeField]
    private Text ResultTimeText;

    //はめたピース数
    [SerializeField]
    private Text ResultPieceText;

    void Start()
    {
        Drag.ClearPiece = 0;
    }

    void Update()
    {
        
        ResultTimeText.text =$"記録 {GoResult.min}:{GoResult.seconds/10}{GoResult.seconds%10}";
        ResultPieceText.text =$"×{GoResult.PieceMax}";
    }
}
