/*
 * slowZone
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Makes the Aoe from the Slow Tower set the slow bool from enemies inside the zone in order to make them slow
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowZone : MonoBehaviour
{
    public float duration;
    public float destruction;
    public float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > destruction)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            if(timer<duration)
            {
                collision.GetComponent<EnemyBehavior>().slow = true;
            }
            else if (timer>duration && timer<destruction)
            {
                collision.GetComponent<EnemyBehavior>().slow = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyBehavior>().slow = false;
        }
    }

}
