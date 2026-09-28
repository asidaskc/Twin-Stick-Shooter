using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerAttackController : MonoBehaviour
{
    PlayerController m_playerController;
    public GameObject m_bulletPrefab;
    public float m_attackSpeed;

    public enum m_FireMode
    {
        SemiAuto,
        FullAudo
    }
    public m_FireMode m_fireMode;
    float m_attackTimer;

    void Start()
    {
        m_playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        Vector3 aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimPosition.z = 0;
        Vector3 aimDirection = aimPosition - transform.position;
        aimDirection = aimDirection.normalized;

        // Page 28 challenge: full-auto firing with a timer.
        m_attackTimer -= Time.deltaTime;
        if (m_fireMode == m_FireMode.SemiAuto && Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnBullet(aimDirection);
        }
        else if (m_fireMode == m_FireMode.FullAudo && Input.GetKey(KeyCode.Mouse0) && m_attackTimer <= 0)
        {
            SpawnBullet(aimDirection);
            m_attackTimer = 1f / Mathf.Max(m_attackSpeed, 0.1f);
        }
    }

    void SpawnBullet(Vector3 aimDirection)
    {
        GameObject bullet = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);
        var bC = bullet.GetComponent<BulletController>();
        bC.m_direction = aimDirection;
        bC.m_damage = m_playerController.m_attackDamage;
    }
}
