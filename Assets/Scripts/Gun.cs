using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float fireRate;
    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;
    protected float lastFireTime;

    void Start()
    {
        lastFireTime = Time.time - 10;
    }
    protected virtual void Update()
    {
    }
    protected void Fire()
    {
        if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammo.ConsumeAmmo(tag);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        }
        GetComponentInChildren<Animator>().Play("Fire");
    }
}
