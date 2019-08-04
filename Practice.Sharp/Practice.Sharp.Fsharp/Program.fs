open System
open BinaryGap

[<EntryPoint>]
let main argv =
    let testData = ["9"; "529"; "51272"; "15"; "53";"2147483647";"2147483648";"0"; "-1"; "A";null;]

    let result = testData
                    |> List.map (fun d -> (getBinaryGap d, d))
   
    0 // return an integer exit code
