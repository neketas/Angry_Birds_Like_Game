using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    static int levelIndex = 0;
    Enemy[] enemies;
   

    

    void OnEnable()
    {
        enemies = FindObjectsOfType<Enemy>();
    }
    void Update()
    {
        foreach(Enemy enemy in enemies)
        {
            if(enemy != null)
            return;
        }
        levelIndex++;
        string nextLevel = "Level" + levelIndex;
        SceneManager.LoadScene(nextLevel);
    }

    public void StartGame()
    {
        levelIndex++;
        string nextLevel = "Level" + levelIndex;
        SceneManager.LoadScene(nextLevel);
    }
    public void BackToMenu()
    {
        string nextLevel = "Level0";
        SceneManager.LoadScene(nextLevel);
    }
}
