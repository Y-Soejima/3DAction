using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] string informationText;
    [SerializeField] Text information;
    [SerializeField] AudioClip selectSound;
    //[SerializeField] AudioClip submitSound;
    [SerializeField] AudioClip ExitSound;
    AudioSource buttonSoundSource;

    private void Start()
    {
        buttonSoundSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// ボタンが選択されたときに呼ぶ
    /// </summary>
    public void OnSelected()
    {
        buttonSoundSource?.PlayOneShot(selectSound);
        information.text = informationText;
    }

    /// <summary>
    /// ボタンから選択が外れたときに呼ぶ
    /// </summary>
    public void DeSelected()
    {
        information.text = "";
    }

    /// <summary>
    /// ボタンを押したときウィンドウを遷移させる
    /// </summary>
    /// <param name="window">遷移させるウィンドウ</param>
    public void TransitionWindow(GameObject window)
    {
        MenuController.FindObjectOfType<MenuController>().ChangeWindow(window);
    }


    /// <summary>
    /// メニュー画面を閉じる
    /// </summary>
    public void CloseWindow()
    {
        buttonSoundSource.PlayOneShot(ExitSound);
        MenuController.FindObjectOfType<MenuController>().MenuScreen();
    }
}

