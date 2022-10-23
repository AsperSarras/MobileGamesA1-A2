/*
 * AoeScript
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Makes the Aoe from the Aoe Tower deals Damage
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeScript : MonoBehaviour
{
    public float destruction;
    public float timer = 0;
    public int _dmg;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > destruction)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyBehavior>()._hp -= _dmg;
        }
    }
}
