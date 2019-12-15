module Combination

open System.Collections.Generic

let rec combinations (n: int) (list: 'T seq): 'T seq seq =
    match n, list with
    | 0, _ -> seq { [] }
    | _, xs when Seq.isEmpty xs -> Seq.empty
    | k, x :: xs ->
        // Choose x and (k-1) elements from xs, or don't choose x and choose n from xs.
        (Seq.map (fun rs -> x :: rs) (combinations (k - 1) xs)) @ combinations k xs

let Combinate ((n: int), (list: IEnumerable<'T>)): IEnumerable<IEnumerable<'T>> =
    combinations n list
