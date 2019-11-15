namespace Tests

module JoinsBy =
    open System
    open Xunit
    open FsUnit.Xunit
    open Join

    [<Fact>]
    let ``0 element``() = joinsBy [ "-"; " " ] [] |> should be Empty

    [<Fact>]
    let ``1 element``() = joinsBy [ "-"; " " ] [ "a" ] |> should equal [ "a" ]

    [<Fact>]
    let ``2 elements, 0 separator``() =
        (fun () -> joinsBy [] [ "a"; "b" ] |> ignore) |> should throw typeof<JoinsBySeparatorsShouldNotEmptyException>

    [<Fact>]
    let ``2 elements, 1 separator``() = joinsBy [ "-" ] [ "a"; "b" ] |> should equal [ "a-b" ]

    [<Fact>]
    let ``2 elements, 2 separators``() = joinsBy [ "-"; " " ] [ "a"; "b" ] |> should equal [ "a-b"; "a b" ]

    [<Fact>]
    let ``3 elements, 2 separators``() =
        joinsBy [ "-"; " " ] [ "a"; "b"; "c" ] |> should equal [ "a-b-c"; "a b-c"; "a-b c"; "a b c" ]
