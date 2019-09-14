module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``One pair of brackets ()``() =
        checkBraket "()" |> should equal true

    [<Test>]
    let ``One pair of brackets []``() =
        checkBraket "[]" |> should equal true

    [<Test>]
    let ``One pair of brackets {}``() =
        checkBraket "{}" |> should equal true

    [<Test>]
    let ``Here is wrong seq``() =
        checkBraket "{([Why i dont learn in ITMO?])}(Because i'm cool" |> should equal false

    [<Test>]
    let ``Empty seq``() =
        checkBraket "" |> should equal true

    [<Test>]
    let ``Wrong set from Yurii``() =
        checkBraket "([)]" |> should equal false