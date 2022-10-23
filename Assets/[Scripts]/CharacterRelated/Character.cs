/*
 * Character
 * AsperSarras
 * 101324242
 * 23/10/2022
 * Moves the character based on the touch and also plays the touch sound.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField]
    [Range(0, 10)]
    float speed = 10.0f;


    public AudioSource Click;


    [SerializeField]
    Rigidbody2D rd;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        GetMobileInput();
    }

    void GetMobileInput()
    {
        foreach (var touch in Input.touches)
        {
            Click.Play();
            var destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (destination.y > -3 && destination.y < 3.50) // to avoid moving when clicking on the interactive menu
            {
                transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * speed);
            }
        }
    }
}
