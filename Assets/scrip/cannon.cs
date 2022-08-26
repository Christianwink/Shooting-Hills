using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cannon : MonoBehaviour
{

    public GameObject Cananone;
    public GameObject Bullet;
    public GameObject Ponta;
    public GameObject cam;
    public GameObject flash;
    public Image imagem;
    public GameObject Fin;


    public float VeloCanhao;
    public float AnguloCanhaoY;
    public float AnguloCanhaoX;

    private float FPS = 0;
    private int municao = 3;


    // Update is called once per frame
    void Update()
    {

             
        FPS -= Time.deltaTime;

        imagem.fillAmount = Mathf.Clamp(FPS, 0, 1.0f);
        

        if (Input.GetKey(KeyCode.Mouse0) && FPS <= 0 && municao >= 1)
        {
            Atirar();
            FPS = 5;
            municao--;
        }
        if(municao == 0)
        {
            Fin.SetActive(true);
        }
        
        MovimentoCanhaoElevacao();
    }

    

    void MovimentoCanhaoElevacao()
    {
        AnguloCanhaoX += Input.GetAxis("Mouse Y") * VeloCanhao * +Time.deltaTime;
        AnguloCanhaoY += Input.GetAxis("Mouse X") * VeloCanhao * +Time.deltaTime;
        AnguloCanhaoX = Mathf.Clamp(AnguloCanhaoX, -10, 50);
        AnguloCanhaoY = Mathf.Clamp(AnguloCanhaoY, 60, 120);
        Cananone.transform.localRotation = Quaternion.Euler(-AnguloCanhaoX,AnguloCanhaoY,0);

    }

    void Atirar()
    {
        FindObjectOfType<AudioManager>().Play("tiro");
        GameObject alvo = Instantiate(Bullet, Ponta.transform.position, Ponta.transform.rotation);
        GameObject camCriada =  Instantiate(cam, Ponta.transform.position, Ponta.transform.rotation);
        Instantiate(flash, Ponta.transform.position, Ponta.transform.rotation);
        camCriada.GetComponent<camerafollow>().alvo = alvo.transform;
        alvo.GetComponent<bullet>().camBullet = camCriada;
    }
}
