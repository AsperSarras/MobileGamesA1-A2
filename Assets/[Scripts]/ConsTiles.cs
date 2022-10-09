using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConsTiles : MonoBehaviour
{

    public ConsTiles tile;
    public CircleCollider2D sc;

    // Start is called before the first frame update
    void Start()
    {
        tile = GetComponent<ConsTiles>();
        sc = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log(gameObject.name + " Player has enter");
        }
    }

}
