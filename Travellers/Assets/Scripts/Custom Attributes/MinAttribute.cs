/*
* Created by Daniel Mak
*/

using UnityEngine;

public class MinAttribute : PropertyAttribute {

    public float min = 0f;

    public MinAttribute(float min) {
        this.min = min;
    }
}