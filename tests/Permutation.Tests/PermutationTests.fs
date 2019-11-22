namespace Tests

module Permutation =
    open Xunit
    open FsUnit.Xunit
    open Permutation

    [<Fact>]
    let ``permutations: 2 elements``() =
        permutations [ "a"; "b" ]
        |> should equal
               [ [ "a"; "b" ]
                 [ "b"; "a" ] ]

    [<Fact>]
    let ``permutations: 3 elements``() =
        permutations [ "a"; "c"; "b" ]
        |> should equal
               [ [ "a"; "c"; "b" ]
                 [ "a"; "b"; "c" ]
                 [ "c"; "a"; "b" ]
                 [ "c"; "b"; "a" ]
                 [ "b"; "a"; "c" ]
                 [ "b"; "c"; "a" ] ]

    [<Fact>]
    let ``permutaionsOfPowerset: 2 elements``() =
        permutaionsOfPowerset [ "a"; "b" ]
        |> should equal
               [ [ "a"; "b" ]
                 [ "b"; "a" ]
                 [ "a" ]
                 [ "b" ]
                 [] ]

    [<Fact>]
    let ``permutaionsOfPowerset: 3 elements``() =
        permutaionsOfPowerset [ 1; 3; 2 ]
        |> should equal
               [ [ 1; 3; 2 ]
                 [ 1; 2; 3 ]
                 [ 3; 1; 2 ]
                 [ 3; 2; 1 ]
                 [ 2; 1; 3 ]
                 [ 2; 3; 1 ]
                 [ 1; 3 ]
                 [ 3; 1 ]
                 [ 1; 2 ]
                 [ 2; 1 ]
                 [ 3; 2 ]
                 [ 2; 3 ]
                 [ 1 ]
                 [ 3 ]
                 [ 2 ]
                 [] ]
