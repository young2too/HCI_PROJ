using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timetext : MonoBehaviour
{

    GameObject floating_board2;
    // Start is called before the first frame update
    void Start()
    {
        floating_board2 = GameObject.Find("Floating Cube2") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        string text = "Escape from this maze\nTime limit : ";
        string time_text = Overmind.instance.remain_time;

        text += time_text;
        floating_board2.GetComponent<TextMesh>().text = text;
    }
}
