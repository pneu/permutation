module Permutation

open Combination

/// <summary>prepend <c>x</c> to all lists of <c>xss</c>.</summary>
let private prefix (x: 'T) (xss: 'T list list): 'T list list = List.map (fun xs -> x :: xs) xss

/// <summary>exclude <c>x</c> from <c>xs</c>.</summary>
let private exclude<'T when 'T: equality> (x: 'T) (xs: 'T list): 'T list = List.filter (fun y -> y <> x) xs

[<CompiledName "Permutate">]
let rec permutations<'T when 'T: equality> (xs: 'T list): 'T list list =
    match xs with
    | [] -> [ [] ]
    | [ _ ] -> [ xs ]
    | _ ->
        List.reduce (@) [ for x in xs -> expand x xs ]

and private expand<'T when 'T: equality> (x: 'T) (xs: 'T list): 'T list list = permutations (exclude x xs) |> prefix x

let permutaionsOfPowerset<'T when 'T: equality> (xs: 'T list): 'T list list =
    [ for i in 0 .. (List.length xs) -> combinations i xs |> List.collect permutations ]
    |> List.rev
    |> List.reduce (@)
