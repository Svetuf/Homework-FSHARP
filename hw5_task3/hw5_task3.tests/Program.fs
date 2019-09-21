module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Add new write`` () =
        let mutable book = phoneBook()
        let mutable res = Map.empty
        let mapToCompare = Map.empty
                              .Add("Person1", "123")
                              .Add("Person2", "456")
        res <- book.addNote "Person1" "123" res
        res <- book.addNote "Person2" "456" res
        res |> should equal mapToCompare

    [<Test>]
    let ``Find phone by name`` () =
        let mutable book = phoneBook ()
        let mutable res = Map.empty

        res <- book.addNote "Person1" "123" res
        res <- book.addNote "Person2" "456" res
        
        book.findPhoneByName "Person1" res |> should equal "123"
        
    [<Test>]
    let ``Find phone by name but wrong`` () =
        let mutable book = phoneBook ()
        let mutable res = Map.empty

        res <- book.addNote "Person1" "123" res
        res <- book.addNote "Person2" "456" res

        book.findPhoneByName "Person 1" res |> should equal "Nothing"

    [<Test>]
    let ``Find name by phone`` () =
        let mutable book = phoneBook ()
        let mutable res = Map.empty

        res <- book.addNote "Person1" "123" res
        res <- book.addNote "Person2" "456" res

        book.findNameByPhone "123" res |> should equal "Person1"

    [<Test>]
    let ``Serializing`` () =
        let mutable book = phoneBook ()
        
        let mutable toSave = Map.empty
        let mutable res = Map.empty

        toSave <- book.addNote "Person1" "123" toSave
        toSave <- book.addNote "Person2" "456" toSave

        book.serealize toSave

        res <- book.deserealize

        res |> should equal toSave
