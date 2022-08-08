using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCam : MonoBehaviour
{
    public static DontDestroyCam Instance = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}