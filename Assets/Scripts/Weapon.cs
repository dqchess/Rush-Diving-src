using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] weapons;
    int weaponIndex = 0;
    bool isWeaponMode = false;
    // Start is called before the first frame update
    void Start()
    {
        weaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (isWeaponMode)
            {
                if (weaponIndex == weapons.Length - 1)
                {
                    isWeaponMode = false;
                    weapons[weaponIndex].SetActive(false);
                }
                else
                {
                    weapons[weaponIndex].SetActive(false);
                    weaponIndex += 1;
                    weapons[weaponIndex].SetActive(true);
                }
            }
            else
            {
                isWeaponMode = true;
                weaponIndex = 0;
                weapons[weaponIndex].SetActive(true);
            }
            
        }
    }
}
