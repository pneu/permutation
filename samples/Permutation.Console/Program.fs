module Program

open Permutation
open Join

[<EntryPoint>]
let main argv =
    permutaionsOfPowerset (Array.toList argv)
    |> List.collect (fun cats -> joinsBy [ "-"; "_"; " "; "" ] cats)
    |> List.iter (printfn "%s")
    0
