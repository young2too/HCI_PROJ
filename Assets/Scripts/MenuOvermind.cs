using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOvermind : MonoBehaviour {

    void Update() {
        if (Input.anyKeyDown && !Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("new_MAZE");
    }
}
