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

    void start()
    {
        ResultTimeText.text =$"記録 {GoResult.min}:{GoResult.seconds}";
        ResultPieceText.text =$"×{GoResult.PieceMax}";
    }
}
