module logic 
//open System

    let reverseString (s:string) = new string(Array.rev (s.ToCharArray()))

    let palindrome word =
        match word with
        | reversed when reversed = reverseString word -> "it's palindrome"
        | _ -> "it's not a palindrome"

