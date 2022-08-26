using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public GameObject explodir;
    public float raio;
    public float forca;
    private float timer = 8;
    public GameObject posiCamera;
    public GameObject camBullet;
    private Vector3 posiCameraOriginal;
    
    void Start()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 50);
        this.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.forward * 1 );
        this.gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.right * 10);


    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
            Destroy(camBullet);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        FindObjectOfType<AudioManager>().Play("explo");
        GameObject _explodir = Instantiate(explodir, transform.position, transform.rotation);
        Destroy(_explodir,3);
        knockback();
        Destroy(gameObject);
        Destroy(camBullet, 1.5f);


    }

    void knockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, raio);

        foreach(Collider nearby in colliders)
        {
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();
            if(rigg != null)
            {
                rigg.AddExplosionForce(forca, transform.position, raio);
            }
        }
    }


}
