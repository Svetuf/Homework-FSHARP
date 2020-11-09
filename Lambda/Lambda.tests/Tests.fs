namespace Tests.Tests

module Tests =

    open NUnit.Framework
    open FsUnit
    open Logic
        
    [<Test>]
    let ``K I = K*`` () =
        betaReduce (Application(Lambda('x', Lambda ('y', Var 'x')), Lambda('x', Var 'x'))) |>
        should equal (Lambda('y', Lambda ('x', Var 'x')))
            
    [<Test>]
    let ``I I = I`` () =
        betaReduce (Application(Lambda('x', Var 'x'), Lambda('x', Var 'x'))) |>
        should equal (Lambda('x', Var 'x'))

    [<Test>]
    let ``K a b``() = 
       betaReduce (Application(Application(Lambda('x', Lambda('y', Var 'x')), Var 'a'), Var 'b')) |>
       should equal (Application (Lambda ('y',Var 'a'),Var 'b')) 

    [<Test>]
    let ``((\a.(\b.b b) (\b.b b)) b) ((\c.(c b)) (\a.a))`` () =
        betaReduce (Application (Application(Application(Lambda('a', Lambda('b', Application(Var('b'), Var('b')))), Lambda('b', Application(Var('b'), Var('b')))), Var('b')), Application(Lambda('c', Application(Var('c'), Var('b'))), Lambda('a', Var('a'))))) |>
        should equal (Application (Application (Lambda (('b'), Application (Var ('b'), Var ('b'))), Var ('b')), Var ('b')))
        