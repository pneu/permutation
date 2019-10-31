namespace Join

module Tests =
    open Xunit
    open FsUnit.Xunit
    open Permutation

    [<Fact>]
    let joinTest() = joinBy "-" [ "a"; "b" ] |> should equal "a-b"
