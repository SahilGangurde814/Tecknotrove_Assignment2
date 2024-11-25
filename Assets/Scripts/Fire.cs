using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    [SerializeField] private Camera mCamera;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private ParticleSystem hitEffect;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private AudioSource gunSound;
    [SerializeField] private float fireCooldown = 1f;

    private float waitToFire = 0f;


    void Start()
    {
        gameInput.OnFireAction += GameInput_OnFireAction;
    }
    private void GameInput_OnFireAction(object sender, System.EventArgs e)
    {
        if (Time.time >= waitToFire)
        {
            Debug.Log("Fire");
            Firing();
            waitToFire = Time.time + fireCooldown;
        }
    }

    private void Firing()
    {
        muzzleFlash.Play();
        gunSound.Play();

        RaycastHit hitInfo;
        if (Physics.Raycast(mCamera.transform.position, mCamera.transform.forward, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);
            Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
        }
    }
}
