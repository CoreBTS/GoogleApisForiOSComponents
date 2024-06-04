using System;
using ObjCRuntime;

namespace MLKit.Vision
{
	[Native]
	public enum ObjectDetectorMode : long
	{
		SingleImage = 0,
		Stream = 1
	}
}
