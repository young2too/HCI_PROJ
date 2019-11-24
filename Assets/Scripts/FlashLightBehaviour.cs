using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightBehaviour : MonoBehaviour
{
    GameObject lightobj;
    // Start is called before the first frame update
    void Start()
    {
        lightobj = GameObject.Find("Spotlight_player") as GameObject;
        
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.F)) {
            lightobj.GetComponent<Light>().enabled 
                = !(lightobj.GetComponent<Light>().enabled);
        }
        
    }
}
