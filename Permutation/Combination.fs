module Combination


[<CompiledName "Combinate">]
let rec combinations (n: int) (list: 'T list): 'T list list =
    match n, list with
    | 0, _ -> [ [] ]
    | _, [] -> []
    | k, x :: xs ->
        // Choose x and (k-1) elements from xs, or don't choose x and choose n from xs.
        (List.map (fun rs -> x :: rs) (combinations (k - 1) xs)) @ combinations k xs
