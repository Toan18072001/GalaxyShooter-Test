using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    const int pointStartBg = 446;
    const int pointEndBg = -440;
    [SerializeField] float speed;
    RectTransform rect;
    Vector2 anchoredPosition = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<Image>().rectTransform;
    }

    // Update is called once per frame
    void Update()
    {
        anchoredPosition = rect.anchoredPosition;
        anchoredPosition.y -= (speed * Time.deltaTime);
        rect.anchoredPosition = anchoredPosition;
        if (anchoredPosition.y <= pointEndBg)
        {
            anchoredPosition.y = pointStartBg;
            rect.anchoredPosition = anchoredPosition;
        }
    }
}
