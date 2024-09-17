using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{ 
    [SerializeField] float leftLimit = -60f;
    [SerializeField] float rightLimit = 60f;
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= leftLimit)
        {
            transform.position = new Vector3(rightLimit, transform.position.y, transform.position.z);
        }
    }
}