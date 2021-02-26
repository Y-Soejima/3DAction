using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] Canvas menu;
    [SerializeField] GameObject[] windowLists;
    [SerializeField] AudioClip submitSound;
    [SerializeField] AudioClip openMenu;
    [SerializeField] AudioClip closeMenu;
    AudioSource buttonSoundSource;
    // Start is called before the first frame update
    void Start()
    {
        buttonSoundSource = GetComponent<AudioSource>();
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
            buttonSoundSource?.PlayOneShot(submitSound);
        }
    }

    /// <summary>
    /// メニュー画面の表示
    /// </summary>
    public void MenuScreen()
    {
        menu.gameObject.SetActive(!menu.gameObject.activeSelf);
        buttonSoundSource.PlayOneShot(menu.gameObject.activeSelf ? openMenu : closeMenu);
        Time.timeScale = menu.gameObject.activeSelf ? 0 : 1;
        ChangeWindow(windowLists[0]);
    }
}
