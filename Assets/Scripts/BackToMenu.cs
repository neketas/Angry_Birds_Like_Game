using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public void BackToMenuButton()
    {
        string Menu = "Level0";
        SceneManager.LoadScene(Menu);
    }
}
