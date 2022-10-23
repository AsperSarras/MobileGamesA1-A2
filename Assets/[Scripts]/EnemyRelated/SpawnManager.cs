/*
 * SpawnManager
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Spawn the rounds and modify the round count. Can randomnize the order of monsters, the full round and make the monster scale based on the numbers of rounds 
 * past round 10
*/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86.Avx;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> _enemyTypes;
    public List<GameObject> _spawnQueue;
    public GameObject _spawnPos;
    public List<GameObject> _positions;

    public int _scaling;

    public int index;
    // Start is called before the first frame update
    void Start()
    {
        FillQueue(3,0,0,0, false, false);
        StartCoroutine(SpawnEnemy());
        GameSingleton.Instance._enemiesLeft = _spawnQueue.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameSingleton.Instance._hp <= 0)
        {
            SceneManager.LoadScene(2);
        }

        if(GameSingleton.Instance._enemiesLeft == 0)
        {
            GameSingleton.Instance._round++;
            GameSingleton.Instance._roundFinished = true;
        }

        if (GameSingleton.Instance._roundFinished == true)
        {
            if (GameSingleton.Instance._round>10)
            {
                RandomRound(_scaling);
            }
            else
            {
                switch (GameSingleton.Instance._round) //keep adding lvls
                {
                    case 2:
                        FillQueue(5, 0, 0, 0, false, false);
                        break;
                    case 3:
                        FillQueue(8, 0, 0, 0, false, false);
                        break;
                    case 4:
                        FillQueue(10, 2, 0, 0, false, false);
                        break;
                    case 5:
                        FillQueue(10, 4, 0, 0, false, false);
                        break;
                    case 6:
                        FillQueue(12, 4, 2, 0, true, false);
                        break;
                    case 7:
                        FillQueue(12, 4, 4, 0, true, false);
                        break;
                    case 8:
                        FillQueue(14, 6, 4, 0, true, false);
                        break;
                    case 9:
                        FillQueue(14, 6, 4, 2, true, false);
                        break;
                    case 10:
                        FillQueue(14, 8, 6, 4, true, false);
                        break;

                }
            }
            

            GameSingleton.Instance._enemiesLeft = _spawnQueue.Count;
            StartCoroutine(SpawnEnemy());
            GameSingleton.Instance._roundFinished = false;
        }
    }

    void FillQueue(int e1, int e2, int e3, int e4, bool random, bool scaling)
    {
        for (int i = 0; i < e1; i++)
        {
            _spawnQueue.Add(_enemyTypes[0]);
        }
        for (int i = 0; i < e2; i++)
        {
            _spawnQueue.Add(_enemyTypes[1]);
        }
        for (int i = 0; i < e3; i++)
        {
            _spawnQueue.Add(_enemyTypes[2]);
        }
        for (int i = 0; i < e4; i++)
        {
            _spawnQueue.Add(_enemyTypes[3]);
        }

        if (random == true)
        {
            Randomize();
        }

        if(scaling == true)
        {
            ScalingMons(_scaling);
            _scaling++;
        }


    }

    void Randomize()
    {
        for (int i = _spawnQueue.Count; i > 1; i--)
        {
            GameObject temp;
            int _randomI = Random.Range(0, _spawnQueue.Count);

            temp = _spawnQueue[_randomI];
            _spawnQueue[_randomI] = _spawnQueue[i - 1];
            _spawnQueue[i - 1] = temp;
        }
    }

    void ScalingMons(float sc)
    {
        foreach (GameObject obj in _spawnQueue)
        {
            obj.GetComponent<EnemyBehavior>().scaleFactor = sc;
            obj.GetComponent<EnemyBehavior>().scaling = true;
        }
    }

    void RandomRound(int scaling)
    {
        int total = 20 + scaling;
        int _mons1 = Random.Range(0, total);
        total -= _mons1;
        int _mons2 = Random.Range(0, total);
        total -= _mons2;
        int _mons3 = Random.Range(0, total);
        total -= _mons3;
        int _mons4 = total;

        FillQueue(_mons1, _mons2, _mons3, _mons4, true, true);

    }

    IEnumerator SpawnEnemy()
    {
        while(index < _spawnQueue.Count)
        {
            yield return new WaitForSeconds(1f);

            Instantiate(_spawnQueue[index], _spawnPos.transform.position, Quaternion.identity);
            index++;
        }

        index = 0;

        _spawnQueue.Clear();
        StopCoroutine(SpawnEnemy());
    }

}
