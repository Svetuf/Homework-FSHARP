namespace Tests.Tests

module Tests =

    open NUnit.Framework
    open FsUnit
    open Logic
        
    [<Test>]
    let ``K I = K*`` () =
        betaReduce (Body(Lambda('x', Lambda ('y', Var 'x')), Lambda('x', Var 'x'))) |>
        should equal (Lambda('y', Lambda ('x', Var 'x')))
            
    [<Test>]
    let ``I I = I`` () =
        betaReduce (Body(Lambda('x', Var 'x'), Lambda('x', Var 'x'))) |>
        should equal (Lambda('x', Var 'x'))

    [<Test>]
    let ``K a b``() = 
       betaReduce (Body(Body(Lambda('x', Lambda('y', Var 'x')), Var 'a'), Var 'b')) |>
       should equal (Body (Lambda ('y',Var 'a'),Var 'b')) 

    [<Test>]
    let ``((\a.(\b.b b) (\b.b b)) b) ((\c.(c b)) (\a.a))`` () =
        betaReduce (Body (Body(Body(Lambda('a', Lambda('b', Body(Var('b'), Var('b')))), Lambda('b', Body(Var('b'), Var('b')))), Var('b')), Body(Lambda('c', Body(Var('c'), Var('b'))), Lambda('a', Var('a'))))) |>
        should equal (Body (Body (Lambda (('b'), Body (Var ('b'), Var ('b'))), Var ('b')), Var ('b')))
        