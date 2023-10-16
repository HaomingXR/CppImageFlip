#pragma once

#ifdef FLIP_EXPORTS
#define FLIP_API __declspec(dllexport)
#else
#define FLIP_API __declspec(dllimport)
#endif

extern "C" FLIP_API void FlipImageVertically(unsigned char* imageData, unsigned int width, unsigned int height, unsigned char bytesPerPixel);
