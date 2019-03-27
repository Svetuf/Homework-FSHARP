module tests

    open NUnit.Framework
    open FsUnit
    open logic

    [<Test>]
    let ``The index of element "6" in array [7;32;4;6;4;6] is Some(3)`` () =
        findElement [7;32;4;6;4;6] 6 |> should equal (Some(4))

    [<Test>]
    let ``The index of element "0" in array [6;3;4;5;6;2;3;4] is None`` () =
        findElement [6;3;4;5;6;2;3;4] 0 |> should equal (None)

    [<Test>]
    let ``The index of element "0" in array [] is None`` () =
        findElement [] 0 |> should equal (None)

    [<Test>]
    let ``The index of element "2" in array [6;3;2;2;6;2;3;4] is None`` () =
        findElement [6;3;4;5;6;2;3;4] 0 |> should equal (Some(3))

