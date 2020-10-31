using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private static WorldManager instance = null;

    public GameObject spawnPosition;
    public bool WorldInMotion { get; private set; }
    public bool SlowWorld { get; private set; }

    public PlayerInputHandler playerInputHandler_;

    float timeSlowStarted;

    // Game Instance Singleton
    public static WorldManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (playerInputHandler_.Jump)
        {
            if (!SlowWorld)
            {
                WorldInMotion = !WorldInMotion;
            }
            Debug.LogError(WorldInMotion);
        }

        if (playerInputHandler_.slowTime && WorldInMotion && !SlowWorld)
        {
            WorldInMotion = false;
            SlowWorld = true;
            timeSlowStarted = Time.realtimeSinceStartup;
            Debug.LogError("SLOWING TIME");
        }

        if (SlowWorld)
        {
            if(Time.realtimeSinceStartup - timeSlowStarted > 1)
            {
                SlowWorld = false;
                WorldInMotion = true;
            }
        }


    }
}
