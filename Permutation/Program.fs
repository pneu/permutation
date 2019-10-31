module Program

open Permutation

exception TooFewArgumentsException

[<EntryPoint>]
let main argv =
    try
        if Array.isEmpty argv then raise TooFewArgumentsException
        let p = permutations (Array.toList argv)
        printfn "%A" p
        0
    with :? TooFewArgumentsException ->
        eprintfn "Too few Arguments"
        1
