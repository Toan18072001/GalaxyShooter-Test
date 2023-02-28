using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab; // Đối tượng viên đạn
    public List<Transform> firePoints; // Mảng các điểm phát đạn
    public float bulletSpeed = 10f; // Tốc độ của viên đạn
    private Vector3 targetPosition; // vị trí mà player muốn đến
    private bool isMoving = false;
    public float speed;
    public float liftBullet;
    public float timeShoot =2f;
    void Update()
    {
        HandleTouchInput();
        liftBullet -= Time.deltaTime;
        if (liftBullet <= 0)
        {
            Shotting();
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
    public void shotBullet()
    {
        Shoot(firePoints[0].position, firePoints[0].up);
    }
    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Kiểm tra xem người dùng chạm vào màn hình
            if (touch.phase == TouchPhase.Began)
            {
                // Lấy vị trí của chạm trên màn hình
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // Giới hạn vị trí của chạm bên trong màn hình
                touchPosition.x = Mathf.Clamp(touchPosition.x, -3.44f, 3.44f);
                touchPosition.y = Mathf.Clamp(touchPosition.y, -4.36f, 4.3f);

                // Chuyển đổi vị trí của chạm thành vị trí mới cho player
                targetPosition = touchPosition;
                isMoving = true;
            }
        }
    }
    private void Shotting()
    {
        liftBullet = timeShoot;
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
