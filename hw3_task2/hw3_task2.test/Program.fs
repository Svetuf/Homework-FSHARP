module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    // Tests whith trivial trees.

    let tree1 = 
        Tree (1, Empty, Empty)

    let tree1AfterExecution = 
        Tree (239, Empty, Empty)

    [<Test>]
    let ``Multiply by some good number`` () =
        mapForTree (fun x -> 239 * x) tree1 |> should equal tree1AfterExecution

    // Tests when trees is about integer type.

    let tree2 =
        Tree (2, 
            Tree (1, Empty, Empty), 
            Tree (3, 
                Tree (5, Empty, Empty), 
                Tree (4, Empty, Empty)))

    let tree2AfterExecution =
        Tree (4, 
            Tree (1, Empty, Empty), 
            Tree (9, 
                Tree (25, Empty, Empty), 
                Tree (16, Empty, Empty)))

    [<Test>]
    let ``Make every elemet of tree be square`` () =
        mapForTree (fun x -> x * x) tree2 |> should equal tree2AfterExecution

    // Tests when trees is about string type.

    let tree3 =
        Tree ("c", 
            Tree ("b", Empty, Empty), 
            Tree ("d", 
                Tree ("a", Empty, Empty), 
                Tree ("e", Empty, Empty)))

    let tree3AfterExecution =
        Tree ("cF#", 
            Tree ("bF#", Empty, Empty), 
            Tree ("da", 
                Tree ("aF#", Empty, Empty), 
                Tree ("eF#", Empty, Empty)))

    [<Test>]
    let ``Adding 'F#' to each element of a tree`` () =
        mapForTree (fun x -> x + "F#") tree3 |> should equal tree3AfterExecution