using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ImageScroller : MonoBehaviour
{
    private RawImage _image;

    [SerializeField] private float _scrollSpeed = 3;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _image.uvRect = new Rect(_image.uvRect.position + new Vector2(-_scrollSpeed, _scrollSpeed) * Time.deltaTime, _image.uvRect.size);
    }
}
