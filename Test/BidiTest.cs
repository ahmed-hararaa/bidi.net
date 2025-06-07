using Harara.Bidi;

namespace Test;

public class UnitTest1
{
    private static string FromCharCodes(List<int> codes)
    {
        return new string(codes.Select(c => (char)c).ToArray());
    }
    
    [Fact]
    public void DecompositionTests()
    {
        var a = FromCharCodes(Bidi.LogicalToVisual("أ"));
        var b = FromCharCodes(Bidi.LogicalToVisual("إ"));
        var c = FromCharCodes(Bidi.LogicalToVisual("ؤ"));

        var d = FromCharCodes(Bidi.LogicalToVisual("خطأ"));
        var e = FromCharCodes(Bidi.LogicalToVisual("كؤ"));
        var f = FromCharCodes(Bidi.LogicalToVisual("مئ"));

        Assert.Equal("ﺃ", a);
        Assert.Equal("ﺇ", b);
        Assert.Equal("ﺅ", c);
        Assert.Equal("ﺄﻄﺧ", d);
        Assert.Equal("ﺆﻛ", e);
        Assert.Equal("ﺊﻣ", f);
    }
    
    [Fact]
    public void NormalizingArabicShaddaPairs()
    {
        var shaddaCompMapping = new Dictionary<string,int>(){
            { "\u064C\u0651", 64606 },
            { "\u0651\u064C", 64606 },
            { "\u064D\u0651", 64607 },
            { "\u0651\u064D", 64607 },
            { "\u064E\u0651", 64608 },
            { "\u0651\u064E", 64608 },
            { "\u064F\u0651", 64609 },
            { "\u0651\u064F", 64609 },
            { "\u0650\u0651", 64610 },
            { "\u0651\u0650", 64610 },
            { "\u0651\u0670", 64611 },
            { "\u0670\u0651", 64611 },
        };
        foreach (var pair in shaddaCompMapping.Keys) {
            // we added dummy letter [\u0645]=> 65249 to get a real composition
            Assert.Equal(
                Bidi.LogicalToVisual($"\u0645{pair}"),
                [shaddaCompMapping[pair], 65249]
            );
        }
    }
}