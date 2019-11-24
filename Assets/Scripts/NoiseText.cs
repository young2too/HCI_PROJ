using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseText : MonoBehaviour {

    public Color[] textColors;
    GameObject lightobj;
    Text text;

    void Start() {
        text = GetComponent<Text>();
        lightobj = GameObject.Find("Spotlight_player") as GameObject;
    }

    void LateUpdate() {
        if(lightobj.GetComponent<Light>().enabled == true) {
            Player.instance.noiseLevel += 1;
            if (Player.instance.noiseLevel > 3)
                Player.instance.noiseLevel = 3;
        }
        int noiseLevel = Player.instance.noiseLevel;


        text.text = "Noise: ";
        if (noiseLevel == 0)
            text.text += "none";
        else if (noiseLevel == 1)
            text.text += "low";
        else if (noiseLevel == 2)
            text.text += "medium";
        else if (noiseLevel >= 3){
            noiseLevel = 3;
            text.text += "high!";
        }
        text.color = textColors[noiseLevel];
        
    }
}
