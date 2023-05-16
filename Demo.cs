using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField]
    private Texture2D target;

    [SerializeField]
    private RawImage showcase;

    void Start()
    {
        Util.FlipTextureVertically(ref target);
        showcase.texture = target;
    }
}