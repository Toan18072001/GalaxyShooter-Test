using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab; // Đối tượng viên đạn
    public List< Transform> firePoints; // Mảng các điểm phát đạn
    public float bulletSpeed = 10f; // Tốc độ của viên đạn

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Bắn đạn theo 3 hướng khác nhau
            Shoot(firePoints[0].position, firePoints[0].up);
            Shoot(firePoints[1].position, firePoints[1].up + firePoints[2].right);
            Shoot(firePoints[2].position, firePoints[2].up - firePoints[2].right);
        }
    }

    private void Shoot(Vector3 position, Vector3 direction)
    {
        // Tạo mới một viên đạn và đặt vị trí bắt đầu của nó tại điểm phát đạn
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);

        // Đặt hướng đi của viên đạn
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }
}
