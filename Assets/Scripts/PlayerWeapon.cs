using UnityEngine;
using System.Collections;
public class PlayerWeapon : MonoBehaviour
{
    [Header("General References : ")]
    public GameObject bulletPrefab;
    public Transform firepoint;
    public Rigidbody2D rb;
    public PlayerHealth ph;
    public AnimationManager am;

    private bool canShoot = true;

    [Header("Cooldown : ")]
    [SerializeField] private float shootCd = 1f;

    void LateUpdate()
    {
        if (Input.GetKey("a") && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
            StartCoroutine(ApplyCd((i) => { canShoot = i; }, shootCd));
            am.TriggerShootVar();
        }
        if (Input.GetKey("e"))
        {
            ph.TakeDamage(20);
        }
    }

    IEnumerator ApplyCd(System.Action<bool> callback, float cooldown)
    {
        callback(false);
        yield return new WaitForSeconds(cooldown);
        callback(true);
    }
}