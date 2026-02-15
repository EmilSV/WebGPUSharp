using WebGpuSharp;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp.Tests;

public class Utf8Test
{
    private const string CHINESE_TEST_TEXT =
    """
    天地玄黄 宇宙洪荒 日月盈昃 辰宿列张 寒来暑往 秋收冬藏

    闰馀成岁 律吕调阳 云腾致雨 露结为霜 金生丽水 玉出昆冈

    剑号巨阙 珠称夜光 果珍李柰 菜重芥姜 海咸河淡 鳞潜羽翔

    龙师火帝 鸟官人皇 始制文字 乃服衣裳 推位让国 有虞陶唐

    天地玄黄 宇宙洪荒 日月盈昃 辰宿列张 寒来暑往 秋收冬藏

    闰馀成岁 律吕调阳 云腾致雨 露结为霜 金生丽水 玉出昆冈

    剑号巨阙 珠称夜光 果珍李柰 菜重芥姜 海咸河淡 鳞潜羽翔

    龙师火帝 鸟官人皇 始制文字 乃服衣裳 推位让国 有虞陶唐

    天地玄黄 宇宙洪荒 日月盈昃 辰宿列张 寒来暑往 秋收冬藏

    闰馀成岁 律吕调阳 云腾致雨 露结为霜 金生丽水 玉出昆冈

    剑号巨阙 珠称夜光 果珍李柰 菜重芥姜 海咸河淡 鳞潜羽翔

    龙师火帝 鸟官人皇 始制文字 乃服衣裳 推位让国 有虞陶唐

    天地玄黄 宇宙洪荒 日月盈昃 辰宿列张 寒来暑往 秋收冬藏

    闰馀成岁 律吕调阳 云腾致雨 露结为霜 金生丽水 玉出昆冈

    剑号巨阙 珠称夜光 果珍李柰 菜重芥姜 海咸河淡 鳞潜羽翔

    龙师火帝 鸟官人皇 始制文字 乃服衣裳 推位让国 有虞陶唐
    
    """;


    [Fact]
    public unsafe void Text_Conversion_To_Utf8()
    {
        WebGpuAllocatorLogicBlock allocatorLogicBlock = default;
        const int stackAllocSize = 1024 * sizeof(byte);
        byte* stackAllocPtr = stackalloc byte[stackAllocSize];

        using var allocator = WebGpuMarshallingMemory.GetAllocatorHandle(
            ref allocatorLogicBlock,
            stackAllocPtr,
            stackAllocSize
        );

        var CHINESE_TEST_TEXT_UTF8_BYTE_COUNT = System.Text.Encoding.UTF8.GetByteCount(CHINESE_TEST_TEXT);
        var chineseTestTextUtf = System.Text.Encoding.UTF8.GetBytes(CHINESE_TEST_TEXT); 

        var codeUtf8Span = WebGPUMarshal.ToUtf8Span(CHINESE_TEST_TEXT, allocator, addNullTerminator: false);

        Assert.Equal(CHINESE_TEST_TEXT, System.Text.Encoding.UTF8.GetString(codeUtf8Span));
    }
}
