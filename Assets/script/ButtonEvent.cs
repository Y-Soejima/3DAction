using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] string informationText;
    [SerializeField] Text information;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ボタンが選択されたときに呼ぶ
    /// </summary>
    public void OnSelected()
    {
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
        MenuController.FindObjectOfType<MenuController>().MenuScreen();
    }
}

