using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseBtn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pauseGame()
    {
        Game.Pause();
    }

    public void Continue()
    {
        Game.Continue();
    }

    public void backToMenu()
    {
        Game.Menu();
    }
}
