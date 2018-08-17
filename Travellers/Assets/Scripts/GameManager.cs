/*
* Created by Daniel Mak
*/

using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public CircleManager circle;
    [Header("Events")]
    public UnityEvent duringPlayEvents;
    public UnityEvent onLoseEvents;
    
    private bool hasStart = false;

    private void Update() {
        if (!hasStart) {
            if (CheckStart()) {
                hasStart = true;
            }
        } else {
            duringPlayEvents.Invoke();

            if (CheckLose()) {
                onLoseEvents.Invoke();
            }
        }
    }

    private bool CheckStart() {
        return circle.InsideCenterCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private bool CheckLose() {
        return !circle.InsideCenterCircle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }    

    private void OnValidate() {
        name = "[Game Manager]";
    }
}