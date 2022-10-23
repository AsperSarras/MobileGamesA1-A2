/*
 * GameSingleton
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Holds data that needs to go through scenes
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    public static GameSingleton Instance { get; private set; }

    public int _enemiesLeft;
    public int _round = 1;
    public bool _roundFinished;
    public int _money = 60;
    public int _hp = 10;
    public int _enemiesDefeated;





    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}