using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookFunctions : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    public Vector3 Right { get { Vector3 right = _camera.right; right.y = 0; return right.normalized; } }
    public Vector3 Forward { get { Vector3 forward = _camera.forward; forward.y = 0; return forward.normalized; } }
}
