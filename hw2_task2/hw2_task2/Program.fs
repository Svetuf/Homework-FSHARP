module logic 
open System
    let reverse (someString: string): string = 
        someString.ToCharArray() |> Array.rev |> System.String

    let palindrome word =
        match word with
        | reversed when reversed = reverse word -> "it's palindrome"
        | _ -> "it's not a palindrome"

