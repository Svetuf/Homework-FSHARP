module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Add new write`` () =
        let mutable book = PhoneBook()
        let mutable res = Map.empty
        let mapToCompare = Map.empty
                              .Add("Person1", "123")
                              .Add("Person2", "456")
        res <- book.AddNote "Person1" "123" res
        res <- book.AddNote "Person2" "456" res
        res |> should equal mapToCompare

    [<Test>]
    let ``Find phone by name`` () =
        let mutable book = PhoneBook ()
        let mutable res = Map.empty

        res <- book.AddNote "Person1" "123" res
        res <- book.AddNote "Person2" "456" res
        
        book.FindPhoneByName "Person1" res |> should equal "123"
        
    [<Test>]
    let ``Find phone by name but wrong`` () =
        let mutable book = PhoneBook ()
        let mutable res = Map.empty

        res <- book.AddNote "Person1" "123" res
        res <- book.AddNote "Person2" "456" res

        book.FindPhoneByName "Person 1" res |> should equal "Nothing"

    [<Test>]
    let ``Find name by phone`` () =
        let mutable book = PhoneBook ()
        let mutable res = Map.empty

        res <- book.AddNote "Person1" "123" res
        res <- book.AddNote "Person2" "456" res

        book.FindNameByPhone "123" res |> should equal "Person1"

    [<Test>]
    let ``Serializing`` () =
        let mutable book = PhoneBook ()
        
        let mutable toSave = Map.empty
        let mutable res = Map.empty

        toSave <- book.AddNote "Person1" "123" toSave
        toSave <- book.AddNote "Person2" "456" toSave

        book.Serealize toSave

        res <- book.Deserealize

        res |> should equal toSave
