/*
 * GameOverManager
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Updates Ends Scene scores
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text _LifeText;
    public TMP_Text _RoundText;
    public TMP_Text _EnemiesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _LifeText.text = GameSingleton.Instance._hp.ToString();
        _RoundText.text = GameSingleton.Instance._round.ToString();
        _EnemiesText.text = GameSingleton.Instance._enemiesDefeated.ToString();
    }
}
