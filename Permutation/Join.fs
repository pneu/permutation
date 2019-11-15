module Join

exception JoinsBySeparatorsShouldNotEmptyException

let rec private joinsBy' (separators: string list) (list: string list): string list =
    match list with
    | [] -> []
    | [ x ] -> [ x ]
    | x :: [ y ] -> List.map (fun s -> x + s + y) separators
    | x :: remain -> List.collect (fun r -> List.map (fun s -> x + s + r) separators) (joinsBy' separators remain)

[<CompiledName "JoinBy">]
let joinsBy (separators: string list) (list: string list): string list =
    if separators.IsEmpty then raise JoinsBySeparatorsShouldNotEmptyException
    joinsBy' separators list
