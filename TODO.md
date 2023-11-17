Make some classes into polled object with fixed lifetime
1. CommandEncoder start with Device.CreateCommandEncoder() ends with CommandEncoder.Finish()
2. RenderPassEncoder start with CommandEncoder.BeginRenderPass() ends with RenderPassEncoder.End()
3. CommandBuffer start with CommandEncoder.Finish() ends with Queue.Submit()

Make specialized classes for swapChain with fixed lifetime to help with gc in main loop
1. TextureView from SwapChain.GetCurrentTextureView()
2. Texture from SwapChain.GetCurrentTexture()