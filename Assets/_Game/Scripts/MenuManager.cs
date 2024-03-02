using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    public void OnClick_PlayBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClick_SettingBtn()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClick_QuitBtn()
    {
        Application.Quit();
    }
}
