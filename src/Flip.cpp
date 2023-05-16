#include "pch.h"
#include "Flip.h"

void FlipImageVertically(unsigned char* imageData, int width, int height, int bytesPerPixel)
{
    unsigned char* rowBuffer = new unsigned char[width * bytesPerPixel];
    int halfHeight = height / 2;

    for (int row = 0; row < halfHeight; row++) {
        int topRowIndex = row * width * bytesPerPixel;
        int bottomRowIndex = (height - row - 1) * width * bytesPerPixel;

        // Swap top row with bottom row
        memcpy(rowBuffer, &imageData[topRowIndex], width * bytesPerPixel);
        memcpy(&imageData[topRowIndex], &imageData[bottomRowIndex], width * bytesPerPixel);
        memcpy(&imageData[bottomRowIndex], rowBuffer, width * bytesPerPixel);
    }

    delete[] rowBuffer;
}