/*
 * InstructionManager
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Goes through the different instructions menus
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    public List<GameObject> Menus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveInstMenu(int i)
    {
        gameObject.SetActive(true);
        Menus[i].SetActive(true);
    }

    public void Backmenu(int i)
    {
        gameObject.SetActive(false);
        Menus[i].SetActive(false);
    }

}
