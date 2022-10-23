/*
 * ConfirmMenuScript
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Displays the data of the tower based on the one choosed from the construction menu, also allowes to construct it or go back.
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmMenuScript : MonoBehaviour
{
    public int _towerIndex;
    public List<GameObject> _towerList;
    public GameObject _interactiveManager;
    public InteractiveMenuManager _interactiveManagerScript;
    public TowerScript _towerScript;

    public Button _acceptButton;

    public TMP_Text atk;
    public TMP_Text atkRate;
    public TMP_Text cost;
    public TMP_Text ability;


    public GameObject _constructionMenu;

    // Update is called once per frame

    void Start()
    {
        _interactiveManagerScript = _interactiveManager.GetComponent<InteractiveMenuManager>();
    }

    void Update()
    {
        _towerScript = _towerList[_towerIndex].GetComponent<TowerScript>();
        atk.text = "Atk:" + _towerScript._atk.ToString() + ".";
        atkRate.text = "AtkRate:" + _towerScript._cd.ToString() + ".";
        cost.text = "Cost:" + _towerScript._cost.ToString() + ".";
        ability.text = "Ability: " + _towerScript._ability + ".";

        if (_towerScript._cost > GameSingleton.Instance._money)
        {
            _acceptButton.interactable = false;
        }
        else
        {
            _acceptButton.interactable = true;
        }

    }

    public void Accept()
    {
        GameSingleton.Instance._money -= _towerScript._cost;
        _interactiveManagerScript.ConstructTowerManager(_towerIndex);
        _interactiveManagerScript.SetActiveMenu(_constructionMenu);
    }

    public void Cancel()
    {
        _interactiveManagerScript.SetActiveMenu(_constructionMenu);
    }

}
