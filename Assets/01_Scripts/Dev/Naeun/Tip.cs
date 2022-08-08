using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour
{
    #region tip
    [Header("фа")]
    [SerializeField] private Image _tip;
    #endregion

    public void TipOpen()
    {
        _tip.gameObject.SetActive(true);
    }
    public void TipClose()
    {
        _tip.gameObject.SetActive(false);
    }
}
