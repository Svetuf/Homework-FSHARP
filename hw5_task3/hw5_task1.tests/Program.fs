module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``One pair of brackets ()``() =
        checkBracket "()" |> should equal true

    [<Test>]
    let ``One pair of brackets []``() =
        checkBracket "[]" |> should equal true

    [<Test>]
    let ``One pair of brackets {}``() =
        checkBracket "{}" |> should equal true

    [<Test>]
    let ``Here is wrong seq``() =
        checkBracket "{([Why i dont learn in ITMO?])}(Because i'm cool" |> should equal false

    [<Test>]
    let ``Empty seq``() =
        checkBracket "" |> should equal true

    [<Test>]
    let ``Wrong set from Yurii``() =
        checkBracket "([)]" |> should equal false