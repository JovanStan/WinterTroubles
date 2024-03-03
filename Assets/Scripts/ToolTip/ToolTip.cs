using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI headerField, contentField;

    public LayoutElement layout;

    public int characterWrapLimit;

    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 pos = Input.mousePosition;

        float pivotX = pos.x / Screen.width;
        float pivotY = pos.y / Screen.height;

        rect.pivot = new Vector2(pivotX, pivotY);

        transform.position = pos + new Vector2(0f, -40f);
    }

    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        contentField.text = content;

        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        if (headerLength > characterWrapLimit || contentLength > characterWrapLimit)
        {
            layout.enabled = true;
        }
        else
        {
            layout.enabled = false;
        }
    }
}
