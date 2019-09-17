module Tests

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``one plus two``() =
        let result = WorkFlowString() {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }
        result |> should equal (Some 3)
     
    [<Test>]
    let ``one plus ъ``() =
        let res = WorkFlowString() {
            let! x = "1"
            let! y = "Ъ"
            let z = x + y
            return z
        }
        res |> should equal None