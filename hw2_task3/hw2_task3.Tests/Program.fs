    module tests

    open NUnit.Framework
    open FsUnit
    open logic

    [<Test>]
    let ``Sorting [1;3;2] should return [1;2;3]`` () =
         mergeSort [1;3;2] |> should equal [1;2;3]
    [<Test>]
    let ``Sorting [] should return []`` () =
         mergeSort [] |> should equal []

    [<Test>]
    let ``Sorting [1;1;1;1;1;1;1] should return [1;1;1;1;1;1;1]`` () =
         mergeSort [1;1;1;1;1;1;1] |> should equal [1;1;1;1;1;1;1]

    [<Test>]
    let ``Sorting [9;8;7;6;5;4;3;2;1] should return [1;2;3;4;5;6;7;8;9]`` () =
         mergeSort [9;8;7;6;5;4;3;2;1] |> should equal [1;2;3;4;5;6;7;8;9]