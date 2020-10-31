using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private static WorldManager instance = null;

    public bool InMotion { get; private set; }
    public PlayerInputHandler playerInputHandler_;

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
            InMotion = !InMotion;
            Debug.LogError(InMotion);
        }
    }
}
