/*
* Created by Daniel Mak
*/

using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public CircleManager circle;
    [Header("Events")]
    public UnityEvent duringPlayEvents;
    public UnityEvent onLoseEvents;
    
    private bool hasStart = false;

    private void Awake() {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

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