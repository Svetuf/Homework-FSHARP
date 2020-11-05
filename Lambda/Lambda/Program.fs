module Logic

open System

/// A type representing a lambda term.
type Term =
    | Var of Char
    | Body of Term * Term
    | Lambda of Char * Term

/// Finds all free variables in a lambda expression.
let findFreeVars term=
    let rec recGetFV t vars =
        match t with
        | Var var -> var :: vars
        | Body (S, T) -> (recGetFV S vars) @ (recGetFV T vars)
        | Lambda (var, S) -> (recGetFV S vars) |> List.filter (fun x -> x <> var)
    recGetFV term []

/// Finding a new name for a variable.
let findFreeName S T =
    (Set.ofSeq ['a' .. 'z'] - Set.ofList ((findFreeVars S) @ (findFreeVars T))).MinimumElement
    
/// Substitution of the term S into the term T instead of the variable v.
let rec substitute T v S =
    match T with
    | Var x -> 
        if v = x
        then S
        else T
    | Body (T1, T2) ->
        Body (substitute T1 v S, substitute T2 v S)
    | Lambda (var, T) -> 
        match S with
        | Var (_) when v = var -> T
        | _ when (not((findFreeVars S) |> List.contains var) 
                    || (not((findFreeVars T) |> List.contains v))) -> 
            Lambda (var, substitute T v S)
        | _ ->
            Lambda (findFreeName S T, substitute (substitute S var (Var (var))) v T)
            
/// Normal strategy betta reduction algorithm.
let rec betaReduce term =
    match term with
    | Var v -> Var v
    | Body (S1, S2) ->
        match S1 with
        | Lambda (v, S) -> 
            betaReduce (substitute S v S2)
        | _ -> 
            Body (betaReduce S1, betaReduce S2)
    | Lambda (v, T) -> Lambda(v, betaReduce T)
    
        