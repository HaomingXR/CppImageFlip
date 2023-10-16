#include "pch.h"
#include "Flip.h"

void FlipImageVertically(unsigned char* imageData, unsigned int width, unsigned int height, unsigned char bytesPerPixel)
{
    unsigned char* rowBuffer = new unsigned char[width * bytesPerPixel];
    unsigned int halfHeight = height / 2;

    for (unsigned int row = 0; row < halfHeight; row++) {
        unsigned int topRowIndex = row * width * bytesPerPixel;
        unsigned int bottomRowIndex = (height - row - 1) * width * bytesPerPixel;

        // Swap top row with bottom row
        memcpy(rowBuffer, &imageData[topRowIndex], width * bytesPerPixel);
        memcpy(&imageData[topRowIndex], &imageData[bottomRowIndex], width * bytesPerPixel);
        memcpy(&imageData[bottomRowIndex], rowBuffer, width * bytesPerPixel);
    }

    delete[] rowBuffer;
}
