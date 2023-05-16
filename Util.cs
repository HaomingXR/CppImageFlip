using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class Util
{
    [DllImport("ImageFlip")]
    private static extern void FlipImageVertically(IntPtr imageData, int width, int height, int bytesPerPixel);

    // Note that since this uses ref, it WILL modify the original texture. Edit this script if you don't want that!
    public static unsafe void FlipTextureVertically(ref Texture2D original, byte channel = 3)
    {
        byte[] data = original.GetRawTextureData();

        IntPtr ptr = Marshal.AllocHGlobal(data.Length);
        Marshal.Copy(data, 0, ptr, data.Length);

        Utils.FlipImageVertically(ptr, original.width, original.height, channel);

        Marshal.Copy(ptr, data, 0, data.Length);

        original.LoadRawTextureData(data);
        original.Apply();
        Marshal.FreeHGlobal(ptr);
    }
}