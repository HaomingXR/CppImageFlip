using UnityEngine;
using UnityEngine.UI;

public class FlipDemo : MonoBehaviour
{
    [SerializeField]
    private Texture2D target;

    [SerializeField]
    private RawImage showcase;

    void Start()
    {
        showcase.texture = ImageFlip.FlipVertically(target);
    }
}
