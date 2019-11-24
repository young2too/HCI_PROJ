using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_trap : MonoBehaviour
{
    GameObject[] Teleport_positons;

    bool isdeactivated = false;

    void toggle_dectvation() {
        isdeactivated = !isdeactivated;
    }

    // Start is called before the first frame update
    void Start()
    {
        Teleport_positons = new GameObject[10];
        for(int i = 0; i <= 9; i++) {
            Teleport_positons[i] = GameObject.Find("TeleportPoint" + i);
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        int random_index = (int)Random.Range(0, 9.9f);
        if (other.CompareTag("Player")) {
            if(isdeactivated == false) {
                Debug.Log("come here! ontrigger enter");
                other.GetComponent<Transform>().SetPositionAndRotation
                    (Teleport_positons[random_index].GetComponent<Transform>().position
                    ,new Quaternion());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
