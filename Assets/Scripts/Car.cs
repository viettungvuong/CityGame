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
        Debug.Log(touch.name);
        string touchName = touch.name;
        //if (touchName != "Colliders-B" && !touchName.Contains("Colliders") && !touchName.Contains("Road") && !touchName.Contains("Grass") && !touchName.Contains("Sidewalk")) //tuc dung xe
        if (!touchName.Contains("Colliders"))
        {
            Debug.Log("Dung xe");
            Game.health -= 15; //tru di suc khoe cua xe
        }
    }
}
