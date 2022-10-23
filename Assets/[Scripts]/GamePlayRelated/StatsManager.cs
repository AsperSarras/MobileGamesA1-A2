/*
 * StatsManager
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Updates the ui based on the singleton and plays the background music
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public TMP_Text _LifeText;
    public TMP_Text _RoundText;
    public TMP_Text _EnemiesText;
    public TMP_Text _GoldText;

    public AudioSource _bg;

    // Start is called before the first frame update
    void Start()
    {
        _bg.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _LifeText.text = GameSingleton.Instance._hp.ToString();
        _RoundText.text = GameSingleton.Instance._round.ToString();
        _EnemiesText.text = GameSingleton.Instance._enemiesLeft.ToString();
        _GoldText.text = GameSingleton.Instance._money.ToString();
    }
}
