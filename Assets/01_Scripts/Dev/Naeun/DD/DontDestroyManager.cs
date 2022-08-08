using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyManager : MonoBehaviour
{
    public static DontDestroyManager Instance = null;

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