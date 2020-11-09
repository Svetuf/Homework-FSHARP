module Logic

open System

/// A type representing a lambda term.
type Term =
    | Var of Char
    | Application of Term * Term
    | Lambda of Char * Term

/// Finds all free variables in a lambda expression.
let findFreeVars term =
    let rec recGetFV t vars =
        match t with
        | Var var -> var :: vars
        | Application (S, T) -> (recGetFV S vars) @ (recGetFV T vars)
        | Lambda (var, S) -> (recGetFV S vars) |> List.filter (fun x -> x <> var)
    recGetFV term []

/// Finding a new name for a variable.
let findFreeName s t =
    (Set.ofSeq ['a' .. 'z'] - Set.ofList ((findFreeVars s) @ (findFreeVars t))).MinimumElement
    
/// Substitution of the term S into the term T instead of the variable v.
let rec substitute t v s =
    let noNameConflict s var t v =
        (not((findFreeVars s) |> List.contains var) 
        || (not((findFreeVars t) |> List.contains v)))

    match t with
    | Var x -> 
        if v = x
        then s
        else t
    | Application (t1, t2) ->
        Application (substitute t1 v s, substitute t2 v s)
    | Lambda (var, t) -> 
        match s with
        | Var (_) when v = var -> t
        | _ when noNameConflict s var t v ->  Lambda (var, substitute t v s)
        | _ ->
            Lambda (findFreeName s t, substitute (substitute s var (Var (var))) v t)
            
/// Normal strategy beta-reduction algorithm.
let rec betaReduce term =
    match term with
    | Var v -> Var v
    | Application (s1, s2) ->
        match s1 with
        | Lambda (v, s) -> 
            betaReduce (substitute s v s2)
        | _ -> 
            Application (betaReduce s1, betaReduce s2)
    | Lambda (v, t) -> Lambda(v, betaReduce t)
    
        