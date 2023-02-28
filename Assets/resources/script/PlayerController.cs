using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab; // Đối tượng viên đạn
    public List< Transform> firePoints; // Mảng các điểm phát đạn
    public float bulletSpeed = 10f; // Tốc độ của viên đạn
    private Vector3 targetPosition; // vị trí mà player muốn đến
    private bool isMoving = false;
    public float speed;
    public GameObject btnShoot;

    private Vector3 playerPosition;

    void Start()
    {
        // Lấy vị trí ban đầu của player
        playerPosition = transform.position;
    }

    void Update()
    {
        if (Application.isMobilePlatform)
        {
            // Kiểm tra xem có chạm vào màn hình không
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Lấy vị trí chạm
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                // Di chuyển player theo vị trí chạm
                playerPosition.x += touchDeltaPosition.x * speed * Time.deltaTime;
                playerPosition.y += touchDeltaPosition.y * speed * Time.deltaTime;
            }
            if (GameManager.Instance.ischeckThreeBullet)
            {
                shotThreeBullet();
            }
            else
            {
                shotBullet();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GameManager.Instance.ischeckThreeBullet)
                {
                    shotThreeBullet();
                }
                else
                {
                    shotBullet();
                }
            }
            if (Input.GetMouseButton(0))
            {
                // Lấy vị trí của con trỏ chuột trên màn hình
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Giới hạn vị trí của con trỏ chuột bên trong màn hình
                mousePosition.x = Mathf.Clamp(mousePosition.x, -3.44f, 3.44f);
                mousePosition.y = Mathf.Clamp(mousePosition.y, -4.36f, 4.3f);

                // Chuyển đổi vị trí của con trỏ chuột thành vị trí mới cho player
                targetPosition = mousePosition;
                isMoving = true;
            }

            if (isMoving)
            {
                // Di chuyển player đến vị trí mới
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

                // Nếu player đã đến vị trí mới, dừng di chuyển
                if (transform.position == targetPosition)
                {
                    isMoving = false;
                }
            }
        }
        playerPosition.x = Mathf.Clamp(playerPosition.x, -3.44f, 3.44f);
        playerPosition.y = Mathf.Clamp(playerPosition.y, -4.36f, 4.36f);

        // Cập nhật vị trí của player
        transform.position = playerPosition;
    }

    private void Shoot(Vector3 position, Vector3 direction)
    {
        // Tạo mới một viên đạn và đặt vị trí bắt đầu của nó tại điểm phát đạn
        GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);

        // Đặt hướng đi của viên đạn
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }

    private void shotThreeBullet()
    {
        Shoot(firePoints[0].position, firePoints[0].up);
        Vector2 f1 = (firePoints[1].up + firePoints[2].right) / 2;
        Shoot(firePoints[1].position, f1);
        Vector2 f2 = (firePoints[2].up - firePoints[2].right) / 2;
        Shoot(firePoints[2].position, f2);
    }
    private void shotBullet()
    {
        Shoot(firePoints[0].position, firePoints[0].up);
    }
    public void shottingAndroid()
    {
        if (GameManager.Instance.ischeckThreeBullet)
        {
            shotThreeBullet();
        }
        else
        {
            shotBullet();
        }
    }
}
