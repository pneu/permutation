module Permutation

/// <summary>exclude <c>x</c> from <c>xs</c>.</summary>
let private exclude<'T when 'T: equality> (x: 'T) (xs: 'T list): 'T list = List.filter (fun y -> y <> x) xs

/// <summary>prepend <c>x</c> to all lists of <c>xss</c>.</summary>
let private prefix (x: 'T) (xss: 'T list list): 'T list list = List.map (fun xs -> x :: xs) xss

let rec private expand<'T when 'T: equality> (x: 'T) (xs: 'T list): 'T list list = permutate (exclude x xs) |> prefix x

and permutate<'T when 'T: equality> (xs: 'T list): 'T list list =
    match xs with
    | [ x ] -> [ xs ]
    | _ ->
        List.reduce (@) [ for x in xs -> expand x xs ]

let joinBy (separator: string) (list: string list): string = List.reduce (fun x y -> x + separator + y) list
