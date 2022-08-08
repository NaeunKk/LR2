using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyL : MonoBehaviour
{
    public static DontDestroyL Instance = null;

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