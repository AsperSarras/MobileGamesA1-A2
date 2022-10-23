/*
 * TeleporterScript
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Enable/Disable the teleporters and give the info to the interactive menu for it to know what Teleporter the player is trying to use
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public GameObject _interactiveManager;
    public InteractiveMenuManager _interactiveManaggerScript;

    // Start is called before the first frame update
    void Start()
    {
        _interactiveManaggerScript = _interactiveManager.GetComponent<InteractiveMenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _interactiveManaggerScript.SetActiveMenu(_interactiveManaggerScript.TeleportMenu);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _interactiveManaggerScript.SetActiveMenu(null);
        }
    }
}
