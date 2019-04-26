module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``biggestPalindromeDotOfTwoNumbers should equal 906609`` () =
        biggestPalindromeDotOfTwoNumbers 1  |> should equal 906609