module Permutation

open System

/// <summary>exclude <c>x</c> from <c>xs</c>.</summary>
let private exclude<'T when 'T: equality> (x: 'T) (xs: 'T list): 'T list = List.filter (fun y -> y <> x) xs

/// <summary>prepend <c>x</c> to all lists of <c>xss</c>.</summary>
let private prefix (x: 'T) (xss: 'T list list): 'T list list = List.map (fun xs -> x :: xs) xss

let rec private expand<'T when 'T: equality> (x: 'T) (xs: 'T list): 'T list list =
    permutations (exclude x xs) |> prefix x
and permutations<'T when 'T: equality> (xs: 'T list): 'T list list =
    match xs with
    | [x] -> [xs]
    | _ -> List.reduce (@) [for x in xs -> expand x xs]

exception TooFewArgumentsException

[<EntryPoint>]
let main argv =
    try
        if Array.isEmpty argv then raise TooFewArgumentsException
        let p = permutations (Array.toList argv)
        printfn "%A" p
        0
    with
        | :? TooFewArgumentsException ->
            eprintfn "Too few Arguments"
            1
