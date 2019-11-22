namespace Tests

module Combination =
    open System
    open Xunit
    open FsUnit.Xunit
    open TestUtility
    open Combination

    [<Fact>]
    let ``0 choose 0``() = combinations 0 [] |> should be EmptyLL

    [<Fact>]
    let ``1 choose 0``() = combinations 0 [ 1 ] |> should be EmptyLL

    [<Fact>]
    let ``1 choose 1``() = combinations 1 [ 1 ] |> should equal [ [ 1 ] ]

    [<Fact>]
    let ``1 choose 2``() =
        let r = combinations 2 [ 1 ]
        r |> should be Empty

    [<Fact>]
    let ``2 choose 1``() =
        combinations 1 [ 1; 2 ]
        |> should equal
               [ [ 1 ]
                 [ 2 ] ]

    [<Fact>]
    let ``2 choose 2``() = combinations 2 [ 1; 2 ] |> should equal [ [ 1; 2 ] ]

    [<Fact>]
    let ``3 choose 2``() =
        combinations 2 [ 1; 3; 2 ]
        |> should equal
               [ [ 1; 3 ]
                 [ 1; 2 ]
                 [ 3; 2 ] ]
