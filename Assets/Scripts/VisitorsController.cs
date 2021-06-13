using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class VisitorsController : MonoBehaviour
{
    private Transform _target;
    private Transform _nextTarget;
    private NavMeshAgent _navmesh;
    private bool _trigger;
    public string _enemyTag = "Free";
    public string _stayTag = "Busy";
    public List<GameObject> FreeChairs = new List<GameObject>();
    public List<GameObject> FreeVisitors = new List<GameObject>();
    [SerializeField] private float _seeDistance = 10f;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private ChairsController _chairsController;
    [SerializeField] private VisitorsController _visitorsController;

    public Dictionary<GameObject, VisitorStatus> VisitorsStatusChange = new Dictionary<GameObject, VisitorStatus>();
    public enum VisitorStatus
    {
        Free = 0,
        Busy = 1
    }
    private void Start()
    {
        _navmesh = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag(_enemyTag).transform;
        
        FreeChairs = _chairsController.GetFreeChairs();
        FreeVisitors = _visitorsController.GetFreeVisitors();
        _chairsController.OnChairsListChange += b =>
        {
            FreeChairs = _visitorsController.FreeVisitors;
        };
    }
    private void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _trigger = true;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _trigger = false;
        }
        
        if (!_trigger) return;

        if (Vector3.Distance(_navmesh.destination, _target.transform.position) < _seeDistance);
        {
            transform.LookAt(_target.transform);
            transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
        }
        Debug.Log("Space pressed");
    }

    public List<GameObject>  GetFreeVisitors()
    {
        List<GameObject> visitors = new List<GameObject>();
        foreach (var visitor in VisitorsStatusChange)
        {
            if (visitor.Value == VisitorStatus.Free)
            {
                visitors.Add(visitor.Key);
            }
        }
        return visitors;
    }
}