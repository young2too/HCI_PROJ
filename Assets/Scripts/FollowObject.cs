using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

    public Transform followedObject;
    public bool follow_X;
    public bool follow_Y;
    public bool follow_Z;
    public Vector3 offset;

    void LateUpdate() {
        Vector3 position = transform.position;
        if (follow_X) position.x = followedObject.position.x + offset.x;
        if (follow_Y) position.y = followedObject.position.y + offset.y;
        if (follow_Z) position.z = followedObject.position.z + offset.z;
        transform.position = position;
    }
}
