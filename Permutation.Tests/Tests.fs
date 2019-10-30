module Tests

open Xunit
open FsUnit.Xunit
open Permutation

[<Fact>]
let ``testPerm 2要素の場合``() =
    permutations [ "a"; "b" ]
    |> should equal
           [ [ "a"; "b" ]
             [ "b"; "a" ] ]

[<Fact>]
let ``testPerm 3要素の場合``() =
    permutations [ 1; 2; 3 ]
    |> should equal
           [ [ 1; 2; 3 ]
             [ 1; 3; 2 ]
             [ 2; 1; 3 ]
             [ 2; 3; 1 ]
             [ 3; 1; 2 ]
             [ 3; 2; 1 ] ]
