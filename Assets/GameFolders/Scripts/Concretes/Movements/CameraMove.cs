using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float _finalCameraMoveSpeed;
    private void Update()
    {
        if(this.gameObject.transform.position.x < 17.00f || this.gameObject.transform.position.x > 0.0f){
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * _finalCameraMoveSpeed);
        }
        else if(this.gameObject.transform.position.x > -1.00f || this.gameObject.transform.position.x < 0.0f){

            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * _finalCameraMoveSpeed);

        }
    }
}
