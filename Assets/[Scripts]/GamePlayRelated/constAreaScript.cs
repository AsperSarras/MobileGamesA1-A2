/*
 * constAreaScript
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Used by towers to see if Player is near the in order to use the interactive menu.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constAreaScript : MonoBehaviour
{
    public bool _onArea = false;
    // Start is called before the first frame update


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(gameObject.name + " Player has enter");
            _onArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(gameObject.name + " Player has left");
            _onArea = false;
        }
    }
}
