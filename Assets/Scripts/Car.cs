using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject touch = collision.gameObject; //lay vat xe vua moi dung
        string touchName = touch.name;
        if (!(touchName.Contains("Road") && touchName.Contains("Grass") && touchName.Contains("Sidewalk")))
        {

        }
    }
}
