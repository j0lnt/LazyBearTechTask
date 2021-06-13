using UnityEngine;
using System;
   
    public class ChairsView : MonoBehaviour
    {
        public ChairsController.ChairStatus StatusC { get; private set; }
        public VisitorsController.VisitorStatus StatusV { get; private set; }
        public event Action<ChairsController.ChairStatus, int> ChairStatusChange;
        public event Action<int, string> Contact;

        private void Awake()
        {
            StatusC = ChairsController.ChairStatus.Free;
            StatusV = VisitorsController.VisitorStatus.Free;
        }

        private void OnTriggerEnter(Collider myCollider)
        {
            if (myCollider.gameObject.CompareTag("Player"))
            {
                StatusC = ChairsController.ChairStatus.Busy;
                StatusV = VisitorsController.VisitorStatus.Busy;
                Debug.Log("Chair is busy");
                gameObject.tag = "Busy";
                // Contact.Invoke(gameObject.GetInstanceID()," ");
            }
        }

        // private void OnTriggerStay(Collider other)
        // {
        //     if (other.gameObject.CompareTag("Player"))
        //     {
        //         StatusC = ChairsController.ChairStatus.Busy;
        //         StatusV = VisitorsController.VisitorStatus.Busy;
        //         Debug.Log("Chair is busy");
        //         gameObject.tag = "Busy";
        //         Contact.Invoke(gameObject.GetInstanceID()," ");
        //     }
        // }
        //
        // private void OnTriggerExit(Collider other)
        // {
        //     if (gameObject.CompareTag("Player") || gameObject.CompareTag("Busy"))
        //     {
        //         gameObject.tag = "Free";
        //     }
        // }
    }