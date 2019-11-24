using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLifetime : MonoBehaviour {

    public float lifetime = 5f;

    float elapsedTime;

    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > lifetime)
            Destroy(gameObject);
    }
}
