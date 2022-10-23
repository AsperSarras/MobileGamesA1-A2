/*
 * ConstructionScript
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Used to manage the construction menu, pass info to the confirm menu and enables the end game button once you reach round 10
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionScript : MonoBehaviour
{
    public GameObject _interactiveMenuManager;
    public InteractiveMenuManager _menuManagerScript;
    public GameObject _confirmMenu;

    public Button endGame;



    private void Start()
    {
        _menuManagerScript = _interactiveMenuManager.GetComponent<InteractiveMenuManager>();    
    }

    private void Update()
    {
        if (GameSingleton.Instance._round > 10)
        {
            endGame.interactable = true;
        }
    }

    public void ConfirmTower(int i)
    {
        _menuManagerScript.SetActiveMenu(_confirmMenu, i);
    }


}
