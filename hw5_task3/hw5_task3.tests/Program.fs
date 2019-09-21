module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Add new write`` () =
        let book = PhoneBook()
        let res = Map.empty
        let mapToCompare = Map.empty
                              .Add("Person1", "123")
                              .Add("Person2", "456")
        let res = book.AddNote "Person1" "123" res
        let res = book.AddNote "Person2" "456" res
        res |> should equal mapToCompare

    [<Test>]
    let ``Find phone by name`` () =
        let book = PhoneBook ()
        let res = Map.empty

        let res = book.AddNote "Person1" "123" res
        let res = book.AddNote "Person2" "456" res
        
        book.FindPhoneByName "Person1" res |> should equal (Some("123"))
        
    [<Test>]
    let ``Find phone by name but wrong`` () =
        let book = PhoneBook ()
        let res = Map.empty

        let res = book.AddNote "Person1" "123" res
        let res = book.AddNote "Person2" "456" res

        book.FindPhoneByName "Person 1" res |> should equal None

    [<Test>]
    let ``Find name by phone`` () =
        let book = PhoneBook ()
        let res = Map.empty

        let res = book.AddNote "Person1" "123" res
        let res = book.AddNote "Person2" "456" res

        book.FindNameByPhone "123" res |> should equal (Some("Person1"))

    [<Test>]
    let ``Serializing`` () =
        let book = PhoneBook ()
        
        let toSave = Map.empty
        let res = Map.empty

        let toSave = book.AddNote "Person1" "123" toSave
        let toSave = book.AddNote "Person2" "456" toSave

        book.Serealize toSave

        let res = book.Deserealize

        res |> should equal toSave
