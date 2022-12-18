using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generatePiece : MonoBehaviour
{
    //ピースのプレハブ
    [SerializeField]
    private GameObject piece;
    
    //１ピース当たりの文字数
    [SerializeField]
    private int pieceSize;

    //ランダムに生成されるピースのX座標
    [SerializeField]
    private float generatePositionX;
    //ランダムに生成されるピースのX方向の間隔
    [SerializeField]
    private float transferVolumeX;
    //ランダムに生成されるピースのY座標
    [SerializeField]
    private float generatePositionY;
    //ランダムに生成されるピースのY方向の間隔
    [SerializeField]
    private float transferVolumeY;

    private GameObject pieceCanvas,pieceText;
    private string partTweet;

    private int nextStringCount = 0;

    public List<GameObject> pieces = new List<GameObject>();
    public List<Vector2> generatePositions = new List<Vector2>();

    //拾ってきた文字列を受け取る変数
    private string tweet;

    //ピースの個数
    int pieceNumber;
    //余った文字の数
    int remainCharNumber;

    void OnEnable()
    {
        StartCoroutine(Generate());

    }

        IEnumerator Generate()
        {
            yield return new WaitForSeconds(0.1f);
            tweet = GetTweet.Tweet;
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
                generatePositions.Add(new Vector2(generatePositionX + transferVolumeX*(i % 3),generatePositionY + transferVolumeY * (i/3)));
            }

            for(int i = 0;i < pieceNumber;i++)
            {
                int randomIndex = Random.Range(0, generatePositions.Count);
                pieces.Add(Instantiate(piece,generatePositions[randomIndex],Quaternion.identity));
                pieceCanvas = pieces[i].GetComponent<Transform>().transform.GetChild(0).gameObject;
                pieceText = pieceCanvas.GetComponent<Transform>().transform.GetChild(0).gameObject;
                partTweet = tweet.Substring(nextStringCount,pieceSize);
                pieceText.GetComponent<Text>().text = partTweet;
                nextStringCount += pieceSize;
                generatePositions.RemoveAt(randomIndex);
            }
        }
    
    
}
