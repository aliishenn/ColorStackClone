using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    public GameObject movePosition;
    public GameObject[] sockets;
    public int emptySocket;
    public List<GameObject> _Circles = new();
    [SerializeField] private GameManager _GameManager;

    private int numberCircleCompletions;

    public GameObject giveTopCircle()
    {
        return _Circles[^1];
    }
    
    public GameObject suitableSocket()
    {
        return sockets[emptySocket];
    }

    public void ChangeSocketProcess(GameObject DestroyObject)
    {
        _Circles.Remove(DestroyObject);
        if (_Circles.Count!=0)
        {
            emptySocket--;
            _Circles[^1].GetComponent<Circle>().isMovement = true;
        }
        else
        {
            emptySocket = 0;
        }
    }

    public void checkItCircles()
    {
        if (_Circles.Count==4)
        {
            string Color = _Circles[0].GetComponent<Circle>().Color;
            foreach (var item in _Circles)
            {
                if (Color == item.GetComponent<Circle>().Color)
                {
                    numberCircleCompletions++;
                }
            }
            if (numberCircleCompletions == 4)
            {
                Debug.Log("Completed");
                _GameManager.StandCompleted();
                StandCompletedProcess();
            }
            else
            {
                Debug.Log("Noting");
                numberCircleCompletions = 0;
            }
        }

        void StandCompletedProcess()
        {
            foreach (var item in _Circles)
            {
                item.GetComponent<Circle>().isMovement = false;

                Color32 color = item.GetComponent<MeshRenderer>().material.GetColor("_Color");
                color.a = 150;
                item.GetComponent<MeshRenderer>().material.SetColor("_Color",color);
                gameObject.tag = "CompletedStand";
            }
        }

        
    }
}