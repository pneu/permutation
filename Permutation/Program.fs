module Program

open Permutation

exception TooFewArgumentsException

[<EntryPoint>]
let main argv =
    try
        if Array.isEmpty argv then raise TooFewArgumentsException
        permutate (Array.toList argv)
        |> List.collect (fun cats -> joinsBy [ "-"; "_"; " "; "" ] cats)
        |> printfn "%A"
        0
    with :? TooFewArgumentsException ->
        eprintfn "Too few Arguments"
        1
