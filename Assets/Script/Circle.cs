using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject whichStand;
    public GameObject whichCircleSocket;
    public bool isMovement;
    public string Color;
    public GameManager _GameManager;

    private GameObject _MovementPosition;
    private GameObject _goToStand;
    private bool selected, posChange, socketPlace, socketBack;

    public void Movement(string process, GameObject Stand = null, GameObject Socket = null,GameObject ObjectGo = null)
    {
        switch (process)
        {
            case "Selected":
                _MovementPosition = ObjectGo;
                selected = true;
                break;
            case "ChangePosition":
                _goToStand = Stand;
                whichCircleSocket = Socket;
                _MovementPosition = ObjectGo;
                posChange = true;
                break;
            case "SocketBack":
                socketBack = true;
                break;
        }
    }
    void Update()
    {
        if (selected)
        {
            transform.position = Vector3.Lerp(transform.position,_MovementPosition.transform.position,2f);
            if (Vector3.Distance(transform.position,_MovementPosition.transform.position)<.10)
            {
                selected = false;
            }
        }
        if (posChange)
        {
            transform.position = Vector3.Lerp(transform.position,_MovementPosition.transform.position,2f);
            if (Vector3.Distance(transform.position,_MovementPosition.transform.position)<.10)
            {
                posChange = false;
                socketPlace = true;
            }
        }
        if (socketPlace)
        {
            transform.position = Vector3.Lerp(transform.position,whichCircleSocket.transform.position,2f);
            if (Vector3.Distance(transform.position,whichCircleSocket.transform.position)<.10)
            {
                transform.position = whichCircleSocket.transform.position;
                socketPlace = false;

                whichStand = _goToStand;

                if (whichStand.GetComponent<Stand>()._Circles.Count>1)
                {
                    whichStand.GetComponent<Stand>()._Circles[^2].GetComponent<Circle>().isMovement = false;
                }
                _GameManager.thereIsMovement = false;
            }
        }
        if (socketBack)
        {
            transform.position = Vector3.Lerp(transform.position,whichCircleSocket.transform.position,2f);
            if (Vector3.Distance(transform.position,whichCircleSocket.transform.position)<.10)
            {
                transform.position = whichCircleSocket.transform.position;
                socketBack = false;
                _GameManager.thereIsMovement = false;
            }
        }
    }
}