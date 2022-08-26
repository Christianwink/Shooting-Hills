using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform alvo;

    public float veloSuave = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        if (alvo != null)
        {
            Vector3 posidesejada = alvo.position + offset;
            Vector3 posiSuavizada = Vector3.Lerp(transform.position, posidesejada, veloSuave);
            transform.position = posiSuavizada;

            transform.LookAt(alvo);
        }
    }
}
