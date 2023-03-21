using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FlyingText : MonoBehaviour
{
    private Text text;
    private RectTransform rectTrasform;
    [SerializeField]
    private float MaxDistance = 100;

    [SerializeField]
    private float velocity;
    private float distance = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        rectTrasform = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rect transform = rectTrasform.rect;
        //transform.y+=Time.deltaTime * velocity;
        if (distance > MaxDistance)
            Destroy(this.gameObject);
        distance += velocity * Time.deltaTime;
        rectTrasform.Translate(0, velocity * Time.deltaTime, 0);
    }
}
