using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        transform.Translate(Vector2.right * -speed * Time.deltaTime);
        
        if(transform.position.x < -30)
            Destroy(gameObject);
    }
}
