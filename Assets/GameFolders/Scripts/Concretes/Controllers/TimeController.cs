using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _slowDownLength = 2.0f;
    
    private void Update()
    {
        Time.timeScale += (1f / _slowDownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0.0f, 1.0f);
    }
    public void MakeTimeToSlow()
    {
        Time.timeScale = 0.5f;
        //Time.fixedDeltaTime = 0.02f * Time.timeScale; 
    }
}