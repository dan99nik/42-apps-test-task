using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class PoolMono<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { get; set; }

    public Transform Container;

    private List<T> _pool;

    public PoolMono(T prefab, int count)
    {
        this.Prefab = prefab;
        this.Container = null;

        this.CreatePool(count);
    }

    public PoolMono(T prefab, int count, Transform container,List<T> startedPool)
    {
        this.Prefab = prefab;
        this.Container = container;

        this.CreatePool(count);
        this.SetStartedObjects(startedPool);
    }

    private void CreatePool(int count)
    {
        this._pool = new List<T>();

        for(int i =0;i< count; i++)
        {
            this.CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(this.Prefab, this.Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this._pool.Add(createdObject);
        return createdObject;
    }

    public void SetStartedObjects(List<T> obj)
    {
        foreach (T mono in obj)
        {
            var createdObject = mono;
            createdObject.gameObject.SetActive(false);
            this._pool.Add(createdObject);
        }
    }

    public bool HasFreeElement(out T element)
    {
        foreach(var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
            return element;

        if (this.AutoExpand)
            return this.CreateObject(true);

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }

    public int CountPool()
    {
        return _pool.Count;
    }
}
