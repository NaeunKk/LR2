using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyR : MonoBehaviour
{
    public static DontDestroyR Instance = null;

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