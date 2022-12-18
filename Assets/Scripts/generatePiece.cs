using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///ピースを生成しランダムに並べるクラス
///</summary>
public class generatePiece : MonoBehaviour
{
    //ピースのプレハブ
    [SerializeField]
    private GameObject piece;
    
    //１ピース当たりの文字数
    [SerializeField]
    private int pieceSize;

    //ランダムに生成されるピースのうち一番左の列のX座標
    [SerializeField]
    private float generatePositionX;
    //ランダムに生成されるピースのX方向の間隔
    [SerializeField]
    private float transferVolumeX;
    //ランダムに生成されるピースのうち一番上の行のY座標
    [SerializeField]
    private float generatePositionY;
    //ランダムに生成されるピースのY方向の間隔
    [SerializeField]
    private float transferVolumeY;

    //ピースのCanvasとTextを取得する変数
    private GameObject pieceCanvas,pieceText;
    //ツイートから切り出した文字列を入れる変数
    private string partTweet;

    private int nextStringCount = 0;

    //生成したピースを格納する配列
    public List<GameObject> pieces = new List<GameObject>();
    //ランダムにピースを生成する座標を格納する配列
    public List<Vector2> generatePositions = new List<Vector2>();

    //拾ってきた文字列を受け取る変数
    private string tweet;

    //ピースの個数
    int pieceNumber;
    //余った文字の数
    int remainCharNumber;

    void Start()
    {
        tweet = GetTweet.Tweet;
        tweet.Replace("\r"," ").Replace("\n"," ");
        pieceNumber = tweet.Length / pieceSize;
        remainCharNumber = tweet.Length % pieceSize;
        if(remainCharNumber !=0)
        {
            pieceNumber++;
            for(int i = remainCharNumber;i < pieceSize;i++)
            {
                tweet += " ";
            }

        }
        GoResult.PieceMax = pieceNumber;

        for(int i = 0;i < pieceNumber;i++)
        {
            generatePositions.Add(new Vector2(generatePositionX + transferVolumeX*(i % 3),generatePositionY - transferVolumeY * (i/3)));
        }


        for(int i = 0;i < pieceNumber;i++)
        {
            int randomIndex = Random.Range(0, generatePositions.Count);
            pieces.Add(Instantiate(piece,generatePositions[randomIndex],Quaternion.identity));
            pieceCanvas = pieces[i].GetComponent<Transform>().transform.GetChild(0).gameObject;
            pieceText = pieceCanvas.GetComponent<Transform>().transform.GetChild(0).gameObject;
            pieces[i].GetComponent<Drag>().PieceNo = i;
            partTweet = tweet.Substring(nextStringCount,pieceSize);
            pieceText.GetComponent<Text>().text = partTweet;
            nextStringCount += pieceSize;
            generatePositions.RemoveAt(randomIndex);
        }

    }
}
