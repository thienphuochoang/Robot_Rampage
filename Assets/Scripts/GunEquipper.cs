using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;
    public static string activeWeaponType;
    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;
    public GameObject laser;
    GameObject activeGun;
    [SerializeField]
    Ammo ammo;
    void Start ()
    {
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;
    }
    private void loadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);
        laser.SetActive(false);
        weapon.SetActive(true);
        activeGun = weapon;
        gameUI.SetAmmoText(ammo.GetAmmo(activeGun.tag));
    }
    void Update ()
    {
        if (Input.GetKeyDown("1"))
        {
            loadWeapon(pistol);
            activeWeaponType = Constants.Pistol;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("2"))
        {
            loadWeapon(assaultRifle);
            activeWeaponType = Constants.AssaultRifle;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("3"))
        {
            loadWeapon(shotgun);
            activeWeaponType = Constants.Shotgun;
            gameUI.UpdateReticle();
        }
        else if (Input.GetKeyDown("4"))
        {
            loadWeapon(laser);
            activeWeaponType = Constants.Laser;
            gameUI.UpdateReticle();
        }
    }
    public GameObject GetActiveWeapon()
    {
        return activeGun;
    }
}
