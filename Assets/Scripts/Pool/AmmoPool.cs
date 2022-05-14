using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPool : MonoBehaviour
{
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private AmmoController _ammoPrefab;
    [SerializeField] private List<AmmoController> _startedPool; 

    private PoolMono<AmmoController> _pool;

    public static AmmoPool Instate;

    private void Awake()
    {
        this._pool = new PoolMono<AmmoController>(this._ammoPrefab, 0, this.transform, _startedPool);
        this._pool.AutoExpand = _autoExpand;

        if (Instate == null)
            Instate = this;
        else
            Destroy(gameObject);
    }

    public AmmoController GetAmmo()
    {
        var obj = _pool.GetFreeElement();
        return obj;
    }
}
