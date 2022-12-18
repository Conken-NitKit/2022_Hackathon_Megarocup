using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int PieceNo = 0;
    private bool Clear;
    public static int ClearPiece;

    [SerializeField]
    private Vector2 offset = new Vector2(1f,0.31f);
    
    private Vector2[] PiecePos = new Vector2[28];

    [SerializeField]
    private float posX = -5.85f;
    [SerializeField]
    private float posY = 2.47f;
    [SerializeField]
    private float posfarX = 2f;
    [SerializeField]
    private float posfarY = 0.62f;
	// Use this for initialization
	void Start () 
    {
        Clear = false;
        
        for(int i=0;i<28;i++)
        {
            PiecePos[i] = new Vector2(posX + posfarX*(i%3) , posY - posfarY*(i/3));
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(GetTweet.Tweet);
        Debug.Log(Clear);
        this.transform.SetSiblingIndex(99);
        Vector3 TapPos = Input.mousePosition;
        TapPos.z = 5f;
        transform.position = Camera.main.ScreenToWorldPoint(TapPos);
    }

    // ドラッグ開始時に呼び出されるメソッド
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Clear)
        {
            Clear = false;
            ClearPiece -= 1;
            Debug.Log(Clear);
        }
        Debug.Log(ClearPiece);
    }

    // ドラッグ終了時に呼び出されるメソッド
    public void OnEndDrag(PointerEventData eventData)
    {
        //ドロップ時のピースのｘｙ座標を取得
        float objx = this.transform.localPosition.x;
        float objy = this.transform.localPosition.y;

        //ポジションからのオフセット
        float leftx = PiecePos[PieceNo].x - offset.x;
        float rightx = PiecePos[PieceNo].x + offset.x;
        float upy = PiecePos[PieceNo].y + offset.y;
        float downy = PiecePos[PieceNo].y - offset.y;

        //ポジションからオフセット内にドロップされたかの判定
        if (leftx <= objx && objx<=rightx)
        {
            if (upy >= objy && objy >= downy)
            {
                this.transform.SetSiblingIndex(0);
                this.transform.localPosition = new Vector3(PiecePos[PieceNo].x, PiecePos[PieceNo].y, 0);
                Clear = true;
                ClearPiece += 1;
                Debug.Log(Clear);
                Debug.Log(ClearPiece);
            }
        }
    }
}
