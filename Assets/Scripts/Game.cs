using System.Collections;
using System.Collections.Generic;
using MTAssets.EasyMinimapSystem;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Transform player;
    static bool start = true;
    public static Transform destination;
    public static float time = 0;
    public static bool timerOn = false;
    public TMPro.TextMeshProUGUI timerShow;
    public static float health = 100; //suc khoe xe
    public Slider slider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            Place.instance.route.StopCalculatingAndHideRotesToDestination();
            start = false;
            Place.instance.getNewDestination(); //tim dia diem den moi
        }
        if (reached())
        {
            destination.GetComponent<MinimapItem>().enabled = false;
            start = true; //start cho moi
        }
        if (timerOn)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timerShow.text = "Time: " + ((int)Mathf.Round(time)).ToString() + "s";
                UpdateHealth();
                if (health <= 0)
                    Lose();
            }
            else
            {
                Lose(); //thua
                time = 0;
                timerShow.text = "Time: 0s";
                timerOn = false;
            }
        }

    }
    private void UpdateHealth()
    {
        slider.value = health;
    }
    bool reached()
    {
        if (destination == null)
            return false;
        if (Vector3.Distance(player.position, destination.position) < 5)
            return true;
        return false;
    }

    public static void Lose()
    {
        Time.timeScale = 0; //ngung game
    }
}
