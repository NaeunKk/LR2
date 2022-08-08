using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeAttackSceneChange : MonoBehaviour
{
    [Header("특정 위치")]
    [SerializeField]
    private List<Vector2> _colPos;
    [Header("감지 범위")]
    [SerializeField]
    private List<Vector2> _colSize;
    [Header("변환할 씬 이름")]
    [SerializeField]
    private List<string> scenes;

    // Update is called once per frame
    void Update()
    {
        TimeAttackSenser();
    }
    private void TimeAttackSenser()
    {
        for(int i = 0; i < _colPos.Count; i++)
        {
            Debug.DrawRay(_colPos[i], Vector2.up);
            Collider2D box = Physics2D.OverlapBox(_colPos[i], _colSize[i], 0);

            if(box != null && box.transform.CompareTag("PlayerL") || box != null && box.transform.CompareTag("PlayerR"))
            {
                SceneManager.LoadScene(scenes[i]);
            }
        }
        
    }
}
