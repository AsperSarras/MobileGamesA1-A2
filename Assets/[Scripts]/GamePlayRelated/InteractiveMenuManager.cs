/*
 * InteractiveMenuManager
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Used to manage the Interactive menu by hanging menus 
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveMenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject TeleportMenu;
    public GameObject constMenu;
    public GameObject EndButtonMenu;
    public GameObject ConfirmMenu;

    public GameObject ActiveMenu;

    public GameObject SelectedTower;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveMenu(GameObject newMenu)
    {
        if (ActiveMenu != null)
        {
            ActiveMenu.SetActive(false);
            ActiveMenu = null;
        }

        ActiveMenu = newMenu;
        ActiveMenu.SetActive(true);

    }

    public void SetActiveMenu(GameObject newMenu, GameObject constTile) // for tower selection
    {
        if (ActiveMenu != null)
        {
            ActiveMenu.SetActive(false);
            ActiveMenu = null;
            if(SelectedTower != null)
            {
                SelectedTower = null;
            }    
        }

        ActiveMenu = newMenu;
        Debug.Log("Tower Name: " + constTile.name);
        ActiveMenu.SetActive(true);
        SelectedTower = constTile;
    }

    public void SetActiveMenu(GameObject newMenu, int i) // in and of confirm menu
    {
        ActiveMenu.SetActive(false);
        ActiveMenu = null;

        ActiveMenu = newMenu;
        var ConfirmScript = newMenu.GetComponent<ConfirmMenuScript>();
        ConfirmScript._towerIndex = i;
        ActiveMenu.SetActive(true);

    }


    public void ConstructTowerManager(int i)
    {
        ConsTiles script = SelectedTower.GetComponent<ConsTiles>();
        script.ConstructTower(i);
    }

}
