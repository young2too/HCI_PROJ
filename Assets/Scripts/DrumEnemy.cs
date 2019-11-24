using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrumEnemy : MonoBehaviour {

    public float waitTime = 10f;
    public float walkTime = 1f;
    public GameObject footprintPrefab;
    public Transform footprintContainer;
    public AudioClip[] drums;
    public float[] arcs  = new float[0];
    public Color[] colors = new Color[0];

    NavMeshAgent agent;

    Queue<Vector3> positionQueue = new Queue<Vector3>();
    float elapsedTime = 0;
    bool begun = false;
    bool flipFootprint = false;
    AudioSource source;

    public void Start() {
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
        begun = false;
        positionQueue.Clear();
        positionQueue.Enqueue(Player.instance.transform.position);
        source.Stop();
        Invoke("BeginHunt", waitTime);
    }

    void BeginHunt() {
        begun = true;
    }

    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > walkTime) {
            elapsedTime = 0f;
            positionQueue.Enqueue(Player.instance.transform.position);
            InstantiateFootprint();
        }
        if (begun)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                if (positionQueue.Count > 0)
                    agent.destination = positionQueue.Dequeue();
            }
        }
        UpdateAudio();
    }

    void InstantiateFootprint() {
        GameObject footprint = Instantiate(footprintPrefab);
        footprint.transform.position = new Vector3(transform.position.x, 0.51f, transform.position.z);
        footprint.transform.rotation = Quaternion.Euler(90f, 0f, -transform.rotation.eulerAngles.y);
        footprint.transform.parent = footprintContainer;
        if (flipFootprint)
            footprint.GetComponent<SpriteRenderer>().flipX = true;
        flipFootprint = !flipFootprint;
    }

    void UpdateAudio() {
        if (begun) {
            float distanceFromPlayer = Vector3.Distance(Player.instance.transform.position, transform.position);
            if (distanceFromPlayer < arcs[0] && !source.isPlaying)
                ChangeDrumClip(drums[0]);
            else if (distanceFromPlayer < arcs[1] && !source.isPlaying)
                ChangeDrumClip(drums[1]);
            else if (distanceFromPlayer < arcs[2] && !source.isPlaying)
                ChangeDrumClip(drums[2]);
        }
    }

    void ChangeDrumClip(AudioClip sound) {
        source.Stop();
        source.clip = sound;
        source.Play();
    }

    void OnTriggerEnter(Collider other) {
        if (begun && other.gameObject == Player.instance.gameObject)
            Overmind.instance.LoseGame();
    }

    void OnDrawGizmosSelected() {
        for (int i = 0; i < arcs.Length; ++i) {
            Gizmos.color = colors[i];
            Gizmos.DrawWireSphere(transform.position, arcs[i]);
        }
    }
}
