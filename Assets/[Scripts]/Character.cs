using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField]
    [Range(0, 10)]
    float speed = 10.0f;

    //public float xMax;
    //public float xMin;
    //public float yMax;
    //public float yMin;

    //float xpos;
    //float ypos;

    [SerializeField]
    Rigidbody2D rd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //xpos = transform.position.x;
        //ypos = transform.position.y;

    }

    private void FixedUpdate()
    {
        //CheckBounds();

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector3 currentPos = transform.position;
        //transform.position = currentPos + new Vector3(inputX, inputY, 0) * speed * Time.deltaTime;

        //rd.velocity = new Vector3(inputX, inputY, 0) * speed; 
        //Either works, I liked more the commented one, should be added on fixedUpdate
        rd.MovePosition(currentPos + new Vector3(inputX, inputY, 0) * speed * Time.deltaTime);
    }

    //void CheckBounds()
    //{
    //    if (transform.position.x > xMax)
    //    {
    //        transform.position = new Vector2(xMax, ypos);
    //    }
    //    if (transform.position.x < xMin)
    //    {
    //        transform.position = new Vector2(xMin, ypos);
    //    }
    //    if (transform.position.y > yMax)
    //    {
    //        transform.position = new Vector2(xpos, yMax);
    //    }
    //    if (transform.position.y < yMin)
    //    {
    //        transform.position = new Vector2(xpos, yMin);
    //    }
    //}
}
