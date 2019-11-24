using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject == Player.instance.gameObject)
            Overmind.instance.WinGame();
    }
}
