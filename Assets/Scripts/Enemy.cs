using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public Transform[] points;

    public GameObject footprintPrefab;
    public Transform footprintContainer;

    public float footstepTime = 0.5f;

    public float[] arcs = new float[0];
    public Color[] colors = new Color[0];
    public float[] speeds;
    public AudioClip[] regularSounds;

    NavMeshAgent agent;
    private int destPoint = 0;

    AudioSource source;
    bool notice;
    bool flipFootprint;
    float elapsedTime;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        CheckNoiseLevel();
        Move();
        UpdateFootsteps();
        UpdateSound();
    }

    void CheckNoiseLevel() {
        int noiseLevel = Player.instance.noiseLevel;
        if (noiseLevel > 0)
        {
            if (noiseLevel >= arcs.Length)
                noiseLevel = arcs.Length - 1;
            // Player Position과 이 오브젝트의 Position의 거리가 arcs[noiseLevel]보다 작을 경우 움직이기
            notice = Vector3.Distance(Player.instance.transform.position, transform.position) < arcs[noiseLevel];
        }
        else notice = false;
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }

    void Move() {
        if (notice) {
            agent.SetDestination(Player.instance.transform.position);
            agent.speed = speeds[Player.instance.noiseLevel];
        }
        else {
            agent.destination = points[destPoint].position;
            agent.speed = speeds[1];
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
    }

    void UpdateFootsteps() {
        elapsedTime += Time.fixedDeltaTime;
        if (elapsedTime > footstepTime) {
            InstantiateFootprint();
            elapsedTime = 0;
        }
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

    void UpdateSound() {
        if (!source.isPlaying) {
            source.clip = regularSounds[Random.Range(0, regularSounds.Length)];
            source.Play();
        }
    }

    void OnDrawGizmosSelected() {
        for (int i = 0; i < arcs.Length; ++i) {
            Gizmos.color = colors[i];
            Gizmos.DrawWireSphere(transform.position, arcs[i]);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject == Player.instance.gameObject) {
            InstantiateFootprint();
            Overmind.instance.LoseGame();
        }
    }
}
