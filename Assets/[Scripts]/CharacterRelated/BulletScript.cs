/*
 * BulletScript
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Moves the bullet to the destination, deals damage to the enemy and destroy the bullet on collision, depending on the bullet type also spawn aoe effects
*/

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float _speed;
    public float _damage;
    public GameObject _destination;
    public EnemyBehavior _enemyBehavior;
    public GameObject _aoeEffect;

    public AudioSource _hitSound;

    public TowerEnum Type;

    // Start is called before the first frame update
    void Start()
    {
        _enemyBehavior = _destination.GetComponent<EnemyBehavior>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(_destination == null)
        {
            Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, _destination.transform.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _destination)
        {
            if(Type == TowerEnum.SLOW || Type == TowerEnum.AOE)
            {
                Instantiate(_aoeEffect,collision.transform.position, Quaternion.identity);
            }
            _hitSound.Play();
            _enemyBehavior._hp -= _damage;
            Destroy(gameObject);
        }    
    }

}
