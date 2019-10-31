namespace Join

module Tests =
    open System
    open Xunit
    open FsUnit.Xunit
    open Permutation

    [<Fact>]
    let ``joinsBy 0要素``() =
        (fun () -> joinsBy [ "-"; " " ] [] |> ignore)
        |> should throw typeof<JoinsByListIsShouldHaveTwoElementsAtLeastException>

    [<Fact>]
    let ``joinsBy 1要素``() =
        (fun () -> joinsBy [ "-"; " " ] [ "a" ] |> ignore)
        |> should throw typeof<JoinsByListIsShouldHaveTwoElementsAtLeastException>

    [<Fact>]
    let ``joinsBy 2要素 separator0種類``() =
        (fun () -> joinsBy [] [ "a"; "b" ] |> ignore) |> should throw typeof<JoinsBySeparatorsShouldNotEmptyException>

    [<Fact>]
    let ``joinsBy 2要素 separator1種類``() = joinsBy [ "-" ] [ "a"; "b" ] |> should equal [ "a-b" ]

    [<Fact>]
    let ``joinsBy 2要素 separator2種類``() = joinsBy [ "-"; " " ] [ "a"; "b" ] |> should equal [ "a-b"; "a b" ]

    [<Fact>]
    let ``joinsBy 3要素 separator2種類``() =
        joinsBy [ "-"; " " ] [ "a"; "b"; "c" ] |> should equal [ "a-b-c"; "a b-c"; "a-b c"; "a b c" ]
