using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    [SerializeField] Canvas menu;
    [SerializeField] GameObject[] windowLists;
    // Start is called before the first frame update
    void Start()
    {
        menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            MenuScreen();
        }
    }

    public void ChangeWindow(GameObject window)
    {
        foreach (var item in windowLists)
        {
            if (item == window)
            {
                item.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
            }
            else
            {
                item.SetActive(false);
            }
            //　それぞれのウインドウのMenuAreaの最初の子要素をアクティブな状態にする
            EventSystem.current.SetSelectedGameObject(window.transform.Find("MenuArea").GetChild(0).gameObject);
        }
    }

    /// <summary>
    /// メニュー画面の表示
    /// </summary>
    public void MenuScreen()
    {
        menu.gameObject.SetActive(!menu.gameObject.activeSelf);
        Time.timeScale = menu.gameObject.activeSelf ? 0 : 1;
        ChangeWindow(windowLists[0]);
    }
}
