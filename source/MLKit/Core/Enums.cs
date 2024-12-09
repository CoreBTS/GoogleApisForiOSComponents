using System;
using ObjCRuntime;
using Foundation;

namespace MLKit.Core {
	[Native]
	public enum ImageSourceType : long {
		ImageSourceTypeImage = 0,
		ImageSourceTypePixelBuffer = 1,
		ImageSourceTypeSampleBuffer = 2
	}

	public static class ModelDownloadUserInfoKeyConstants
	{
		public static NSString MLKModelDownloadUserInfoKeyRemoteModel { get; } = new NSString("MLKModelDownloadUserInfoKeyRemoteModel");
		public static NSString MLKModelDownloadUserInfoKeyError { get; } = new NSString("MLKModelDownloadUserInfoKeyError");
	}
}
