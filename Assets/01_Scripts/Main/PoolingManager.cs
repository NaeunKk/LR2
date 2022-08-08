using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance;
    [SerializeField] private List<GameObject> poolList = new List<GameObject>();
    private Dictionary<string, Stack<GameObject>> pools = new Dictionary<string, Stack<GameObject>>();
    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        foreach (GameObject item in poolList)
        {
            Stack<GameObject> pool = new Stack<GameObject>();
            pools.Add(item.name, pool);
        }
    }
    public GameObject Pop(GameObject prefab)
    {
        GameObject temp = null;
        if (pools[prefab.name].Count > 0)
        {
            temp = pools[prefab.name].Pop();
        }
        else
        {
            temp = Instantiate(prefab, transform);
            temp.name = temp.name.Replace("(Clone)", null);
        }
        temp.SetActive(true);
        return temp;
    }
    public void Push(GameObject prefab)
    {
        prefab.SetActive(false);
        pools[prefab.name].Push(prefab);
    }
}