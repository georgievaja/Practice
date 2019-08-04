open System
open BinaryGap

[<EntryPoint>]
let main argv =
    let testData = ["9"; "529"; "51272"; "15"; "53";"2147483647";"2147483648";"0"; "-1"; "A";null;]
    let testData2 = ["51272";]

    testData
                    |> List.map (fun d -> (getBinaryGap2 d, d))
                    |> List.iter (printfn "%A")
   
    0 // return an integer exit code
