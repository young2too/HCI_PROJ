using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_room_in : MonoBehaviour
{
    GameObject floating_board;
    GameObject floating_board2;
    GameObject room_in;
    GameObject room_out;

    bool player_in = false;
   

    // Start is called before the first frame update
    void Start()
    {
        room_in = GameObject.Find("Flash_light_room_in") as GameObject;
        room_out = GameObject.Find("Flash_light_room_out") as GameObject;
        floating_board = GameObject.Find("Floating Cube") as GameObject; 
        floating_board2 = GameObject.Find("Floating Cube2") as GameObject;
        floating_board.SetActive(false);
        floating_board2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Player")) {
            floating_board.SetActive(true);
            floating_board2.SetActive(true);
            room_out.SetActive(true);
            room_in.SetActive(false);
        }
    }
}
