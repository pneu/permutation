using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.FSharp.Collections;
using Xunit;

public class JoinTests
{
    FSharpList<T> FSList<T>(IEnumerable<T> list)
        => list.Reverse().Aggregate(FSharpList<T>.Empty, (acc, x) => FSharpList<T>.Cons(x, acc));

    [Fact]
    public void joinsBy_0要素()
    {
        var expected = FSList(new[] { "a-b" });
        Assert.Equal(
            expected,
            Join.JoinBy(FSList(new[] { "-" }), FSList(new[] { "a", "b" })));
    }
}