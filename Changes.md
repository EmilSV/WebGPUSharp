
# Changelog

## [0.5.2] - 2026-02-16
### Overview
- Update Dawn to same version as chrome m145-d9f5a98 and fixed issues where shaders code that need reallocation threw an exception.

### Fixed
- Fixed an issue where shaders code that need reallocation threw an exception.

### Added
- Added `Texture.GetTextureBindingViewDimension()`
- Added `TextureHandle.GetTextureBindingViewDimension()`

### Changed
- `Device.GetLimits(ref Limits)` returns a status.


## [0.5.1] - 2026-01-17
### Fixed
- Fixed `Device.GetLimits()` and `DeviceHandle.GetLimits()` crashing when called.
- Fixed `DeviceHandle.GetLimits()` and `DeviceHandle.GetLimits()` crashing when called.

### Changed
- Readme.md updated to reflect changes in 0.5.0

## [0.5.0] - 2026-01-14

### Overview
- Update Dawn to same version as chrome m144-a8d1e55

- Removed the concept of owned and unowned handles all handle are now unowned by default. Use the `.AddRef()` method on the handle to create an owned handle from the borrowed handle.

- All async api like `RequestDevice` now have 3 version a callback version, a task based version with `Async` suffix and synchronous version with `Sync` suffix with a timeout.

- WebGPUSharp is now using "a event thread" internally to handle WebGPU callbacks. This means that all callbacks will be invoked on that thread. this change was made to avoid the "undefined behavior" of calling the webgpu api inside a callback that was invoked from webgpu itself via AllowSpontaneous.  

- Some handle now require the owning instance when converted to manged handle to use the instance for event callbacks. 

- Encoders are now locked to the thread they where created and will throw on other threads as they are not thread safe.

### Added
- Added `Adapter.RequestDeviceSync` for synchronous device request with timeout.
- Added `Buffer.MapSync` for synchronous buffer mapping with timeout.
- Added `Device.CreateComputePipelineSync` for synchronous compute pipeline creation with timeout.
- Added `ShaderModule.GetCompilationInfoSync` for synchronous shader compilation info retrieval with timeout.
- Added `Instance.RequestAdapterSync` for synchronous adapter request with timeout.
- Added `Queue.OnSubmittedWorkDone`, `Queue.OnSubmittedWorkDoneAsync` and `Queue.OnSubmittedWorkDoneSync` to notify when all work submitted to the queue is done.



### Changed
- `AdapterHandle.AddRef()` now returns it self for easier chaining.
- `BindGroupHandle.AddRef()` now returns it self for easier chaining.
- `BindGroupLayoutHandle.AddRef()` now returns it self for easier chaining.
- `BufferHandle.AddRef()` now returns it self for easier chaining.
- `CommandBufferHandle.AddRef()` now returns it self for easier chaining.
- `CommandEncoderHandle.AddRef()` now returns it self for easier chaining.
- `ComputePassEncoderHandle.AddRef()` now returns it self for easier chaining.
- `ComputePipelineHandle.AddRef()` now returns it self for easier chaining.
- `DeviceHandle.AddRef()` now returns it self for easier chaining.
- `ExternalTextureHandle.AddRef()` now returns it self for easier chaining.
- `InstanceHandle.AddRef()` now returns it self for easier chaining.
- `PipelineLayoutHandle.AddRef()` now returns it self for easier chaining.
- `QuerySetHandle.AddRef()` now returns it self for easier chaining.
- `QueueHandle.AddRef()` now returns it self for easier chaining.
- `RenderBundleEncoderHandle.AddRef()` now returns it self for easier chaining.
- `RenderBundleHandle.AddRef()` now returns it self for easier chaining.
- `RenderPassEncoderHandle.AddRef()` now returns it self for easier chaining.
- `RenderPipelineHandle.AddRef()` now returns it self for easier chaining.
- `SamplerHandle.AddRef()` now returns it self for easier chaining.
- `ShaderModuleHandle.AddRef()` now returns it self for easier chaining.
- `TextureHandle.AddRef()` now returns it self for easier chaining.
- `TextureViewHandle.AddRef()` now returns it self for easier chaining.

- `Adapter` now requires an instance when created from handle.
- `Adapter.RequestDeviceAsync` that before took a callback is now called `Adapter.RequestDevice` and the callback now also gets a status parameter and an error message parameter.
- `Buffer.MapAsync` that before took a callback is now called `Buffer.Map` and the callback now also gets a status parameter and an error message parameter.`
- `Device.CreateComputePipelineAsync` that before took a callback is now called `Device.CreateComputePipeline` and the callback now also gets a status parameter and an error message parameter.
- `Instance.RequestAdapterAsync` that before took a callback is now called `Instance.RequestAdapter` and the callback now also gets a status parameter and an error message parameter.
- `WebGPUMarshal.GetBorrowHandlesAsPtrAndLength` name change to `GetHandlesAsPtrAndLength`
- `WebGPUMarshal.GetBorrowHandle` name change to `GetHandle`

- `AdapterHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `AdapterHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `BindGroupHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `BindGroupLayoutHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `BufferHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `CommandBufferHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `ComputePipelineHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `DeviceHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `ExternalTextureHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `InstanceHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `PipelineLayoutHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `QuerySetHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `QueueHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `RenderBundleHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `RenderPassEncoderHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `RenderPipelineHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `SamplerHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `ShaderModuleHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `TextureHandle.ToSafeHandle` no longer has a incrementRefCount parameter.
- `TextureViewHandle.ToSafeHandle` no longer has a incrementRefCount parameter.


### Removed
- Removed `DeviceDescriptor.DeviceLostCallbackMode` property.
- Removed `WebGPUMarshal.GetOwnedHandle`
- Removed `Instance.ProcessEvents` method as it does now work well with multithreading https://github.com/webgpu-native/webgpu-headers/issues/491 and the event thread take care of event processing.
- Removed `AdapterHandle.RequestDeviceAsync` methods.
- Removed `InstanceHandle.RequestAdapterAsync` methods.