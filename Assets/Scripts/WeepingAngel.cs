using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WeepingAngel : MonoBehaviour
{
    public float speed;
    public float[] distance;

    private float elapsedTime;
    bool CheckObjectIsInCamera()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }

    void Start()
    {
        elapsedTime = 0;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (!CheckObjectIsInCamera() && elapsedTime > 1)
        {
            Transform playerTransform = Player.instance.transform;
            transform.position = playerTransform.position - playerTransform.forward * 1.0f;
            transform.position.Set(transform.position.x, transform.position.y, transform.position.z);
            transform.LookAt(Player.instance.transform);
            elapsedTime = 0;
        }
    }
}
