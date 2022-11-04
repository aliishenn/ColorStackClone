using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject _selectedObject;
    private GameObject _selectedStand;
    private Circle _circle;
    public bool thereIsMovement;
    public GameObject nextPanel;

    public int targetNumberStand;
    private int targetNumberCompletedStand;
    
    
    
    private void Start()
    {
        nextPanel.SetActive(false);
    }

    void Update()
    {
        if (targetNumberCompletedStand == targetNumberStand)
        {
            return;

        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                if (hit.collider != null && hit.collider.CompareTag("Stand"))
                {
                    if (_selectedObject != null && _selectedStand != hit.collider.gameObject)
                    {
                        //Sending a Circle
                        Stand _stand = hit.collider.GetComponent<Stand>();

                        if (_stand._Circles.Count != 4 && _stand._Circles.Count != 0)
                        {
                            if (_circle.Color == _stand._Circles[^1].GetComponent<Circle>().Color)
                            {
                                _selectedStand.GetComponent<Stand>().ChangeSocketProcess(_selectedObject);
                                _circle.Movement("ChangePosition", hit.collider.gameObject, _stand.suitableSocket(),
                                    _stand.movePosition);
                                _stand.emptySocket++;
                                _stand._Circles.Add(_selectedObject);
                                _stand.checkItCircles();
                                _selectedObject = null;
                                _selectedStand = null;

                            }
                            else
                            {
                                _circle.Movement("SocketBack");
                                _selectedObject = null;
                                _selectedStand = null;
                            }

                        }
                        else if (_stand._Circles.Count == 0)
                        {
                            _selectedStand.GetComponent<Stand>().ChangeSocketProcess(_selectedObject);
                            _circle.Movement("ChangePosition", hit.collider.gameObject, _stand.suitableSocket(),
                                _stand.movePosition);
                            _stand.emptySocket++;
                            _stand._Circles.Add(_selectedObject);
                            _stand.checkItCircles();
                            _selectedObject = null;
                            _selectedStand = null;
                        }
                        else
                        {
                            _circle.Movement("SocketBack");
                            _selectedObject = null;
                            _selectedStand = null;
                        }
                    }
                    else if (_selectedStand == hit.collider.gameObject)
                    {
                        _circle.Movement("SocketBack");
                        _selectedObject = null;
                        _selectedStand = null;
                    }
                    else
                    {
                        Stand _stand = hit.collider.GetComponent<Stand>();
                        _selectedObject = _stand.giveTopCircle();
                        _circle = _selectedObject.GetComponent<Circle>();
                        thereIsMovement = true;

                        if (_circle.isMovement)
                        {
                            _circle.Movement("Selected", null, null,
                                _circle.whichStand.GetComponent<Stand>().movePosition);

                            _selectedStand = _circle.whichStand;
                        }
                    }
                }
            }
        }
    }

    public void StandCompleted()
    {
        targetNumberCompletedStand++;
        if (targetNumberCompletedStand == targetNumberStand)
        {
            nextPanel.SetActive(true);
            
        }
    }
}