using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraRotate : MonoBehaviour
{
    private void Start() {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
    }
}
