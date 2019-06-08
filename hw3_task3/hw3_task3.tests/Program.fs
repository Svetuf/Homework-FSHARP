module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Calculate one num.`` () = 
        calculus (Number(9052019)) |> should equal 9052019

    [<Test>]
    let ``Calculate (6+6)*6.`` () = 
        calculus (Multiply(Plus(Number 6, Number 6), Number 6)) |> should equal 72

    [<Test>]
    let ``Calculate 2*(900/3) - 600.`` () = 
        calculus (Minus(Multiply(Number 2, Divide(Number 900, Number 3)), Number 600)) |> should equal 0