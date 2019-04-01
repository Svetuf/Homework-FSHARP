module tests

open NUnit.Framework
open FsUnit
open logic

    [<Test>]
    let ``Check if madam is palindrome`` () =
        palindrome "madam" |> should equal "it's palindrome"
    
    [<Test>]
    let ``Check if madama is palindrome`` () =
        palindrome "madama" |> should equal "it's not a palindrome"
    
    [<Test>]
    let ``Check if "" is palindrome`` () =
        palindrome "" |> should equal "it's palindrome"
    
    [<Test>]
    let ``Check if mam is palindrome`` () =
        palindrome "mam" |> should equal "it's palindrome"
    
    [<Test>]
    let ``Check if abba is palindrome`` () =
        palindrome "abba" |> should equal "it's palindrome"