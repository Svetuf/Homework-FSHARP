module Tests

    open Logic
    open NUnit.Framework
    open FsUnit


    [<Test>]
    let YaRuIsSave_ShouldReturnZero () =
        downloadAllPagesFromLinks "https://ya.ru/" |> List.length |> should equal 0

    [<Test>]
    let YuriiLitvinovPage_Contains_31Links () =
        downloadAllPagesFromLinks "https://compscicenter.ru/teachers/3392/" |> List.length |> should equal 31

    [<Test>]
    let RickRollSite_HaveOnlyOneLink () =
        downloadAllPagesFromLinks "https://www.latlmes.com/" |> List.length |> should equal 1


