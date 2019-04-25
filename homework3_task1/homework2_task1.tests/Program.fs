module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``The number of even elements in [2; 3; 4; 5] should equal 2, using first method`` () =
        numberOfEvenElementsInList1 [2; 3; 4; 5] |> should equal 2

    [<Test>]
    let ``The number of even elements in [2; 3; 4; 5] should equal 2, using second method`` () =
        numberOfEvenElementsInList2 [2; 3; 4; 5] |> should equal 2

    [<Test>]
    let ``The number of even elements in [2; 3; 4; 5] should equal 2, using third method`` () =
        numberOfEvenElementsInList3 [2; 3; 4; 5] |> should equal 2

    [<Test>]
    let ``The number of even elements in [2; 2; 2; 2; 4] should equal 5, using first method`` () =
        numberOfEvenElementsInList1 [2; 2; 2; 2; 4] |> should equal 5

    [<Test>]
    let ``The number of even elements in [2; 2; 2; 2; 4] should equal 5, using second method`` () =
        numberOfEvenElementsInList2 [2; 2; 2; 2; 4] |> should equal 5

    [<Test>]
    let ``The number of even elements in [2; 2; 2; 2; 4] should equal 5, using third method`` () =
        numberOfEvenElementsInList3 [2; 2; 2; 2; 4] |> should equal 5

    [<Test>]
    let ``The number of even elements in [1; 3; 5; 7; 9; 13; 13; 17] should equal 0, using first method`` () =
        numberOfEvenElementsInList1 [1; 3; 5; 7; 9; 13; 13; 17] |> should equal 0

    [<Test>]
    let ``The number of even elements in  [1; 3; 5; 7; 9; 13; 13; 17] should equal 0, using second method`` () =
        numberOfEvenElementsInList2 [1; 3; 5; 7; 9; 13; 13; 17] |> should equal 0

    [<Test>]
    let ``The number of even elements in  [1; 3; 5; 7; 9; 13; 13; 17] should equal 0, using third method`` () =
        numberOfEvenElementsInList3 [1; 3; 5; 7; 9; 13; 13; 17] |> should equal 0

    [<Test>]
    let ``The number of even elements in [] should equal 0, using first method`` () =
        numberOfEvenElementsInList1 [] |> should equal 0

    [<Test>]
    let ``The number of even elements in  [] should equal 0, using second method`` () =
        numberOfEvenElementsInList2 [] |> should equal 0

    [<Test>]
    let ``The number of even elements in  [] should equal 0, using third method`` () =
        numberOfEvenElementsInList3 [] |> should equal 0