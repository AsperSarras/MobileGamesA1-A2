/*
 * MyButton
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Used to for buttons that change scenes
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameMenu()
    {
        GameSingleton.Instance._round = 1;
        GameSingleton.Instance._hp = 10;
        GameSingleton.Instance._enemiesDefeated = 0;
        GameSingleton.Instance._money = 60;
        GameSingleton.Instance._roundFinished = false;


        SceneManager.LoadScene(1);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndMenu()
    {
        SceneManager.LoadScene(2);
    }
}
