using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _finalCameraMoveSpeed;
    private void Update()
    {
        this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * _finalCameraMoveSpeed);
    }
}
