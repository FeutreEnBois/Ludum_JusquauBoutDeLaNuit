using UnityEngine;
using System.Collections;
public class PlayerWeapon : MonoBehaviour
{
    [Header("General References : ")]
    public GameObject bulletPrefab;
    public Rigidbody2D rb;
    public Transform firepoint;
    public PlayerHealth ph;
    public AnimationManager am;

    private bool canShoot = true;

    [Header("Cooldown : ")]
    [SerializeField] private float shootCd = 1f;

    void LateUpdate()
    {
        if (Input.GetKey("a") && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firepoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(rb.velocity.x, 0);
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