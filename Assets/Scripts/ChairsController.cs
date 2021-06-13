using System;
using System.Collections.Generic;
using UnityEngine;

public class ChairsController : MonoBehaviour
{

    public  Dictionary<GameObject, ChairStatus> ChairStatusChange = new Dictionary<GameObject, ChairStatus>();
    [SerializeField] private ChairsView[] _chairsViews;
    public event Action<bool> OnChairsListChange;
    public enum ChairStatus
    {
        Free = 0,
        Busy = 1
    }

    // private void Cont(int ID, string Value)
    // {
    //     foreach (var gb in ChairStatusChange.Keys)
    //     {
    //         if (gb.GetInstanceID().Equals(ID))
    //         {
    //             ChairStatusChange.Remove(gb);
    //         }
    //     }
    // }

    public List<GameObject>  GetFreeChairs()
    {
        List<GameObject> chairs = new List<GameObject>();
        foreach (var chair in ChairStatusChange)
        {
            if (chair.Value == ChairStatus.Free)
            {
                chairs.Add(chair.Key);
            }
        }
        return chairs;
    }

    // public void Start()
    // {
    //     for (int i = 0; i < _chairsViews.Length; i++)
    //     {
    //         _chairsViews[i].Contact += Cont;
    //         ChairStatusChange.Add(_chairsViews[i].gameObject, _chairsViews[i].StatusC);
    //     }
    // }
}