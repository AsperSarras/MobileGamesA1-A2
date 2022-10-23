/*
 * EnemyBehavior
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Moves the enemies through the positions on the list, destroy them and updates the singleton when defeated and scale them when the boolean is turned true
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float _hp;

    public int _goldWorth;

    public float _speed;

    public List<GameObject> _positions;
    int index = 0;
    public GameObject _spawnManager;
    public SpawnManager _spawnManagerScript;

    public bool slow = false;

    public bool scaling = false;
    public float scaleFactor = 1;


    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager");
        _spawnManagerScript = _spawnManager.GetComponent<SpawnManager>();
        
        foreach (GameObject pos in _spawnManagerScript._positions)
        {
            _positions.Add(pos);
        }

        StartCoroutine(Move(_positions[index].transform.position));

        if(scaling == true)
        {
            ScaleMonsters(scaleFactor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_hp <= 0)
        {
            Destroy(gameObject);
            GameSingleton.Instance._enemiesLeft--;
            GameSingleton.Instance._enemiesDefeated++;
            GameSingleton.Instance._money += _goldWorth;
        }
    }

    IEnumerator Move(Vector3 tPos)
    {
        Vector3 sPos = transform.position;

        //Will move towards the new position until the diference in distance is
        //less than Epsilon (The smallest value that a float can have different from zero.)
        while ((tPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            if(slow == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, tPos, _speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, tPos, (_speed * 0.5f) * Time.deltaTime);
            }
            

            yield return null;
        }

        index++;
        if(index == 12)
        {
            Destroy(gameObject);
            GameSingleton.Instance._enemiesLeft--;
            GameSingleton.Instance._hp--;
            GameSingleton.Instance._money += _goldWorth / 2;
        }
        else
        {
            StartCoroutine(Move(_positions[index].transform.position));
        }

    }

    public void ScaleMonsters(float value)
    {
        _hp += 3 * value;
        _speed += (value * 0.2f);
    }
}
