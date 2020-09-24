using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Rotater : MonoBehaviour
{

    private Vector3 rotate;
    public float speed;

    void Update()
    {
        rotate = new Vector3(Random.Range(-10, 10), Random.Range(10,30), Random.Range(20, 30));
        transform.Rotate(rotate * Time.deltaTime * speed);
    }
}
