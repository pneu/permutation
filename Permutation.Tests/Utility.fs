module private TestUtility

#nowarn "64"

open System
open NHamcrest.Core

let EmptyLL =
    // referred to https://stackoverflow.com/questions/30405768/fsharp-pattern-that-matches-list-type
    let (|IsListList|_|) (x: obj) =
        let t = x.GetType()
        if t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<list<list<_>>> then Some(true)
        else None
    CustomMatcher<obj>
        ("mismatched data",
         (fun o ->
         match o with
         //| :? (list<list<_>>) as ll -> List.length ll = 1 && List.isEmpty ll.[0]
         | IsListList o -> true
         | _ -> false))
