using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMission : MonoBehaviour
{
    List<Vector3> places = new List<Vector3>(5);
    Vector3[] placeVector = { new Vector3(-1835.4f,0,341.6f),
        new Vector3(-1767.3f,0,287.9f),
        new Vector3(-1650.2f,0,287.9f),
        new Vector3(-1553.6f,0,237.5f),
    };
    class Place
    {
        public float x;
        public float y;
        public string name;

    };
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateMissions()
    {

    }
}
