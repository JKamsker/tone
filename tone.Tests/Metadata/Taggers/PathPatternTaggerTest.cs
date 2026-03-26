using System.Collections.Generic;
using System.Reflection;
using GrokNet;
using tone.Metadata.Taggers;
using tone.Tests._TestHelpers;
using Xunit;

namespace tone.Tests.Metadata.Taggers;

public class PathPatternTaggerTest
{
    [Fact]
    public void TestMapsSupportedMetadataFields()
    {
        var metadata = new MockMetadata();
        var results = new GrokResult(new List<GrokItem>
        {
            new("Genre", "Fantasy"),
            new("Artist", "J.K. Rowling"),
            new("Title", "Quidditch Through the Ages"),
            new("IgnoreDummy", "ignored"),
            new("Unknown", "ignored")
        });

        var mapResultsMethod = typeof(PathPatternTagger).GetMethod("MapResults", BindingFlags.NonPublic | BindingFlags.Static);

        Assert.NotNull(mapResultsMethod);
        mapResultsMethod!.Invoke(null, new object?[] { results, metadata });

        Assert.Equal("Fantasy", metadata.Genre);
        Assert.Equal("J.K. Rowling", metadata.Artist);
        Assert.Equal("Quidditch Through the Ages", metadata.Title);
    }
    
    [Fact]
    public void TestIgnoresNullResults()
    {
        var metadata = new MockMetadata
        {
            Genre = "Existing Genre"
        };

        var mapResultsMethod = typeof(PathPatternTagger).GetMethod("MapResults", BindingFlags.NonPublic | BindingFlags.Static);

        Assert.NotNull(mapResultsMethod);
        mapResultsMethod!.Invoke(null, new object?[] { null, metadata });

        Assert.Equal("Existing Genre", metadata.Genre);
    }
}
