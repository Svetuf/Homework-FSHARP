module Tests

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Test from task``() =
        let result = RoundFlow 3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
        result |> should (equalWithin 0.001) 0.048

    [<Test>]
    let ``Test namba 2 (accuracy 6)``() =
        let res = RoundFlow 6 {
            let! a = 5.0 / 2.0
            let! b = 0.5
            return 1.0 / (a + b)
        }
        res |> should (equalWithin 0.000001) 0.333333

    [<Test>]
    let ``Test namba 3(accyracy 9)``() =
        let res = RoundFlow 9 {
            let! a = 5.0 / 2.0
            let! b = 0.5
            return 1.0 / (a + b)
        }
        res |> should (equalWithin 0.000000001) 0.333333333