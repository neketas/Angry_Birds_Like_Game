using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public void StartButton()
    {
        string startLevel = "Level1";
        SceneManager.LoadScene(startLevel);
    }
}
