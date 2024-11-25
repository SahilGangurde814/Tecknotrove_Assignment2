using UnityEngine;

public class GunEquip : MonoBehaviour
{
    [SerializeField] private Transform gunHolder; 
    private GameObject nearbyGun; 
    private bool canEquip = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canEquip && nearbyGun != null)
        {
            EquipGun(nearbyGun);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnequipGun"))
        {
            nearbyGun = other.gameObject;
            canEquip = true;
            Debug.Log($"Near gun: {nearbyGun.name}. Press F to equip.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UnequipGun"))
        {
            nearbyGun = null;
            canEquip = false;
            Debug.Log("Left gun area.");
        }
    }

    private void EquipGun(GameObject gun)
    {
        gun.transform.SetParent(gunHolder);
        gun.transform.localPosition = Vector3.zero;
        gun.transform.localRotation = Quaternion.identity; 

        var collider = gun.GetComponent<Collider>();
        if (collider != null) collider.enabled = false;

        var rb = gun.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        gun.GetComponent<Fire>().enabled = true;
    }
}
