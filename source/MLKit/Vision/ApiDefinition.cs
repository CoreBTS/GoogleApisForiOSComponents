using System;

using UIKit;
using Foundation;
using CoreMedia;
using CoreVideo;
using CoreGraphics;
using ObjCRuntime;

using MLKit.Core;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace MLKit.Vision
{
	// @interface GMLImage : NSObject
	[BaseType(typeof(CompatibleImage), Name = "GMLImage")]
	[DisableDefaultCtor]
	interface MLImage
	{
		// @property (readonly, nonatomic) CGFloat width;
		[Export("width")]
		nfloat Width { get; }

		// @property (readonly, nonatomic) CGFloat height;
		[Export("height")]
		nfloat Height { get; }

		// @property (nonatomic) UIImageOrientation orientation;
		[Export("orientation", ArgumentSemantic.Assign)]
		UIImageOrientation Orientation { get; set; }

		// @property (readonly, nonatomic) GMLImageSourceType imageSourceType;
		[Export("imageSourceType")]
		ImageSourceType ImageSourceType { get; }

		// @property (readonly, nonatomic) UIImage * _Nullable image;
		[NullAllowed, Export("image")]
		UIImage Image { get; }

		// @property (readonly, nonatomic) CVPixelBufferRef _Nullable pixelBuffer;
		[NullAllowed, Export("pixelBuffer")]
		CVPixelBuffer PixelBuffer { get; }

		// @property (readonly, nonatomic) CMSampleBufferRef _Nullable sampleBuffer;
		[NullAllowed, Export("sampleBuffer")]
		CMSampleBuffer SampleBuffer { get; }

		// -(instancetype _Nullable)initWithImage:(UIImage * _Nonnull)image __attribute__((objc_designated_initializer));
		[Export("initWithImage:")]
		[DesignatedInitializer]
		NativeHandle Constructor(UIImage image);

		// -(instancetype _Nullable)initWithPixelBuffer:(CVPixelBufferRef _Nonnull)pixelBuffer __attribute__((objc_designated_initializer));
		[Export("initWithPixelBuffer:")]
		[DesignatedInitializer]
		NativeHandle Constructor(CVPixelBuffer pixelBuffer);

		// -(instancetype _Nullable)initWithSampleBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer __attribute__((objc_designated_initializer));
		[Export("initWithSampleBuffer:")]
		[DesignatedInitializer]
		NativeHandle Constructor(CMSampleBuffer sampleBuffer);
	}

	interface ICompatibleImage { }

	[Protocol]
	[BaseType(typeof(NSObject), Name = "MLKCompatibleImage")]
	interface CompatibleImage
	{
	}

	// @interface MLKVision3DPoint
	[BaseType(typeof(VisionPoint), Name = "MLKVision3DPoint")]
	[DisableDefaultCtor]
	interface Vision3DPoint
	{
		// @property (readonly, nonatomic) CGFloat z;
		[Export("z")]
		nfloat Z { get; }
	}

	// @interface MLKVisionImage : NSObject <MLKCompatibleImage>
	[BaseType(typeof(CompatibleImage), Name = "MLKVisionImage")]
	[DisableDefaultCtor]
	interface VisionImage
	{
		// @property (nonatomic) UIImageOrientation orientation;
		[Export("orientation", ArgumentSemantic.Assign)]
		UIImageOrientation Orientation { get; set; }

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image __attribute__((objc_designated_initializer));
		[Export("initWithImage:")]
		[DesignatedInitializer]
		NativeHandle Constructor(UIImage image);

		// -(instancetype _Nonnull)initWithBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer __attribute__((objc_designated_initializer));
		[Export("initWithBuffer:")]
		[DesignatedInitializer]
		NativeHandle Constructor(CMSampleBuffer sampleBuffer);
	}

	// @interface MLKVisionPoint : NSObject
	[BaseType(typeof(NSObject), Name = "MLKVisionPoint")]
	[DisableDefaultCtor]
	interface VisionPoint
	{
		// @property (readonly, nonatomic) CGFloat x;
		[Export("x")]
		nfloat X { get; }

		// @property (readonly, nonatomic) CGFloat y;
		[Export("y")]
		nfloat Y { get; }
	}

	// @interface MLKCommonImageLabelerOptions : NSObject
	[BaseType(typeof(NSObject), Name = "MLKCommonImageLabelerOptions")]
	[DisableDefaultCtor]
	interface CommonImageLabelerOptions
	{
		// @property(nonatomic, nullable) NSNumber *confidenceThreshold;
		[NullAllowed, Export("confidenceThreshold", ArgumentSemantic.Assign)]
		NSNumber ConfidenceThreshold { get; set; }
	}

	// @interface MLKImageLabel : NSObject
	[BaseType(typeof(NSObject), Name = "MLKImageLabel")]
	[DisableDefaultCtor]
	interface ImageLabel
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull text;
		[Export("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSInteger index;
		[Export("index")]
		nint Index { get; }

		// @property (readonly, nonatomic) float confidence;
		[Export("confidence")]
		float Confidence { get; }
	}

	// typedef void (^MLKImageLabelingCallback)(NSArray<MLKImageLabel *> * _Nullable, NSError * _Nullable);
	delegate void ImageLabelingCallback([NullAllowed] ImageLabel[] imageLabels, [NullAllowed] NSError error);

	// @interface MLKImageLabeler : NSObject
	[BaseType(typeof(NSObject), Name = "MLKImageLabeler")]
	[DisableDefaultCtor]
	interface ImageLabeler
	{
		// +(instancetype _Nonnull)imageLabelerWithOptions:(MLKCommonImageLabelerOptions * _Nonnull)options __attribute__((swift_name("imageLabeler(options:)")));
		[Static]
		[Export("imageLabelerWithOptions:")]
		ImageLabeler ImageLabelerWithOptions(CommonImageLabelerOptions options);

		// -(void)processImage:(id<MLKCompatibleImage> _Nonnull)image completion:(MLKImageLabelingCallback _Nonnull)completion __attribute__((swift_name("process(_:completion:)")));
		[Export("processImage:completion:")]
		void ProcessImage(ICompatibleImage image, ImageLabelingCallback completion);

		// -(NSArray<MLKImageLabel *> * _Nullable)resultsInImage:(id<MLKCompatibleImage> _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[Export("resultsInImage:error:")]
		[return: NullAllowed]
		ImageLabel[] ResultsInImage(ICompatibleImage image, [NullAllowed] out NSError error);
	}

	// @interface MLKCommonObjectDetectorOptions : NSObject
	[BaseType(typeof(NSObject), Name = "MLKCommonObjectDetectorOptions")]
	[DisableDefaultCtor]
	interface CommonObjectDetectorOptions
	{
		// @property (nonatomic) BOOL shouldEnableClassification;
		[Export("shouldEnableClassification")]
		bool ShouldEnableClassification { get; set; }

		// @property (nonatomic) BOOL shouldEnableMultipleObjects;
		[Export("shouldEnableMultipleObjects")]
		bool ShouldEnableMultipleObjects { get; set; }

		// @property (nonatomic) MLKObjectDetectorMode detectorMode;
		[Export("detectorMode")]
		ObjectDetectorMode Mode { get; set; }
	}

	// @interface MLKObject : NSObject
	[BaseType(typeof(NSObject), Name = "MLKObject")]
	[DisableDefaultCtor]
	interface VisionObject
	{
		// @property (readonly, nonatomic) CGRect frame;
		[Export("frame")]
		CGRect Frame { get; }

		// @property (readonly, nonatomic) NSArray<MLKObjectLabel *> * _Nonnull labels;
		[Export("labels")]
		ObjectLabel[] Labels { get; }

		// @property (readonly, nonatomic) NSNumber * _Nullable trackingID;
		[NullAllowed, Export("trackingID")]
		NSNumber TrackingId { get; }
	}

	// typedef void (^MLKObjectDetectionCallback)(NSArray<MLKObject *> * _Nullable, NSError * _Nullable);
	delegate void ObjectDetectionCallback([NullAllowed] VisionObject[] objects, [NullAllowed] NSError error);

	// @interface MLKObjectDetector : NSObject
	[BaseType(typeof(NSObject), Name = "MLKObjectDetector")]
	[DisableDefaultCtor]
	interface ObjectDetector
	{
		// +(instancetype _Nonnull)objectDetectorWithOptions:(MLKCommonObjectDetectorOptions * _Nonnull)options __attribute__((swift_name("objectDetector(options:)")));
		[Static]
		[Export("objectDetectorWithOptions:")]
		ObjectDetector ObjectDetectorWithOptions(CommonObjectDetectorOptions options);

		// -(void)processImage:(id<MLKCompatibleImage> _Nonnull)image completion:(MLKObjectDetectionCallback _Nonnull)completion __attribute__((swift_name("process(_:completion:)")));
		[Export("processImage:completion:")]
		void ProcessImage(ICompatibleImage image, ObjectDetectionCallback completion);

		// -(NSArray<MLKObject *> * _Nullable)resultsInImage:(id<MLKCompatibleImage> _Nonnull)image error:(NSError * _Nullable * _Nullable)error;
		[Export("resultsInImage:error:")]
		[return: NullAllowed]
		VisionObject[] ResultsInImage(ICompatibleImage image, [NullAllowed] out NSError error);
	}

	// @interface MLKObjectLabel : NSObject
	[BaseType(typeof(NSObject), Name = "MLKObjectLabel")]
	[DisableDefaultCtor]
	interface ObjectLabel
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull text;
		[Export("text")]
		string Text { get; }

		// @property (readonly, nonatomic) NSInteger index;
		[Export("index")]
		nint Index { get; }

		// @property (readonly, nonatomic) float confidence;
		[Export("confidence")]
		float Confidence { get; }
	}
}
