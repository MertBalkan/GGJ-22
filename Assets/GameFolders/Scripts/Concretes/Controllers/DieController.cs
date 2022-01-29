using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieController : MonoBehaviour
{
    [SerializeField] private GameObject _checkPoint;
    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.transform.position = _checkPoint.transform.position;
    }
}
