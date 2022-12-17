using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル画面におけるボタンの動きを管理するクラス
/// </summary>
public class Button : MonoBehaviour
{

    [SerializeField] private Scenes scene; //ボタンを押したときシーンを遷移する
    float scaleChangeSeconds = 0.5f;
    float scaleChangeMagnification = 1.1f;
    public enum Scenes
    {
        Game,
        Sample,
        Satou,
    }

    /// <summary>
    /// ボタンがクリックされたときボタンが一瞬拡大する
    /// </summary>
    public void OnClicked()
    {
        transform.DOScale(scaleChangeMagnification,scaleChangeSeconds).SetEase(Ease.OutElastic).OnComplete(() => SceneManager.LoadScene($"{scene}"));    
    }
    
}