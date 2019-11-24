using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_room_out : MonoBehaviour {
    GameObject floating_board;
    GameObject floating_board2;
    GameObject room_out;
    GameObject room_in;
    
    string text = "Escape from this maze\nTime limit : ";

    // Start is called before the first frame update
    void Start() {
        room_out = GameObject.Find("Flash_light_room_out") as GameObject;
        room_in = GameObject.Find("Flash_light_room_in") as GameObject;
        floating_board = GameObject.Find("Floating Cube") as GameObject;
        floating_board2 = GameObject.Find("Floating Cube2") as GameObject;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            floating_board.SetActive(false);
            floating_board2.SetActive(false);
            room_out.SetActive(false);
            room_in.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update() {
    }
}
