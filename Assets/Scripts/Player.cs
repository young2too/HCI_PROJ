using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

    public static Player instance { get; private set; }

    public int noiseLevel;

    void Awake() {
        instance = this;
    }

    void LateUpdate() {
        noiseLevel = GetComponent<FirstPersonController>().noiseLevel;
    }
}
