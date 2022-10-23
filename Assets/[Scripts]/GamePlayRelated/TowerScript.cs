/*
 * TowerScript
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Manage Towers. set the target, has the bullet and trigger the attack function and its cd.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject _target;
    public GameObject _bullet;
    public BulletScript _bulletScript;
    public bool _canShoot = true;
    public float _atk;
    public float _cd;
    public int _cost;
    public string _ability;
    float timer = 0;

    //for DualTypeOnly
    public GameObject _target2;
    float timer2 = 0;
    public bool _canShoot2 = true;

    public TowerEnum Type;



    // Start is called before the first frame update
    void Start()
    {
        _bulletScript = _bullet.GetComponent<BulletScript>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(_canShoot == false)
        {
            timer += Time.deltaTime;
            if(timer>_cd)
            {
                _canShoot = true;
                timer = 0;
            }
        }
        else if(_target != null)
        {
            Shoot(_target);
            _canShoot = false;
        }

        if (Type == TowerEnum.DUAL)
        {
            Debug.Log("Dual Pass");
            if (_canShoot2 == false)
            {
                Debug.Log("Cant Shoot");
                timer2 += Time.deltaTime;
                if (timer2 > _cd)
                {
                    Debug.Log("Reset");
                    _canShoot2 = true;
                    timer2 = 0;
                }
            }
            else if (_target2 != null)
            {
                Debug.Log("Shoot");
                Shoot(_target2);
                _canShoot2 = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_target == null)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("TargetGet");
                _target = collision.gameObject;
            }
        }
        if(Type == TowerEnum.DUAL)
        {
            if(_target2 == null)
            {
                if (collision.gameObject.tag == "Enemy" && collision.gameObject != _target)
                {
                    Debug.Log("TargetGet2");
                    _target2 = collision.gameObject;
                }
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("TargetLost");
        _target = null;
      
        if (Type == TowerEnum.DUAL)
        {
            if (collision.gameObject == _target2)
            {
                _target2 = null;
            }
        }


    }
    public void Shoot(GameObject destination)
    {
        _bulletScript._destination = destination;
        Instantiate(_bullet, this.transform.position, Quaternion.identity);
    }

}
