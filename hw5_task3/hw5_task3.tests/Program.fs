module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Add new write`` () =
        let mutable book = phoneBook ()
        let mapToCompare = Map.empty
                              .Add("Person1", "123")
                              .Add("Person2", "456")
        book.addNote "Person1" "123" |> ignore
        book.addNote "Person2" "456" |> ignore
        
        book.phoneBook |> should equal mapToCompare

    [<Test>]
    let ``Find phone by name`` () =
        let mutable book = phoneBook ()
        let mapToCompare = Map.empty
                              .Add("Person1", "123")
                              .Add("Person2", "456")
        book.addNote "Person1" "123" |> ignore
        book.addNote "Person2" "456" |> ignore
        
        book.findPhoneByName "Person1" |> should equal "123"
        
    [<Test>]
    let ``Find phone by name but wrong`` () =
        let mutable book = phoneBook ()
        let mapToCompare = Map.empty
                              .Add("Person1", "123")
                              .Add("Person2", "456")
        book.addNote "Person1" "123" |> ignore
        book.addNote "Person2" "456" |> ignore

        book.findPhoneByName "Person 1" |> should equal "Nothing"

    [<Test>]
    let ``Find name by phone`` () =
        let mutable book = phoneBook ()
        let mapToCompare = Map.empty
                              .Add("Person1", "123")
                              .Add("Person2", "456")
        book.addNote "Person1" "123" |> ignore
        book.addNote "Person2" "456" |> ignore

        book.findNameByPhone "123" |> should equal "Person1"

    [<Test>]
    let ``Serializing`` () =
        let mutable book = phoneBook ()
        let mutable book2 = phoneBook ()
        let mapToCompare = Map.empty
                              .Add("Person1", "123")
                              .Add("Person2", "456")
        book.addNote "Person1" "123" |> ignore
        book.addNote "Person2" "456" |> ignore

        book.serealize
        book2.deserealize |> should equal "Successfully loaded data!"
