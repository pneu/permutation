module Permutation

/// <summary>exclude <c>x</c> from <c>xs</c>.</summary>
let private exclude<'T when 'T: equality> (x: 'T) (xs: 'T list): 'T list = List.filter (fun y -> y <> x) xs

/// <summary>prepend <c>x</c> to all lists of <c>xss</c>.</summary>
let private prefix (x: 'T) (xss: 'T list list): 'T list list = List.map (fun xs -> x :: xs) xss

exception PermutateArgsIsShouldNotEmptyException

let rec private expand<'T when 'T: equality> (x: 'T) (xs: 'T list): 'T list list = permutate (exclude x xs) |> prefix x

and permutate<'T when 'T: equality> (xs: 'T list): 'T list list =
    match xs with
    | [] -> raise PermutateArgsIsShouldNotEmptyException
    | [ x ] -> [ xs ]
    | _ ->
        List.reduce (@) [ for x in xs -> expand x xs ]

exception JoinsByListIsShouldHaveTwoElementsAtLeastException

exception JoinsBySeparatorsShouldNotEmptyException

let rec private joinsBy' (separators: string list) (list: string list): string list =
    match list with
    | x :: [ y ] -> List.map (fun s -> x + s + y) separators
    | x :: remain -> List.collect (fun r -> List.map (fun s -> x + s + r) separators) (joinsBy' separators remain)
    | _ -> raise JoinsByListIsShouldHaveTwoElementsAtLeastException

let joinsBy (separators: string list) (list: string list): string list =
    if separators.IsEmpty then raise JoinsBySeparatorsShouldNotEmptyException
    joinsBy' separators list
