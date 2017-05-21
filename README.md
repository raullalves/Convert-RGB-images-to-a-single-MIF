# Convert RGB image files (BMP, GIF, JPEG, PNG, TIFF) to a single MIF (Memory Initialization File)

This is a C# Visual Studio project that converts up to 4 images (.bmp, .jpg, etc) into a Memory Initialization File.
That MIF can be loaded into a FPGA's memory, and be used to transmit into a VGA connection, for example.

It resizes the RGB images for the size you want, and organizes into a MIF as a representation of 24 bits
