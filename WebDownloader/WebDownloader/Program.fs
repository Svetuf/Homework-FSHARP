module Logic

    open FSharp.Data
    open System.Net
    open System.IO

    /// Get url adress as string. Return list of (Length of page,Website name).
    let downloadAllPagesFromLinks (page: string) =

        /// Returns a list of all links from page.
        let getLinks = 
            HtmlDocument.Load(page).Descendants ["a"]
            |> Seq.choose (fun x -> 
                   x.TryGetAttribute("href")
                   |> Option.map (fun a -> a.Value()))
            |> Seq.filter (fun x -> 
                        x.StartsWith("http"))
            |> Seq.toList

        /// Workflow to async load of urls, also print information.
        let fetchAsync (url: string) =
           async {
               let request = WebRequest.Create(url)
               use! response = request.AsyncGetResponse()
               use stream = response.GetResponseStream()
               use reader = new StreamReader(stream)
               let html = reader.ReadToEnd()
               printfn "%s --- %d" url html.Length
               return html.Length
           }

        List.map (fun x -> ( x |> fetchAsync |> Async.StartAsTask , x)) getLinks