/*
 * TeleportButtomScript
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Teleport the player based on the teleporter the player is trying to use.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButtomScript : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Teleport(GameObject pos)
    {
        Player.transform.position = pos.transform.position;
    }

}
