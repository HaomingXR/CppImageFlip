using System;
using System.Runtime.InteropServices;
using UnityEngine;

public static class ImageFlip
{
    [DllImport("ImageFlip")]
    private static extern void FlipImageVertically(IntPtr imageData, uint width, uint height, byte bytesPerPixel);

    /// <summary>
    /// Flips a Texture vertically so that it is upside down
    /// </summary>
    /// <param name="input">Texture to flip</param>
    /// <returns>The new Texture that is flipped</returns>
    public static Texture2D FlipVertically(Texture2D input)
    {
        byte[] data = input.GetRawTextureData();
        byte channel;

        if (input.format == TextureFormat.RGB24)
            channel = 3;
        else if (input.format == TextureFormat.RGBA32)
            channel = 4;
        else
            throw new NotSupportedException("Only RGB24 and RGBA32 Images are Supported!");

        IntPtr ptr = Marshal.AllocHGlobal(data.Length);
        Marshal.Copy(data, 0, ptr, data.Length);

        FlipImageVertically(ptr, (uint)input.width, (uint)input.height, channel);

        Marshal.Copy(ptr, data, 0, data.Length);

        Texture2D output = new Texture2D(input.width, input.height, input.format, false);

        output.LoadRawTextureData(data);
        output.Apply();

        Marshal.FreeHGlobal(ptr);

        return output;
    }
}
