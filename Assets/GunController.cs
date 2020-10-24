using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField] int damege = 10;
    [SerializeField] float shootDelay = 0.2f;
    [SerializeField] float force = 0.2f;
    [SerializeField] float range = 100f;
    [SerializeField] float  effectsDisplayTime = 0.2f;
    float lastShoot=1f;

    Ray shootRay = new Ray();
    RaycastHit shootHit;
   // int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
   // AudioSource gunAudio;
  //  Light gunLight;


    void Awake()
    {
        //shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
       // gunAudio = GetComponent<AudioSource>();
      //  gunLight = GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastShoot += Time.deltaTime;


        if (Input.GetButton("Fire1"))
            {
            Shot();
            }


        if (lastShoot >= shootDelay * effectsDisplayTime)
        {
            DisableEffects();
        }


    }
    public void DisableEffects()
    {
        gunLine.enabled = false;
      //  gunLight.enabled = false;
    }
    public void Shot()
    {

        if (lastShoot >= shootDelay )
        {
            lastShoot = 0f;

            gunParticles.Stop();
            gunParticles.Play();

            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            if (Physics.Raycast(shootRay, out shootHit, range))
            {
                Health enemyHealth = shootHit.collider.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damege, shootHit.point);
                }
                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }
    }
}
