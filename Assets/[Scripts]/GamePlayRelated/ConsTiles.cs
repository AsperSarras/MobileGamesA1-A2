/*
 * ConsTiles
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Used to make the interactive menu knows to what construction place the player is trying to construct on. Also the tower is constructed in this script.
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ConsTiles : MonoBehaviour
{
    public GameObject _interactiveManager;
    public InteractiveMenuManager _interactiveManaggerScript;

    public GameObject _area;
    public constAreaScript _areaScript;

    public GameObject _Button;
    public Button _buttonScript;

    //Towers
    public List<GameObject> _towerList;
    public GameObject _Tower;



    public bool _constructed = false;

    // Start is called before the first frame update
    void Start()
    {
        _interactiveManaggerScript = _interactiveManager.GetComponent<InteractiveMenuManager>();
        _areaScript = _area.GetComponent<constAreaScript>();
        _buttonScript = _Button.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_areaScript._onArea == true)
        {
            _buttonScript.interactable = true;
        }
        else
        {
            _buttonScript.interactable = false;
        }
    }

    public void TowerInteract()
    {
        _interactiveManaggerScript.SetActiveMenu(_interactiveManaggerScript.constMenu, this.gameObject);
    }

    public void ConstructTower(int i)
    {
        if (_constructed != false)
        {
            Destroy(_Tower);
            _Tower = null;
        }

        _Tower = Instantiate(_towerList[i], transform.position, Quaternion.identity);
        _Tower.transform.parent = this.transform;
        _constructed = true;
    }

}
